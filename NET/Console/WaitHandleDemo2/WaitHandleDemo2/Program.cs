using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandleDemo2
{
    class Program
    {


        static void Main(string[] args)
        {


        }

        /// <summary>
        /// C#互斥量使用示例代码
        /// </summary>
        /// <remarks>已在经过测试并上线运行，可直接使用</remarks>
        public static class MutexExample
        {
            /// <summary>
            /// 进程间同步执行的简单例子
            /// </summary>
            /// <param name="action">同步处理代码</param>
            /// <param name="mutexKey">操作系统级的同步键
            /// (如果将 name 指定为 null 或空字符串，则创建一个局部互斥体。 
            /// 如果名称以前缀“Global\”开头，则 mutex 在所有终端服务器会话中均为可见。 
            /// 如果名称以前缀“Local\”开头，则 mutex 仅在创建它的终端服务器会话中可见。 
            /// 如果创建已命名 mutex 时不指定前缀，则它将采用前缀“Local\”。)</param>
            /// <remarks>不重试且不考虑异常情况处理的简单例子</remarks>
            [Obsolete(error: false, message: "请使用MutexExec")]
            public static void MutexExecEasy(string mutexKey, Action action)
            {
                //声明一个已命名的互斥体，实现进程间同步；该命名互斥体不存在则自动创建，已存在则直接获取
                using (Mutex mut = new Mutex(false, mutexKey))
                {
                    try
                    {
                        //上锁，其他线程需等待释放锁之后才能执行处理；若其他线程已经上锁或优先上锁，则先等待其他线程执行完毕
                        mut.WaitOne();
                        //执行处理代码（在调用WaitHandle.WaitOne至WaitHandle.ReleaseMutex的时间段里，只有一个线程处理，其他线程都得等待释放锁后才能执行该代码段）
                        action();
                    }
                    finally
                    {
                        //释放锁，让其他进程(或线程)得以继续执行
                        mut.ReleaseMutex();
                    }
                }
            }


            /// <summary>
            /// 获取文件名对应的进程同步键
            /// </summary>
            /// <param name="filePath">文件路径(请注意大小写及空格)</param>
            /// <returns>进程同步键(互斥体名称)</returns>
            public static string GetFilePathMutexKey(string filePath)
            {
                //生成文件对应的同步键，可自定义格式（互斥体名称对特殊字符支持不友好，遂转换为BASE64格式字符串）
                var fileKey = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format(@"FILE\{0}", filePath)));
                //转换为操作系统级的同步键
                var mutexKey = string.Format(@"Global\{0}", fileKey);
                return mutexKey;
            }

            /// <summary>
            /// 进程间同步执行
            /// </summary>
            /// <param name="mutexKey">操作系统级的同步键
            /// (如果将 name 指定为 null 或空字符串，则创建一个局部互斥体。 
            /// 如果名称以前缀“Global\”开头，则 mutex 在所有终端服务器会话中均为可见。 
            /// 如果名称以前缀“Local\”开头，则 mutex 仅在创建它的终端服务器会话中可见。 
            /// 如果创建已命名 mutex 时不指定前缀，则它将采用前缀“Local\”。)</param>
            /// <param name="action">同步处理操作</param>
            public static void MutexExec(string mutexKey, Action action)
            {
                MutexExec(mutexKey: mutexKey, action: action, recursive: false);
            }

            /// <summary>
            /// 进程间同步执行
            /// </summary>
            /// <param name="mutexKey">操作系统级的同步键
            /// (如果将 name 指定为 null 或空字符串，则创建一个局部互斥体。 
            /// 如果名称以前缀“Global\”开头，则 mutex 在所有终端服务器会话中均为可见。 
            /// 如果名称以前缀“Local\”开头，则 mutex 仅在创建它的终端服务器会话中可见。 
            /// 如果创建已命名 mutex 时不指定前缀，则它将采用前缀“Local\”。)</param>
            /// <param name="action">同步处理操作</param>
            /// <param name="recursive">指示当前调用是否为递归处理，递归处理时检测到异常则抛出异常，避免进入无限递归</param>
            private static void MutexExec(string mutexKey, Action action, bool recursive)
            {
                //声明一个已命名的互斥体，实现进程间同步；该命名互斥体不存在则自动创建，已存在则直接获取
                //initiallyOwned: false：默认当前线程并不拥有已存在互斥体的所属权，即默认本线程并非为首次创建该命名互斥体的线程
                //注意：并发声明同名的命名互斥体时，若间隔时间过短，则可能同时声明了多个名称相同的互斥体，并且同名的多个互斥体之间并不同步，高并发用户请另行处理
                using (Mutex mut = new Mutex(initiallyOwned: false, name: mutexKey))
                {
                    try
                    {
                        //上锁，其他线程需等待释放锁之后才能执行处理；若其他线程已经上锁或优先上锁，则先等待其他线程执行完毕
                        mut.WaitOne();
                        //执行处理代码（在调用WaitHandle.WaitOne至WaitHandle.ReleaseMutex的时间段里，只有一个线程处理，其他线程都得等待释放锁后才能执行该代码段）
                        action();
                    }
                    //当其他进程已上锁且没有正常释放互斥锁时(譬如进程忽然关闭或退出)，则会抛出AbandonedMutexException异常
                    catch (AbandonedMutexException ex)
                    {
                        //避免进入无限递归
                        if (recursive)
                            throw ex;

                        //非递归调用，由其他进程抛出互斥锁解锁异常时，重试执行
                        MutexExec(mutexKey: mutexKey, action: action, recursive: true);
                    }
                    finally
                    {
                        //释放锁，让其他进程(或线程)得以继续执行
                        mut.ReleaseMutex();
                    }
                }
            }
        }
    }
}
