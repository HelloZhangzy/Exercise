using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace 简单线程
{
    class Program
    {
        static void Main(string[] args)
        {
            TestThread tth = new TestThread();
            tth.CreateThread();
            Console.ReadKey();
            return;                

            TestThreadTimer ttt = new TestThreadTimer();
            ttt.test();

            Console.ReadKey();
            return;

            //System.Timers.Timer 
            TestTimer tt = new TestTimer();
            tt.test();

            //BeginInvoke，创建一个委托
            testDelgate t = new testDelgate();
            t.testDo();
            Thread.Sleep(2000);
            t.SetD(122);
            Console.ReadKey();

        }
    }

    class testDelgate
    {
        public static int d = 1234545;
        delegate void DoXXOO();
        DoXXOO doxxoo = new DoXXOO(() =>
          {
              for (int i = 0; i < 10; i++)
              {
                  Thread.Sleep(1000);

                  Console.WriteLine("do over ThreadID=" + Thread.CurrentThread.ManagedThreadId.ToString() + " d=>" + d.ToString());
              }

          });

        public void testDo()
        {
            Console.WriteLine("Main thread ThreadID=" + Thread.CurrentThread.ManagedThreadId.ToString());
            doxxoo.BeginInvoke(null, null);
            Console.WriteLine("Main Over");
        }
        public void SetD(int v)
        {
            d = v;
        }
    }

    class TestTimer
    {
        private System.Timers.Timer aTimer;
        public void test()
        {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
            Console.WriteLine("start....");
            Console.ReadKey();
            aTimer.Enabled = false;
            GC.KeepAlive(aTimer);
            Console.WriteLine("over...");


        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("TheElapsed event was raised at{0}", e.SignalTime);
        }
    }

    class TestThreadTimer
    {
        public void test()
        {
            AutoResetEvent autorest = new AutoResetEvent(false);
            int invokeCount = 0;
            var t = new System.Threading.Timer((x) =>
              {
                  //AutoResetEvent autoWait = (AutoResetEvent)x;
                  Console.WriteLine("{0} count{1,2}.", DateTime.Now.ToString("h:mm:ss.fff"), (++invokeCount).ToString());
                  if (invokeCount % 10 == 0)
                  {
                      autorest.Set();
                  }
              }, autorest, 500, 500);
                autorest.WaitOne();
                Console.WriteLine("change");
                t.Change(1000, 1000);
                autorest.WaitOne();
                t.Dispose();
                Console.WriteLine("Over");             
        }
    }

    class TestThread
    {
        Thread t1 = null;
        Thread t2 = null;
        public void CreateThread()
        {
            Console.WriteLine("Start Thread");
            //无参方式
            t1 = new Thread(new ThreadStart(
                () =>{
                        Console.WriteLine("i an thread one id " + Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                        Console.WriteLine("i an thread one over");
                    }
                ));
            t1.IsBackground = true;
            //有参方式
            t2 = new Thread(new ParameterizedThreadStart((x) =>
            {
                Console.WriteLine("i am thread two id " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("i am two "+x.ToString());
                Thread.Sleep(1000);
                Console.WriteLine("i an thread two over");
            }));
            t1.Start();
            t2.Start(8888);
        }
    }

}

