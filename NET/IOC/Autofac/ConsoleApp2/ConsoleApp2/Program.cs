using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Test>();
           // builder.Register(t => new Test()).As<Test>();
            builder.RegisterType<Test2>();
            var container = builder.Build();

            Test test1 = container.Resolve<Test>();
            Test2 test2 = container.Resolve<Test2>(new NamedParameter);
            test2.Show();
            Console.ReadKey();
        }
    }

    class Test
    {
        public void Show()
        {
            Console.WriteLine("Test1 Show");
        }
    }

    class Test2
    {
        public Test te { get; set; }

        public Test2(Test t)
        {
            this.te = t;
        }

        public void Show()
        {
            Console.Write("Test2 Show==>");
            if (te != null) te.Show();
            else
                Console.WriteLine("Null");
        }

    }
}
