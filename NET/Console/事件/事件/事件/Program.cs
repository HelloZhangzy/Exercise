using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber sub = new Subscriber();
            pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
            pub.DoSomething(); // 应该通过DoSomething()来触发事件            
            //pub.NumberChanged(100); //@1 也可以被这样直接调用，对委托变量的不恰当使用
            Console.WriteLine("----------------烧水-------------------");
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            //heater.BoilEvent += alarm.MakeAlert; //注册方法
            //heater.BoilEvent += (new Alarm()).MakeAlert; //为匿名对象注册方法
            heater.BoilEvent += Display.ShowMsg; //注册静态方法
            heater.BoilWater();//烧水，会自动调用注册过对象的方法
            Console.ReadKey();
        }
    }
    // 定义委托
    public delegate void NumberChangedEventHandler(int count);
    // 定义事件发布者
    public class Publishser
    {
        private int count;
        //public NumberChangedEventHandler NumberChanged; // 声明委托变量,使用该代码@1处代码编译通过
        public event NumberChangedEventHandler NumberChanged; // 声明一个事件,使用该代码@1处代码编译不通过，原因为事件委托触发需要由事件发布者触发，而委托则无该限制
        public void DoSomething()
        {
            // 在这里完成一些工作 ...
            if (NumberChanged != null)
            { // 触发事件
                count++;
                NumberChanged(count);
            }
        }
    }
    // 定义事件订阅者
    public class Subscriber
    {
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified: count = {0}", count);
        }
    }

    // 热水器
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int param); //声明委托
        public event BoilHandler BoilEvent; //声明事件
                                            // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvent != null)
                    { //如果有对象注册
                        BoilEvent(temperature); //调用所有注册对象的方法
                    }
                }
            }
        }
    }
    // 警报器
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }
    }
    // 显示器
    public class Display
    {
        public static void ShowMsg(int param)
        { //静态方法
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
            Thread.Sleep(2000);
            Console.WriteLine("{0}End", param);
        }
    }
}

