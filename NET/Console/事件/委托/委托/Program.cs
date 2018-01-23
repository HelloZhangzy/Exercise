using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    //定义委托，它定义了可以代表的方法的类型
    public delegate void GreetingDelegate(string name);
    class Program
    {

        
        static void Main(string[] args)
        {
            GreetPeople("Jimmy Zhang", EnglishGreeting);
            GreetPeople("张子阳", ChineseGreeting);
            Console.WriteLine("--------------------------------");

            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting; // 先向委托类型的变量赋值
            delegate1 += ChineseGreeting; // 向此委托变量再绑定一个方法
                                          // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            GreetPeople("Jimmy Zhang", delegate1);
            Console.WriteLine("--------------------------------");
            //GreetingDelegate delegate1;
            //delegate1 = EnglishGreeting; // 先向委托类型的变量赋值
            //delegate1 += ChineseGreeting; // 向此委托变量再绑定一个方法
            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            delegate1("Jimmy Zhang");

            Console.WriteLine("--------------------------------");
            GreetingDelegate delegate2 = new GreetingDelegate(EnglishGreeting);
           // delegate2 += EnglishGreeting; //这次用的是“+=”绑定语法
            delegate2 += ChineseGreeting; //向此委托变量再绑定一个方法
            GreetPeople("Jimmy Zhang", delegate1);
            Console.WriteLine();
            delegate1 -= EnglishGreeting; // 取消对EnglishGreeting方法的绑定
                                          // 将仅调用 ChineseGreeting
            GreetPeople("张子阳", delegate1);
            Console.WriteLine("---------------接口-----------------");
            GreetPeople("Jimmy Zhang", new EnglishGreeting());
            GreetPeople("张子阳", new ChineseGreeting());
            Console.ReadKey();
        }
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
        //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        private static void GreetPeople(string name, IGreeting makeGreeting)
        {
            makeGreeting.GreetingPeople(name);
        }
    }

    public interface IGreeting
    {
        void GreetingPeople(string name);
    }
    public class EnglishGreeting : IGreeting
    {
        public void GreetingPeople(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
    }
    public class ChineseGreeting : IGreeting
    {
        public void GreetingPeople(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }
}
