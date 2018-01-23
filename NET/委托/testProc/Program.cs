using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testProc
{
    static class Program
    {
        //定义委托
        delegate Boolean moreOrlessDelgate(int item);
        static void Main(string[] args)
        {
            #region 委托
                //var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
                //var d1 = new moreOrlessDelgate(More);
                //Print(arr, d1);
                //Console.WriteLine("OK");

                //var d2 = new moreOrlessDelgate(Less);
                //Print(arr, d2);
                //Console.WriteLine("OK");
                //Console.ReadKey();
            #endregion

            #region 泛型
            //泛型类型List<T>、Dictionary<TKey, TValue>等
            //var intList = new List<int>() { 1, 2, 3 };
            //intList.Add(4);
            //intList.Insert(0, 5);
            //foreach (var t in intList)
            //{
            //    Console.WriteLine(t);
            //}
            //Console.ReadKey();
            #endregion
           
            #region 使用自定义泛型
                //var a1 = SomethingFactory<int>.InitInstance(12);
                //Console.WriteLine(a1);
                //var a2 = SomethingFactory<string>.InitInstance("String");
                //Console.WriteLine(a2);
                //Console.ReadKey();
            #endregion
           
            #region 委托泛型 Predicate
                //var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
                //var d1 = new Predicate<int>(More);
                //var d2 = new Predicate<int>(Less);
                //Print2(arr,d1);
                //Console.WriteLine("OK");
                //Print2(arr, d2);
                //Console.WriteLine("OK");
                //Console.ReadKey();
            #endregion

            #region Lambda表达式
                //List<int> arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
                //arr.ForEach(new Action<int>(delegate(int a) { Console.WriteLine(a); }));
                //Console.WriteLine("  ");
                //arr.ForEach(new Action<int>(a => {if (a>3)Console.WriteLine(a);}));
                //Console.ReadKey();
            #endregion

            #region 扩展方法
                ////必须是静态类才可以添加扩展方法
                ////注意调用扩展方法,必须用对象来调用 
                //    var a1 = "AAA";
                //    a1.PrintString();
                //    Console.ReadKey();
            #endregion
            
        }

        //声明扩展方法
        //扩展方法必须是静态的，Add有三个参数
        //this 必须有，string表示我要扩展的类型，stringName表示对象名
        //三个参数this和扩展的类型必不可少，对象名可以自己随意取如果需要传递参数，//再增加一个变量即可
        public static void PrintString(this String val)
        {
            Console.WriteLine(val);
        }

       //委托
        static void Print2(List<int> arr, Predicate<int> dl)
        {
            foreach (var item in arr)
            {
                if (dl(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        //委托
        static void Print(List<int> arr, moreOrlessDelgate dl)
        {
            foreach (var item in arr)
            {
                if (dl(item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        static bool More(int item)
        {
            if (item > 3)
            {
                return true;
            }
            return false;
        }

        static bool Less(int item)
        {
            if (item < 3)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 自定义泛型类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SomethingFactory<T>
    {
        public static T InitInstance(T inObj)
        {
            //if (false)//你的判断条件
            //{
            //    //do what you want...
                return inObj;
            //}
           // return default(T);//反馈对应型空值
        }
    }
}
