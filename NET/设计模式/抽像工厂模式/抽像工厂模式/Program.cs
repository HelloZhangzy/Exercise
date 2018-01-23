using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽像工厂模式
{
    public abstract class CarFactory
    {
        public abstract void CreateWindows();
        public abstract void CreateWheels();
    }
    public class BenzFactory:CarFactory
    {
        public override void CreateWheels()
        {
            Console.WriteLine("Create Benz Wheels");            
        }
        public override void CreateWindows()
        {
            Console.WriteLine("Create Benz Windows");
        }
    }

    public class BMWFactory:CarFactory
    {
        public override void CreateWindows()
        {
            Console.WriteLine("Create BMW Windows");
        }

        public override void CreateWheels()
        {
            Console.WriteLine("Create BMW Wheels");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory carFactory = new BenzFactory();
            carFactory.CreateWindows();
            carFactory.CreateWheels();

            carFactory = new BMWFactory();
            carFactory.CreateWindows();
            carFactory.CreateWheels();

            Console.ReadKey();
        }
    }
}
