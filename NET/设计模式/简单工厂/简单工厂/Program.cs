using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    public class namer
    {
        protected string frName, Lname;

        public string GetFrName()
        {
            return frName;
        }
        public string GetlName()
        {
            return Lname;
        }
    }

    public class FirstFirst : namer
    {
        public FirstFirst(string name)
        {
            int i = name.Trim().IndexOf(" ");
            if (i>0)
            {
                frName = name.Trim().Substring(0, i).Trim();
                Lname = name.Trim().Substring(i + 1).Trim();
            }
            else
            {
                frName = name.Trim();
                Lname = "";
            }
        }
    }

    public class LastFrist : namer
    {
        public LastFrist(string name)
        {
            int i = name.Trim().IndexOf(",");
            if (i > 0)
            {
                frName = name.Trim().Substring(0, i).Trim();
                Lname = name.Trim().Substring(i + 1).Trim();
            }
            else
            {
                frName = name.Trim();
                Lname = "";
            }
        }
    }

    public class NameFactory
    {
        public NameFactory()
        { }
        public namer getName(string name)
        {
            int i = name.IndexOf(",");
            if (i>0)
            {
                return new LastFrist(name);
            }
            else
            {
                return new FirstFirst(name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NameFactory nf = new NameFactory();
            Console.WriteLine(nf.getName("张三 李四").GetType().ToString());
            Console.WriteLine(nf.getName("张三 李四").GetFrName());         
            Console.WriteLine(nf.getName("张三 李四").GetlName());
            Console.WriteLine("==============================");
            Console.WriteLine(nf.getName("王五,赵六").GetType().ToString());
            Console.WriteLine(nf.getName("王五,赵六").GetFrName());
            Console.WriteLine(nf.getName("王五,赵六").GetlName());
            Console.ReadKey();


        }        
    }
}
