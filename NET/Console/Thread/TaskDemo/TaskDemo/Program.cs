using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTask tt = new TestTask();
            tt.test();
            Console.WriteLine("Task Test End");
            Console.WriteLine("-------------------------------------");
            //Console.ReadKey();

            TestTaskContinue ttc = new TestTaskContinue();
            ttc.Test();
            Console.ReadKey();
        }
    }

    class TestTask
    {
        public void test()
        {
            Action<object> action = (object obj) =>
              {
                  Console.WriteLine("Task={0},obj={1},Thread={2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
              };
            Task t1 = new Task(action, "alpha");
            Task t2 = Task.Factory.StartNew(action, "beta");
            t2.Wait();
            t1.Start();
            Console.WriteLine("t1 has been launched.(Main Thread={0})",Thread.CurrentThread.ManagedThreadId);
            t1.Wait();
            string taskData = "delta";
            Task t3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task={0},obj={1},Thread={2}", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            });
            t3.Wait();            
            Task t4 = new Task(action, "gamma");
            t4.RunSynchronously();
            t4.Wait();

        }
    }


    class TestTaskContinue
    {
        public void Test()
        {
            Task t = Task.Factory.StartNew(() =>
             {
                 Console.WriteLine("Task A start id={0},TaskID={1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                 Thread.Sleep(500);
                 Console.WriteLine("task A execute over id=" + Thread.CurrentThread.ManagedThreadId);
             });
            var t1 = t.ContinueWith(x =>
              {
                  Console.WriteLine("Task t1 start id={0},TaskID={1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                  Thread.Sleep(500);
                  Console.WriteLine("task t1 execute over id=" + Thread.CurrentThread.ManagedThreadId);
              });
            var t2 = t.ContinueWith(x =>
            {
                Console.WriteLine("Task t2 start id={0},TaskID={1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(500);
                Console.WriteLine("task t2 execute over id=" + Thread.CurrentThread.ManagedThreadId);
            });
            var t3 = t1.ContinueWith(x =>
            {
                Console.WriteLine("Task t3 start id={0},TaskID={1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(500);
                Console.WriteLine("task t3 execute over id=" + Thread.CurrentThread.ManagedThreadId);
            });
            var t4 = t3.ContinueWith(x =>
            {
                Console.WriteLine("Task t4 start id={0},TaskID={1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(500);
                Console.WriteLine("task t4 execute over id=" + Thread.CurrentThread.ManagedThreadId);
            });
        }
    }
}
