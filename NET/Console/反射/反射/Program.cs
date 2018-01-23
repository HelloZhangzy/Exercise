using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {

            //Type t = Type.GetType("System.IO.Stream");
            //Console.WriteLine(t.ToString());
            ////与上代码等效
            //t = typeof(System.IO.Stream);
            //Console.WriteLine(t.ToString());

            //string name = "Asp.Net MVC4";
            //t = name.GetType();
            //Console.WriteLine(t.ToString()+":"+t.GetType()); 

            //使用无参构造函数创建对象  
            Assembly asm = Assembly.GetExecutingAssembly();//获取当前代码所在程序集  
            Object obj = asm.CreateInstance("反射.TestClass", true);//创建一个对象TestClass对象
                                                                            //打印：这是一个无参构造函数  

            ObjectHandle handler = Activator.CreateInstance(null, "反射.TestClass");
            //CreateInstance 第一个参数为程序集名称，为null 表示当前程序集，第二个参数表示要创建的类型  
            Object obj1 = handler.Unwrap();
            //打印：这是一个无参构造函数  


            //使用有参构造函数创建对象              
            Object[] param = new Object[2];
            param[0] = 1;
            param[1] = 2;
            Assembly asm2 = Assembly.GetExecutingAssembly();
            Object obj2 = asm2.CreateInstance("反射.TestClass2", true, BindingFlags.Default, null, param, null, null);
            if (obj2==null)
            {
                Console.WriteLine("Null");
            }
            //BindingFlag是限定对类型成员的搜索，这里Default不使用BindingFlags策略  


            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("这是一个无参构造函数");
        }
        public TestClass(int a, int b)
        {
            Console.WriteLine("这是一个有参数构造函数 > a+b=" + (a + b));
        }

        public int show()
        {
            return 1;
        }

        public static int show(int a, int b)
        {
            return a + b;
        }
    }
}
