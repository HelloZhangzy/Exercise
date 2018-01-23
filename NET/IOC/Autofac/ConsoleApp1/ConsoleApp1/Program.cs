using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("使用RegisterType进行注册======>");
            
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClass>();
            IContainer container = builder.Build();
            var myClass = container.Resolve<MyClass>();


            
            builder.Register(c => new MyClass()).As<MyInterface>();

           



            Console.ReadLine();
        }
    }


    class MyClass
    {
        private int _d = -1;
        public MyClass()
        {

            if (_d == -1)
            {
                Random rd = new Random(1000);
                _d = rd.Next();

                Console.WriteLine("Gen:{0}",_d);
            }
            else
                Console.WriteLine("Show:{0}", _d);
        }
    }
}
