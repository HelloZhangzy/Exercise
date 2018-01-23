using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件异常处理
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
            pub.DoSomething();
            Console.ReadKey();
        }

        public class Publisher
        {
            public event EventHandler MyEvent;
            public void DoSomething()
            {
                //if (MyEvent != null)
                //{
                //    //获取订阅者列表
                //    Delegate[] delArray = MyEvent.GetInvocationList();
                //    foreach (Delegate del in delArray)
                //    {
                //        EventHandler method = (EventHandler)del; // 强制转换为具体的委托类型
                //        try
                //        {
                //            method(this, EventArgs.Empty);
                //        }
                //        catch (Exception e)
                //        {
                //            Console.WriteLine("Exception: {0}", e.Message);
                //        }
                //    }
                //}

                //以上代码可以使用下面的方法代替
                if (MyEvent != null)
                {
                    Delegate[] delArray = MyEvent.GetInvocationList();
                    foreach (Delegate del in delArray)
                    {
                        try
                        {
                            // 使用DynamicInvoke方法触发事件
                            del.DynamicInvoke(this, EventArgs.Empty);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: {0}", e.Message);
                        }
                    }
                }

                //下面代码一旦有异常发生，会影响其他订阅者的代码不被执行
                // 做某些其他的事情
                //if (MyEvent != null)
                //{
                //    try
                //    {
                //        MyEvent(this, EventArgs.Empty);
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine("Exception: {0}", e.Message);
                //    }
                //}
            }
        }
        public class Subscriber1
        {
            public void OnEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Subscriber1 Invoked!");
            }
        }
        public class Subscriber2
        {
            public void OnEvent(object sender, EventArgs e)
            {
                throw new Exception("Subscriber2 Failed");
            }
        }
        public class Subscriber3
        {
            public void OnEvent(object sender, EventArgs e)
            {
                Console.WriteLine("Subscriber3 Invoked!");
            }
        }
    }
}