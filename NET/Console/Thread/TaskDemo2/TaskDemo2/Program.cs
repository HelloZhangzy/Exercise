using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
               new Task(n => DoOnSecond((string)n), "t"+i.ToString()).Start();
            }
           
            //Task t2 = t1.ContinueWith((x) => { DoOnSecond("t2"); });
            //Task t3 = t1.ContinueWith((x) => { DoOnSecond("t3"); });
            //Task t4 = t1.ContinueWith((x) => { DoOnSecond("t4"); });
            //t1.Start();
            Console.WriteLine("End");
            Console.ReadKey();
        }
        private static void DoOnSecond( string index)
        {
            Console.WriteLine("task={0},ThreadID={1} start",index,Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("task={0},ThreadID={1} end", index, Thread.CurrentThread.ManagedThreadId);

        }
        //private static Int32 Sum(Int32 i)
        //{
        //    Int32 sum = 0;
        //    for (; i > 0; i--)
        //    {
        //        Console.WriteLine("Sum :" + i);
        //       // checked { sum += i; }

        //    }
        //    return sum;
        //}
    }
}
