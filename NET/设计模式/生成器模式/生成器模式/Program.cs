using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生成器模式
{
    //生成器模式或注入
    interface ICarBuilder
    {
        void BuilderWheels();
        void BuilderWindows();
    }

    public class BasicBuilder:ICarBuilder
    {
        public void BuilderWheels()
        {
            Console.WriteLine("Builder Basic Wheels");
        }

        public void BuilderWindows()
        {
            Console.WriteLine("Builder Basic Windows");
        }
    }
    public class AdvancedBuilder : ICarBuilder
    {
        public void BuilderWheels()
        {
            Console.WriteLine("Builder Advanced Wheels");
        }

        public void BuilderWindows()
        {
            Console.WriteLine("Builder Advanced Wheels");
        }
    }

    class CarFactory
    {
        public ICarBuilder Builder { get; set; }
        public CarFactory(ICarBuilder builder)
        {
            Builder = builder;
        }

        public void CreateCar()
        {
            Builder.BuilderWheels();
            Builder.BuilderWindows();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarFactory game = new CarFactory(new BasicBuilder());
            game.CreateCar();
            game.Builder = new AdvancedBuilder();
            game.CreateCar();
            Console.ReadKey();
        }
    }
}
