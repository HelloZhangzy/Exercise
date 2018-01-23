using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Screen screen = new Screen();
            Alarm alarm = new Alarm();
            heater.Register(screen); // 注册显示器
            heater.Register(alarm); // 注册热水器
            heater.BoilWater(); // 烧水
            heater.UnRegister(alarm); // 取消报警器的注册            
            heater.BoilWater(); // 再次烧水
            Console.WriteLine();
            Console.WriteLine("/*************推模式********************/");
            /*************推模式********************/
            Heater2 heater2 = new Heater2();
            Screen2 screen2 = new Screen2();
            heater2.Register(screen2); // 注册显示器
            heater2.BoilWater(); // 烧水
            Console.WriteLine();
            Console.WriteLine("/*************拉模式********************/");
            /*************拉模式********************/
            Heater3 heater3 = new Heater3();
            Screen3 screen3 = new Screen3();
            heater3.Register(screen3); // 注册显示器
            heater3.BoilWater(); // 烧水
            Console.ReadKey();
        }
    }

    #region 观察者
    public interface IObserver
    {
        void UPdate(int Value);
    }

    public interface IObservale
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);       
    }

    public class SubjectBase : IObservale
    {
        List<IObserver> container = new List<IObserver>();   

        public void UnRegister(IObserver observer)
        {
            container.Remove(observer);
        }

        public void Register(IObserver observer)
        {
            container.Add(observer);
        }
        protected void Notify(int Value)
        {
            foreach (var item in container)
            {
                item.UPdate(Value);
            }
        }
    }

    public class Heater : SubjectBase
    {
        private string type; // 添加型号作为演示
        private string area; // 添加产地作为演示
        private int temprature; // 水温
        public Heater(string type, string area)
        {
            this.type = type;
            this.area = area;
            temprature = 0;
        }
        public string Type { get { return type; } }
        public string Area { get { return Area; } }
        public Heater() : this("RealFire 001", "China Xi'an") { }
        // 供子类覆盖，以便子类拒绝被通知，或添加额外行为
        protected virtual void OnBoiled(int value)
        {
            base.Notify(value);// 调用父类Notify()方法，进而调用所有注册了Observer的Update()方法
        }
        public void BoilWater()
        { // 烧水
            for (int i = 0; i <= 99; i++)
            {
                temprature = i + 1;
                if (temprature > 97)
                { 
                    // 当水快烧开时(温度>97度)，通知Observer
                    OnBoiled(temprature);
                }
            }
        }
    }
    
    // 显示器
    public class Screen : IObserver
    {
        // Subject在事件发生时调用，通知Observer更新状态(通过Notify()方法)
        public void UPdate(int Value)
        {
            Console.WriteLine("Screen".PadRight(7) + ": 水快烧开了。");
        }
    }
  
    // 报警器
    public class Alarm : IObserver
    {
        public void UPdate(int Value)
        {
            Console.WriteLine("Alarm".PadRight(7) + "：嘟嘟嘟，水温快烧开了。");
        }
    }
    #endregion

    #region 推模式
    /***************推模式******************/
    public interface IObserver2
    {
        // 推模式的实现方式，接收一个BoiledEventArgs
        void Update(BoiledEventArgs e);
    }

    public interface IObservale2
    {
        void Register(IObserver2 observer);
        void UnRegister(IObserver2 observer);
    }

    public class BoiledEventArgs
    {
        private int temperature; // 温度

        private string type; // 类型

        private string area; // 产地

        public BoiledEventArgs(int temperature, string type, string area)
        {
            this.temperature = temperature;
            this.type = type;
            this.area = area;
        }
        public int Temperature { get { return temperature; } }

        public string Type { get { return type; } }

        public string Area { get { return area; } }

    }

    public class Screen2 : IObserver2
    {
        private bool isDisplayedType = false; // 标记变量，标示是否已经打印过
        public void Update(BoiledEventArgs e)
        {
            // 打印产地和型号，只打印一次
            if (!isDisplayedType)
            {
                Console.WriteLine("{0} - {1}: ", e.Area, e.Type);
                Console.WriteLine();
                isDisplayedType = true;
            }
            if (e.Temperature < 100)
            {
                Console.WriteLine(
                String.Format("Alarm".PadRight(7) + "：水快烧开了，当前温度：{0}。",
                e.Temperature));
            }
            else
            {
                Console.WriteLine(
                String.Format("Alarm".PadRight(7) + "：水已经烧开了！！"));
            }
        }
    }    

    public abstract class SubjectBase2 : IObservale2
    {
        List<IObserver2> container = new List<IObserver2>();

        public void UnRegister(IObserver2 observer)
        {
            container.Remove(observer);
        }

        public void Register(IObserver2 observer)
        {
            container.Add(observer);
        }

        protected virtual void Notify(BoiledEventArgs e)
        { // 通知所有注册了的Observer
            foreach (IObserver2 observer in container)
            {
                observer.Update(e); // 调用Observer的Update()方法
            }
        }
    }

    public class Heater2 : SubjectBase2
    {
        private string type; // 添加型号作为演示
        private string area; // 添加产地作为演示
        private int temprature; // 水温
        public Heater2(string type, string area)
        {
            this.type = type;
            this.area = area;
            temprature = 0;
        }
        public string Type { get { return type; } }
        public string Area { get { return Area; } }
        public Heater2() : this("RealFire 001", "China Xi'an") { }
        // 供子类覆盖，以便子类拒绝被通知，或者添加额外行为
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            base.Notify(e); // 调用基类方法，通知Observer
        }
        public void BoilWater()
        { // 烧水
            for (int i = 0; i <= 99; i++)
            {
                temprature = i + 1;
                if (temprature > 97)
                { // 当水快烧开时(温度>97度)，通知Observer
                    BoiledEventArgs e = new BoiledEventArgs(temprature, type, area);
                    OnBoiled(e);
                }
            }
        }
    }

    #endregion

    #region 拉模式
    /***************拉模式******************/
    public interface IObserver3
    {
        // 推模式的实现方式，接收一个BoiledEventArgs
        void Update(IObservale3 e);
    }

    public interface IObservale3
    {
        void Register(IObserver3 observer);
        void UnRegister(IObserver3 observer);
    }
        

    public class Screen3 : IObserver3
    {
        private bool isDisplayedType = false; // 标记变量，标示是否已经打印过
        public void Update(IObservale3 obj)
        {
            // 这里存在一个向下转换(由继承体系中高级别的类向低级别的类转换)
            Heater3 heater = (Heater3)obj;
            // 打印产地和型号，只打印一次
            if (!isDisplayedType)
            {
                Console.WriteLine("{0} - {1}: ", heater.Area, heater.Type);
                Console.WriteLine();
                isDisplayedType = true;
            }
            if (heater.Temperature < 100)
            { // 通过热水器引用heater获取温度
                Console.WriteLine(
                String.Format("Alarm".PadRight(7) + "：水快烧开了，当前温度：{0}。",
                heater.Temperature));
            }
            else
            {
                Console.WriteLine(
                String.Format("Alarm".PadRight(7) + "：水已经烧开了！！"));
            }
        }
    }

    public abstract class SubjectBase3 : IObservale3
    {
        List<IObserver3> container = new List<IObserver3>();

        public void UnRegister(IObserver3 observer)
        {
            container.Remove(observer);
        }

        public void Register(IObserver3 observer)
        {
            container.Add(observer);
        }

        protected virtual void Notify(IObservale3 obj)
        { // 通知所有注册了的Observer
            foreach (IObserver3 observer in container)
            {
                observer.Update(obj); // 调用Observer的Update()方法
            }
        }             
    }

    public class Heater3 : SubjectBase3
    {
        private string type; // 添加型号作为演示
        private string area; // 添加产地作为演示
        private int temprature; // 水温

        public int Temperature { get { return temprature; } }

        public Heater3(string type, string area)
        {
            this.type = type;
            this.area = area;
            temprature = 0;
        }
        public string Type { get { return type; } }
        public string Area { get { return area; } }
        public Heater3() : this("RealFire 001", "China Xi'an") { }
        // 供子类覆盖，以便子类拒绝被通知，或者添加额外行为
        protected virtual void OnBoiled()
        {
            base.Notify(this); // 调用基类方法，通知Observer
        }
        public void BoilWater()
        { // 烧水
            for (int i = 0; i <= 99; i++)
            {
                temprature = i + 1;
                if (temprature > 97)
                {                    
                    OnBoiled();
                }
            }
        }
    }

    #endregion
}

