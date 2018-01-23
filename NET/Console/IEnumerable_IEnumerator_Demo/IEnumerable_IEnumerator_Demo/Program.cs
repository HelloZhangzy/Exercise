using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace IEnumerable_IEnumerator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Fun with IEnumberable/IEnumerator************\n");
            Garage carLot = new Garage();

            //交出集合中的每一Car对象吗  
            foreach (Car c in carLot)  //之所以遍历carLot，是因为carLot.GetEnumerator()返回的项时Car类型，这个十分重要  
            {
                Console.WriteLine("{0} is going {1} MPH", c.CarName, c.CurrentSpeed);
            }

            Console.WriteLine("GetEnumerator被定义为公开的，对象用户可以与IEnumerator类型交互，下面的结果与上面是一致的");
            //手动与IEnumerator协作  
            IEnumerator i = carLot.GetEnumerator();
            while (i.MoveNext())
            {
                Car myCar = (Car)i.Current;
                Console.WriteLine("{0} is going {1} MPH", myCar.CarName, myCar.CurrentSpeed);
            }
            Console.WriteLine("回车继续");
            Console.ReadLine();

            // ForeachTest f = new ForeachTest("This is a sample sentence.", new char[] { ' ', '-' });  
            string[] s = new string[] { "This", "is", "a", "sample", "sentence." };
            ForeachTest f = new ForeachTest("This,is,a,sample,sentence.");
            foreach (string item in f)
            {
                System.Console.WriteLine(item);
            }
            Console.WriteLine("回车继续");
            Console.ReadLine();

            //创建一个新的列表框并初始化  
            ListBoxTest lbt = new ListBoxTest("Hello", "World");

            //添加新的字符串  
            lbt.Add("Who");
            lbt.Add("Is");
            lbt.Add("Douglas");
            lbt.Add("Adams");

            //测试访问  
            string subst = "Universe";
            lbt[1] = subst;

            //访问所有的字符串  
            foreach (string ss in lbt)
            {
                Console.WriteLine("Value:{0}", ss);
            }  
            Console.ReadLine();
        }
    }

    public class Car
    {
        public string CarName { set; get; }
        public int CurrentSpeed { set; get; }

        public Car(string name, int age)
        {
            CarName = name;
            CurrentSpeed = age;
        }
    }

    public class Garage : IEnumerable
    {
        Car[] carArray = new Car[4];

        //启动时填充一些Car对象  
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 50);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 45);
        }
        public IEnumerator GetEnumerator()
        {
            return this.carArray.GetEnumerator();
        }
    }

    //修改Garage类型之后，就可以在C#foreach结构中安全使用该类型了。  


    class ForeachTest : IEnumerable
    {
        private string[] elements;  //装载字符串的数组  
        private int ctr = 0;  //数组的下标计数器  

        /// <summary>
        /// 初始化的字符串  
        /// </summary>  
        /// <param name="initialStrings"></param>  
        ForeachTest(params string[] initialStrings)
        {
            //为字符串分配内存空间  
            elements = new String[8];
            //复制传递给构造方法的字符串  
            foreach (string s in initialStrings)
            {
                elements[ctr++] = s;
            }
        }

        /// <summary>  
        ///  构造函数  
        /// </summary>  
        /// <param name="source">初始化的字符串</param>  
        /// <param name="delimiters">分隔符，可以是一个或多个字符分隔</param>  
        public ForeachTest(string initialStrings)
        {
            elements = initialStrings.Split(',');
        }

        //实现接口中得方法  
        public IEnumerator GetEnumerator()
        {
            return new ForeachTestEnumerator(this);
        }

        private class ForeachTestEnumerator : IEnumerator
        {
            private int position = -1;
            private ForeachTest t;
            public ForeachTestEnumerator(ForeachTest t)
            {
                this.t = t;
            }

            #region 实现接口

            public object Current
            {
                get
                {
                    return t.elements[position];
                }
            }

            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            #endregion
        }
    }


    public class ListBoxTest : IEnumerable<String>
    {
        private string[] strings;
        private int ctr = 0;

        #region IEnumerable<string> 成员
        //可枚举的类可以返回枚举  
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string s in strings)
            {
                yield return s;
            }
        }

        #endregion

        #region IEnumerable 成员
        //显式实现接口  
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        //用字符串初始化列表框  
        public ListBoxTest(params string[] initialStrings)
        {
            //为字符串分配内存空间  
            strings = new String[8];
            //复制传递给构造方法的字符串  
            foreach (string s in initialStrings)
            {
                strings[ctr++] = s;
            }
        }

        //在列表框最后添加一个字符串  
        public void Add(string theString)
        {
            strings[ctr] = theString;
            ctr++;
        }

        //允许数组式的访问  
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strings.Length)
                {
                    //处理不良索引  
                }
                return strings[index];
            }
            set
            {
                strings[index] = value;
            }
        }

        //发布拥有的字符串数  
        public int GetNumEntries()
        {
            return ctr;
        }
    }  
}
