using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 强名称程序集及签名
{
    class Program
    {
        static void Main(string[] args)
        {
            string Key = "895647821544584";
            string msDESKey = Convert.ToInt64(Key.Trim()).ToString("X16");
            Console.WriteLine(msDESKey);

            Console.WriteLine(MyClass.MyClass.Add(1, 2).ToString());
            Console.WriteLine(MyClass.MyClass.GetKey());
            Console.ReadKey();            
        }        
    }
}
