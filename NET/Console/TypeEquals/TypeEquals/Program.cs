using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeEquals
{

    public class RefPoint
    {  // 定义一个引用类型
        public int x;
        public RefPoint(int x)
        {
            this.x = x;
        }
    }

    public struct ValPoint
    { // 定义一个值类型
        public int x;
        public ValPoint(int x)
        {
            this.x = x;
        }
    }

    public struct ValLine
    {
        public RefPoint rPoint;  // 引用类型成员
        public ValPoint vPoint;  // 值类型成员
        public ValLine(RefPoint rPoint, ValPoint vPoint)
        {
            this.rPoint = rPoint;
            this.vPoint = vPoint;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            /*************引用类型判等****************/
            /*对于引用类型，即使类型的实例（对象）包含的值相等，如果变量指向的是不同的对象，那么也不相等。*/
            RefPoint rPoint1 = new RefPoint(1);
            RefPoint rPoint2 = rPoint1;
            result = (rPoint1 == rPoint2);  // 返回 true;
            Console.WriteLine("rPoint1 == rPoint2 => "+result);
            result = rPoint1.Equals(rPoint2);  // #2 返回 true;
            Console.WriteLine("rPoint1.Equals(rPoint2) => " + result);

            // 创建新引用类型的对象，其成员的值相等
            RefPoint rPoint4 = new RefPoint(1);
            RefPoint rPoint3 = new RefPoint(1);
            result = (rPoint3 == rPoint4);
            Console.WriteLine("rPoint3 == rPoint4 =>" + result);  // 返回 false;
            result = rPoint3.Equals(rPoint4);
            Console.WriteLine("rPoint3.Equals(rPoint4) =>" + result);  // #2 返回 false
            /*************值类型判等****************/
            // 复制结构变量
            ValPoint vPoint1 = new ValPoint(1);
            ValPoint vPoint2 = vPoint1;
            //result = (vPoint1 == vPoint2);  // 编译错误：不能在 ValPoint 上应用 "==" 操作符
            //Console.WriteLine(result);
            //ReferenceEquals判断两个对象是否在一个内存地址上。
            result = Object.ReferenceEquals(vPoint1, vPoint2); // 隐式装箱，指向了堆上的不同对象
            Console.WriteLine("ReferenceEquals(vPoint1, vPoint2) =>" + result);  // 返回 false

            //值类型Equals会先判断两个类型是否是同一类型，再逐个判断两个值类型变量对应项的值是否相关。
            result = vPoint1.Equals(vPoint2);
            Console.WriteLine("vPoint1.Equals(vPoint2) =>" + result);

            vPoint2.x = 2;
            result = vPoint1.Equals(vPoint2);  // #5 返回 true; #6 返回 false;
            Console.WriteLine("vPoint1.Equals(vPoint2) =>"+result);

            RefPoint rPoint = new RefPoint(1);
            ValPoint vPoint = new ValPoint(1);
            ValLine line1 = new ValLine(rPoint, vPoint);
            ValLine line2 = line1;
            result = line1.Equals(line2);  // 此时已经存在一个装箱操作，调用 ValueType.Equals()
            Console.WriteLine(result);  // 返回 True


            Console.ReadKey();
        }
         public static bool ReferenceEquals(Object objA, Object objB)
        {
            return objA == objB; // #1
        }
        //public virtual bool Equals(Object obj)
        //{
        //    return InternalEquals(this, obj); // #2
        //}
        public static bool Equals(Object objA, Object objB)
        {
            if (objA == objB)
            {  // #3
                return true;
            }
            if (objA == null || objB == null)
            {
                return false;
            }
            return objA.Equals(objB); // #4
        }
    }
}
