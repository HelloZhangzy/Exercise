using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;
using System.Collections;

namespace MemoryCacheDemo2
{
    class MemoryCacheHelper<T> : IDisposable, IEnumerable<T>
    {
        private MemoryCache _Cache;
        private object _locker = new object();
      
        protected MemoryCache Cache{get{return _Cache;}}

        public long Count { get { return _Cache.GetCount(); } }       
       

        #region Event
        /// <summary>
        /// 移除缓存事件
        /// </summary>
        private CacheEntryRemovedCallback _removedCallback;

        public event CacheEntryRemovedCallback RemovedCallback
        {
            add { _removedCallback += value; }

            remove { _removedCallback -= value; }
        }

        protected void OnRemovedCallback(CacheEntryRemovedArguments args)
        {
            if (_removedCallback != null) _removedCallback(args);
        }
        #endregion

        #region 构造
        /// <summary>
        /// 使用默认实例
        /// </summary>
        public MemoryCacheHelper()
        {
            _Cache = MemoryCache.Default;
            Console.WriteLine("PhysicalMemoryLimit：{0}" + _Cache.PhysicalMemoryLimit);
            Console.WriteLine("cacheMemoryLimitMegabytes：{0}" + _Cache.CacheMemoryLimit);
            Console.WriteLine("PollingInterval：{0}" + _Cache.PollingInterval);  
        }
        /// <summary>
        /// 使用自定议实例
        /// </summary>
        /// <param name="CacheName">实例名称</param>
        public MemoryCacheHelper(string CacheName)
        {
            _Cache = new MemoryCache(CacheName);
            Console.WriteLine("PhysicalMemoryLimit：{0}" + _Cache.PhysicalMemoryLimit);
            Console.WriteLine("cacheMemoryLimitMegabytes：{0}" + _Cache.CacheMemoryLimit);
            Console.WriteLine("PollingInterval：{0}" + _Cache.PollingInterval);          
        }
        #endregion


        #region IEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            //IEnumerable<KeyValuePair<string,object>> Item=;
            foreach (var item in _Cache)
            {
                yield return (T)item.Value;
            }
        }
        //显式实现接口  
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public IEnumerable<KeyValuePair<string,object>> GetEnumerable()
        {
            return _Cache.AsEnumerable();
        }

        public void Dispose()
        {
            RemoveAll();
            _Cache = null;
            _Cache.Dispose();
            GC.ReRegisterForFinalize(this);
        }


        /// <summary>
        /// 增加缓存（定时移除）
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="Value">键值</param>
        /// <param name="Absolute_Time">在什么时间点移除缓存</param>
        public bool Add<T>(string key, T Value, DateTimeOffset AbsoluteTime)
        {
            CacheItem item = new CacheItem(key, Value);
            CacheItemPolicy policy = CreatePolicy(AbsoluteTime);            
            lock (_locker)
                return _Cache.Add(item, policy);
        }

        /// <summary>
        /// 增加缓存(多长时间未访问移除)
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="Value">键值</param>
        /// <param name="Relative_Time">间隔多长时间未访问移除缓存</param>
        public bool Add<T>(string key, T Value, TimeSpan RelativeTime)
        {
            CacheItem item = new CacheItem(key, Value);
            CacheItemPolicy policy = CreatePolicy(RelativeTime);
            lock (_locker)
                return _Cache.Add(item, policy);
        }        

        /// <summary>
        /// 增加缓存（永不过期）
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="Value">键值</param>
        public bool Add<T>(string key, T Value)
        {
            CacheItem item = new CacheItem(key, Value);
            CacheItemPolicy policy = CreatePolicy();
            lock (_locker)
                return _Cache.Add(item, policy);
        }

        public bool Update<T>(string key, T Value)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;
            if (!_Cache.Contains(key)) return false;
            if (!(_Cache[key] is T)) return false;
            lock (_locker) _Cache[key] = _Cache;
            return true;
        }

        public bool Reomve(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;
            if (!_Cache.Contains(key)) return false;
            lock (_locker)
            {
                var temp = _Cache.Remove(key);
                if (temp != null)
                {
                    return true;
                }
                else return false;
            }
        }

        public void RemoveAll()
        {
            foreach (var item in _Cache)
            {
                lock (_locker) { _Cache.Remove(item.Key); }
            }
        }    

        public T Get<T>(string Key)
        {
            return (T)_Cache[Key];
        }

        private CacheItemPolicy CreatePolicyDefault()
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            //policy.Priority = CacheItemPriority.Default;
            policy.RemovedCallback = OnRemovedCallback;
            return policy;
        }
        
        /// <summary>
        /// 设置永不过期
        /// </summary>
        /// <returns></returns>
        private CacheItemPolicy CreatePolicy()
        {
            CacheItemPolicy policy = CreatePolicyDefault();
            //policy.AbsoluteExpiration = MemoryCache.InfiniteAbsoluteExpiration;
            //policy.SlidingExpiration = MemoryCache.NoSlidingExpiration;
            return policy;
        }

        /// <summary>
        /// 设置多长时间未访问移除
        /// </summary>
        /// <param name="RelativeTime"></param>
        /// <returns></returns>
        private CacheItemPolicy CreatePolicy(TimeSpan RelativeTime)
        {
            CacheItemPolicy policy = CreatePolicyDefault();
            policy.SlidingExpiration = RelativeTime;            
            return policy;
        }

        /// <summary>
        /// 设置定时移除
        /// </summary>
        /// <param name="AbsoluteTime"></param>
        /// <returns></returns>
        private CacheItemPolicy CreatePolicy(DateTimeOffset AbsoluteTime)
        {
            CacheItemPolicy policy = CreatePolicyDefault();
            policy.AbsoluteExpiration = AbsoluteTime;           
            return policy;
        }

    }
}
