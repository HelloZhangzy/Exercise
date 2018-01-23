using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件__接受多个订阅者的返回值
{
    class Program
    {
        static void Main(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            Subscriber3 sub3 = new Subscriber3();
            pub.NumberChanged += new DemoEventHandler(sub1.OnNumberChanged);
            pub.NumberChanged += new DemoEventHandler(sub2.OnNumberChanged);
            pub.NumberChanged += new DemoEventHandler(sub3.OnNumberChanged);
            List<string> list = pub.DoSomething(); //调用方法，在方法内触发事件
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
    public delegate string DemoEventHandler(int num);
    // 定义事件发布者
    public class Publishser
    {
        public event DemoEventHandler NumberChanged; // 声明一个事件
        public List<string> DoSomething()
        {
            // 做某些其他的事
            List<string> strList = new List<string>();
            if (NumberChanged == null) return strList;
            // 获得委托数组
            Delegate[] delArray = NumberChanged.GetInvocationList();
            foreach (Delegate del in delArray)
            {
                // 进行一个向下转换
                DemoEventHandler method = (DemoEventHandler)del;
                strList.Add(method(100)); // 调用方法并获取返回值
            }
            return strList;
        }
    }
    // 定义事件订阅者
    public class Subscriber1
    {
        public string OnNumberChanged(int num)
        {
            Console.WriteLine("Subscriber1 invoked, number:{0}", num);
            return "[Subscriber1 returned]";
        }
    }
    public class Subscriber2
    {
        public string OnNumberChanged(int num)
        {
            Console.WriteLine("Subscriber2 invoked, number:{0}", num);
            return "[Subscriber2 returned]";
        }
    }
    public class Subscriber3
    {
        public string OnNumberChanged(int num)
        {
            Console.WriteLine("Subscriber3 invoked, number:{0}", num);
            return "[Subscriber3 returned]";
        }
    }
}
