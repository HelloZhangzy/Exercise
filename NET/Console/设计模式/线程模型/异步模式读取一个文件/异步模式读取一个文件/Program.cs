using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步模式读取一个文件
{
    class Program
    {
        // 测试文件
        private const string testFile = @"C:\AsyncReadTest.txt";
        private const int bufferSize = 1024;

        static void Main(string[] args)
        {
            // 删除已存在文件
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }

            // 写入一些东西以便后面读取
            using (FileStream stream = File.Create(testFile))
            {
                string content = "我是文件具体内容，我是不是帅得掉渣？";
                byte[] contentByte = Encoding.UTF8.GetBytes(content);
                stream.Write(contentByte, 0, contentByte.Length);
            }

            // 开始异步读取文件具体内容
            using (FileStream stream = new FileStream(testFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.Asynchronous))
            {
                byte[] data = new byte[bufferSize];
                // 将自定义类型对象实例作为参数
                ReadFileClass rfc = new ReadFileClass(stream, data);
                // 开始异步读取
                IAsyncResult result = stream.BeginRead(data, 0, data.Length, FinshCallBack, rfc);
                // 模拟做了一些其他的操作
                Thread.Sleep(3 * 1000);
                Console.WriteLine("主线程执行完毕，按回车键退出程序");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 传递给异步操作的回调方法
        /// </summary>
        public class ReadFileClass
        {
            // 以便回调方法中释放异步读取的文件流
            public FileStream stream;
            // 文件内容
            public byte[] data;

            public ReadFileClass(FileStream stream, byte[] data)
            {
                this.stream = stream;
                this.data = data;
            }
        }

        /// <summary>
        /// 完成异步操作后的回调方法
        /// </summary>
        /// <param name="result">状态对象</param>
        private static void FinshCallBack(IAsyncResult result)
        {
            ReadFileClass rfc = result.AsyncState as ReadFileClass;
            if (rfc != null)
            {
                // 必须的步骤：让异步读取占用的资源被释放掉
                int length = rfc.stream.EndRead(result);
                // 获取读取到的文件内容
                byte[] fileData = new byte[length];
                Array.Copy(rfc.data, 0, fileData, 0, fileData.Length);
                string content = Encoding.UTF8.GetString(fileData);
                // 打印读取到的文件基本信息
                Console.WriteLine("读取文件结束：文件长度为[{0}]，文件内容为[{1}]", length.ToString(), content);
            }
        }
    }
}
