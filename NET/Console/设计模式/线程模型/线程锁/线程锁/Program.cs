using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 线程锁
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 0;
            System.Threading.Tasks.Parallel.For(0, 100000, (i) =>
            {
                a++;
            });
            Console.WriteLine(a);

            //原子操作
            a = 0;
            System.Threading.Tasks.Parallel.For(0, 100000, (i) =>
            {
                System.Threading.Interlocked.Add(ref a, 1);//正确                
            });
            Console.WriteLine(a);


            Console.Read();
        }
    }
}
