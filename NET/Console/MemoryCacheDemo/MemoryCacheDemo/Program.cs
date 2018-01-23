using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;
using System.IO;
using Cache.Interface;
using Cache.ChangeMoniter;
using Cache;



namespace MemoryCacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Cache.MemoryCache cache = Cache.MemoryCache.DefaultCache;//获取缓存 

            //这里处理自己的逻辑  
            MemoryCachePolicy policy = new MemoryCachePolicy(PolicyType.TimeChange);//设置缓存策略
            TimeChangeMonitor moniter = new TimeChangeMonitor(TimeSpan.FromSeconds(10));//设置相对时间的时间监视器
            //TimeChangeMonitor moniter = new TimeChangeMonitor(DateTime.Now.AddSeconds(600));//设置绝对时间的时间监视器
            policy.TimeChangeMoniter = moniter;
            //存入缓存
            cache.SetCache("Cmd", "AAAAA", policy);
            if (cache.ContainCache("Cmd") == false) Console.WriteLine("True");
            string dsCheck = cache.GetCache<string>("Cmd");
            Console.WriteLine(dsCheck);
            Console.ReadKey();
            

            //object data = new object();
            //string key = "UniqueIDOfDataObject";
            ////Insert empty cache item with absolute timeout
            //string[] absKey = { "Absolute" + key };
            //MemoryCache.Default.Add("Absolute" + key, new object(), DateTimeOffset.Now.AddMinutes(10));

            ////Create a CacheEntryChangeMonitor link to absolute timeout cache item
            //CacheEntryChangeMonitor monitor = MemoryCache.Default.CreateCacheEntryChangeMonitor(absKey);

            ////Insert data cache item with sliding timeout using changeMonitors
            //CacheItemPolicy itemPolicy = new CacheItemPolicy();
            //itemPolicy.ChangeMonitors.Add(monitor);
            //itemPolicy.SlidingExpiration = new TimeSpan(0, 60, 0);
            //MemoryCache.Default.Add(key, data, itemPolicy, null);


            //MemoryCacheHelper _cache = new MemoryCacheHelper();
            //_cache.Add("A1", "B1", null, System.DateTime.Now.AddSeconds(11));
            //_cache.RemovedCallback += RemovedCallback;
            ////_cache.UpdateCallback += UpdateCallback;
            //string d = _cache.Get<string>("A1");
            //Console.WriteLine("A1=>" + d);
            //_cache.Update<string>("A1", "B2");
            //Console.ReadKey();           
        }

        private static void RemovedCallback(CacheEntryRemovedArguments arguments)
        {            
            Console.WriteLine("Remove =>" + arguments.CacheItem.Key);
            Console.WriteLine("RemovedReason =>" + arguments.RemovedReason.ToString());
        }

        private static void UpdateCallback(CacheEntryUpdateArguments arguments)
        {
            Console.WriteLine("UP =>" + arguments.UpdatedCacheItem.Key);
            Console.WriteLine("UP Data=>" + arguments.UpdatedCacheItem.Value);
        }
    }
}

