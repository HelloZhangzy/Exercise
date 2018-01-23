using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 事件__委托和方法的异步调用
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            AddDelegate del = new AddDelegate(cal.Add);
            IAsyncResult asyncResult = del.BeginInvoke(2, 5, null, null);// 异步调用方法
                                                                         // 做某些其他的事情，模拟需要执行3秒钟
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Client executed {1} second(s).",
                Thread.CurrentThread.Name, i);
            }
            int rtn = del.EndInvoke(asyncResult);
            Console.WriteLine("Result: {0}\n", rtn);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();            
        }
    }

    public class Calculator
    {
        public int Add(int x, int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }
            Console.WriteLine("Method invoked!");
            // 执行某些事情，模拟需要执行2秒钟
            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Add executed {1} second(s).",
                Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("Method complete!");
            return x + y;
        }
    }
}
