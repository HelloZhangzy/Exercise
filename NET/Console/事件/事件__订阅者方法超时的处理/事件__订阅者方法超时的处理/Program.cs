using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 事件__订阅者方法超时的处理
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            Subscriber3 sub3 = new Subscriber3();
            pub.MyEvent += new EventHandler(sub1.OnEvent);
            pub.MyEvent += new EventHandler(sub2.OnEvent);
            pub.MyEvent += new EventHandler(sub3.OnEvent);
            pub.DoSomething(); // 触发事件
            Console.WriteLine("Control back to client!\n"); // 返回控制权
            Console.WriteLine("Press any thing to exit...");
            Console.ReadKey(); // 暂停客户程序，提供时间供订阅者完成方法           
        }
        // 触发某个事件，以列表形式返回所有方法的返回值
    }
    public class Publisher
    {
        public event EventHandler MyEvent;
        public void DoSomething()
        {
            // 做某些其他的事情
            Console.WriteLine("DoSomething invoked!");
            if (MyEvent != null)
            {
                Delegate[] delArray = MyEvent.GetInvocationList();
                foreach (Delegate del in delArray)
                {
                    EventHandler method = (EventHandler)del;
                    method.BeginInvoke(null, EventArgs.Empty, null, null);
                }
            }
        }
    }
    public class Subscriber1
    {
        public void OnEvent(object sender, EventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3)); // 模拟耗时三秒才能完成方法
            Console.WriteLine("Waited for 3 seconds, subscriber1 invoked!");
        }
    }
    public class Subscriber2
    {
        public void OnEvent(object sender, EventArgs e)
        {
            throw new Exception("Subsciber2 Failed"); // 即使抛出异常也不会影响到客户端
                                                      //Console.WriteLine("Subscriber2 immediately Invoked!");
        }
    }
    public class Subscriber3
    {
        public void OnEvent(object sender, EventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2)); // 模拟耗时两秒才能完成方法
            Console.WriteLine("Waited for 2 seconds, subscriber3 invoked!");
        }
    }
}
