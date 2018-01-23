using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 限制事件订阅
{
    class Program
    {
        static void Main(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            pub.NumberChanged -= sub1.OnNumberChanged; // 不会有任何反应
            pub.NumberChanged += sub2.OnNumberChanged; // 注册了sub2
            pub.NumberChanged += sub1.OnNumberChanged; // sub1将sub2覆盖掉了
            pub.DoSomething(); // 触发事件
            Console.ReadKey();
        }
    }

    // 定义委托
    public delegate string GeneralEventHandler();
    // 定义事件发布者
    public class Publishser
    {
        // 声明一个委托变量
        private GeneralEventHandler numberChanged;
        // 事件访问器的定义
        public event GeneralEventHandler NumberChanged
        {
            add
            {
                numberChanged = value;
            }
            remove
            {
                numberChanged -= value;
            }
        }
        public void DoSomething()
        {
            // 做某些其他的事情
            if (numberChanged != null)
            { // 通过委托变量触发事件
                string rtn = numberChanged();
                Console.WriteLine("Return: {0}", rtn); // 打印返回的字符串
            }
        }
    }
    // 定义事件订阅者
    public class Subscriber1
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber1 Invoked!");
            return "Subscriber1";
        }
    }
    public class Subscriber2
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber2 Invoked!");
            return "Subscriber2";
        }
    }
    public class Subscriber3
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber3 Invoked!");
            return "Subscriber3";
        }
    }
}
