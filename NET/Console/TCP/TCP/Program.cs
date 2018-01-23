using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

namespace TCP
{
    class Server
    {      
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 3 });
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start(); // 开始侦听
            Console.WriteLine("Start Listening ...");
            while (true)
            {
                // 获取一个连接，同步方法，在此处中断
                TcpClient client = listener.AcceptTcpClient();
                ServerThread wapper = new ServerThread(client);
            }
        }       
    }

    public class ServerThread
    {
        private TcpClient client;
        private NetworkStream streamToClient;
        private const int BufferSize = 8192;
        private byte[] buffer;
        private RequestHandler handler;
        public ServerThread(TcpClient client)
        {
            this.client = client;
            // 打印连接到的客户端信息
            Console.WriteLine("\nClient Connected! Local:{0} <-- Client:{1}",
            client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            // 获得流
            streamToClient = client.GetStream();
            buffer = new byte[BufferSize];
            // 设置RequestHandler
            handler = new RequestHandler();
            // 在构造函数中就开始准备读取
            AsyncCallback callBack = new AsyncCallback(ReadComplete);
            streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
        }

        // 在读取完成时进行回调
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = streamToClient.EndRead(ar);
                if (bytesRead == 0)
                {
                    Console.WriteLine("Client offline"); return;
                }
                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Array.Clear(buffer, 0, buffer.Length); // 清空缓存，避免脏读
                string[] msgArray = handler.GetActualString(msg); // 获取实际的字符串
                                                                  // 遍历获得到的字符串
                foreach (string m in msgArray)
                {
                    Console.WriteLine("Received: {0} [{1} bytes]", m, bytesRead);
                    string back = m.ToUpper();
                    // 将得到的字符串改为大写并重新发送
                    byte[] temp = Encoding.Unicode.GetBytes(back);
                    streamToClient.Write(temp, 0, temp.Length);
                    streamToClient.Flush();
                    Console.WriteLine("Sent: {0}", back);
                }
                // 再次调用BeginRead()，完成时调用自身，形成无限循环
                AsyncCallback callBack = new AsyncCallback(ReadComplete);
                streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
            }
            catch (Exception ex)
            {
                if (streamToClient != null)
                    streamToClient.Dispose();
                client.Close();
                Console.WriteLine(ex.Message); // 捕获异常时退出程序
            }
        }
    }


    public class RequestHandler
    {
        private string temp = string.Empty;

        public string[] GetActualString(string input)
        {
            return GetActualString(input, null);
        }

        private string[] GetActualString(string input, List<string> outputList)
        {
            if (outputList == null)
                outputList = new List<string>();

            if (!String.IsNullOrEmpty(temp))
                input = temp + input;

            string output = "";
            string pattern = @"(?<=^\[length=)(\d+)(?=\])";
            int length;

            if (Regex.IsMatch(input, pattern))
            {

                Match m = Regex.Match(input, pattern);

                // 获取消息字符串实际应有的长度
                length = Convert.ToInt32(m.Groups[0].Value);

                // 获取需要进行截取的位置
                int startIndex = input.IndexOf(']') + 1;

                // 获取从此位置开始后所有字符的长度
                output = input.Substring(startIndex);

                if (output.Length == length)
                {
                    // 如果output的长度与消息字符串的应有长度相等
                    // 说明刚好是完整的一条信息
                    outputList.Add(output);
                    temp = "";
                }
                else if (output.Length < length)
                {
                    // 如果之后的长度小于应有的长度，
                    // 说明没有发完整，则应将整条信息，包括元数据，全部缓存
                    // 与下一条数据合并起来再进行处理
                    temp = input;
                    // 此时程序应该退出，因为需要等待下一条数据到来才能继续处理

                }
                else if (output.Length > length)
                {
                    // 如果之后的长度大于应有的长度，
                    // 说明消息发完整了，但是有多余的数据
                    // 多余的数据可能是截断消息，也可能是多条完整消息

                    // 截取字符串
                    output = output.Substring(0, length);
                    outputList.Add(output);
                    temp = "";

                    // 缩短input的长度
                    input = input.Substring(startIndex + length);

                    // 递归调用
                    GetActualString(input, outputList);
                }
            }
            else
            {    // 说明“[”，“]”就不完整
                temp = input;
            }

            return outputList.ToArray();
        }
    }
}
