using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestThreadPool ttp = new TestThreadPool();
            ttp.ThreadPoolTest();
            Console.ReadKey();
        }
    }

    class TestThreadPool
    {
        public void ThreadPoolTest()
        {
            int maxThread, IOMaxThread;
            ThreadPool.GetMaxThreads(out maxThread,out IOMaxThread);
            Console.WriteLine("Work thread max count=" + maxThread
                    + ",IO thread max count=" + IOMaxThread);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("this is thread pool thread my ID " + Thread.CurrentThread.ManagedThreadId);
                });
            }
        }
    }
}
