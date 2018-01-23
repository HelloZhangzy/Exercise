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
            Queue<UpstreamObject> quo = new Queue<UpstreamObject>();
            for (int i = 0; i < 58000000; i++)
            {
                quo.Enqueue(new UpstreamObject(i));
                if (i % 10000==0 )
                {
                    Console.WriteLine(i);
                }
            }

            Console.ReadKey();
        }
    }

    public class UpstreamObject
    {
        public Object upstreamData;
        public int gwType;
        public Int64 ID;

        public UpstreamObject()
        {
            ID = 11;
            gwType = 1901;
            upstreamData = new object();
        }

        public UpstreamObject(Int64 id)
        {
            this.ID = id;
            gwType = 105;
            upstreamData = (new UpstreamObject());
        }
    }
}
