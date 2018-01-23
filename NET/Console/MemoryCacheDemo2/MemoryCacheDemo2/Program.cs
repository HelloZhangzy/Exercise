using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace MemoryCacheDemo2
{


    class Program
    {
        


        private static object _locker=new object();
        private static Int64 i = 0;
        private static MemoryCacheHelper<User> Cache;
        static void Main(string[] args)
        {
            Cache = new MemoryCacheHelper<User>("User");
            User U1 = new User(4, "A1", 10);
            User U2 = new User(5, "A2", 20);
            User U3 = new User(16, "A3", 30);
            Cache.Add(U1.ID.ToString(), U1.Clone());
            Cache.Add(U2.ID.ToString(), U2.Clone());
            Cache.Add(U3.ID.ToString(), U3.Clone());
            Cache.RemovedCallback += RemovedCallback;

            //User U = Cache.Get<User>("2");
            //U.name = "B2";

            temp dd = (from p in Cache group p by p.ID into g
                       select new temp { age = g.Max(p => p.Age), id = g.Key, t = "ddd" }
                       ).FirstOrDefault();
            
            //foreach (var item in dd)
            //{
                
            //    Console.WriteLine("ID:{0},Age:{1}", item.id, item.age);
            //}

            showdd(dd);

            Console.WriteLine("StartTime:{0}", System.DateTime.Now);


            Console.WriteLine("StartTime:{0}", System.DateTime.Now);
            Console.WriteLine("count:{0}", Cache.Count);
            

            
            //Thread rd1 = new Thread(new ThreadStart(ShowData));
            //Thread rd2 = new Thread(new ThreadStart(AddData));
            //rd1.Start();
            //rd2.Start();
            Console.ReadLine();
        }

        
        private static void ShowData()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Show Begin");
                var d = Cache.OrderBy(t=>t.ID);               
                foreach (var item in d)
                {
                   
                    Thread.Sleep(300);
                    User u = (User)item;
                    Console.WriteLine("ID:{0},Name:{1},Age:{2}", u.ID, u.name, u.Age);
                                 
                }
                Console.WriteLine("Show End");
                Console.WriteLine("----------------------------");
            }
        }

        private static void AddData()
        {
            int i = 4;
            while(true)
            {
                Thread.Sleep(5000);
                Console.WriteLine("********************************");
                User u = new User(i, "A"+i.ToString(), i*10);
                Cache.Add(u.ID.ToString(), u.Clone());
                Console.WriteLine("ADD ID:{0},Name:{1},Age:{2}", u.ID, u.name, u.Age);
                Console.WriteLine("********************************");
                i++;
            }
        }

        private static void RemovedCallback(CacheEntryRemovedArguments args)
        {
            lock (_locker)
            {
                i++;
            }
            Console.WriteLine("count:{3},RemovedReason:{0},Key:{1},Date:{2}", args.RemovedReason.ToString(), args.CacheItem.Key, System.DateTime.Now,i);  
            
        }

        public static void showdd(temp dd)
        {
            //foreach (var item in dd)
            //{
                Console.WriteLine("ID:{0},Age:{1}", dd.id, dd.age);
            //}
            //Console.WriteLine("ID:{0},Age:{1}", item.id, item.age);
        }
    }    

    class temp: IEnumerable
    {
       public long age { get; set; }
       public long id { get; set; }
        public string t { get; set; }
        public IEnumerator GetEnumerator()
        {
            yield return this;
        }

        //public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
        //{
        //    foreach (var cur in e)
        //    {
        //        yield return cur;
        //    }
        //    yield return value;
        //}

        public IEnumerable<int> Add(int value)
        {
            yield return value;
        }

        public IEnumerable<string> Add(string value)
        {
            yield return value;
        }
    }

    public class User:ICloneable
    {
        public Int64 ID { get; set; }
        public string name { get; set; }
        public Int64 Age { get; set; }
        public User(Int64 I, string N, Int64 A) { ID = I; name = N; Age = A; }

        public object Clone()
        {            
            return this.MemberwiseClone();
        }
    }

}
