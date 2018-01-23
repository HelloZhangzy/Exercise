using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;


namespace MemoryCacheDemo
{
    /// <summary>
    /// 基于MemoryCache的缓存辅助类
    /// </summary>
    public  class MemoryCacheHelper
    {
        private static object _locker = new object();

        private static MemoryCache _cache = new MemoryCache("CmdCache");

        #region Event
        //委托移除以后  
        private CacheEntryRemovedCallback _RemovedCallback;

        //委托即将移除时  
        private CacheEntryUpdateCallback _UpdateCallback;

        

        public event CacheEntryRemovedCallback RemovedCallback
        {
            add
            {
                lock (_locker)
                {
                    _RemovedCallback += value;
                }
            }
            remove
            {
                lock (_locker)
                {
                    _RemovedCallback -= value;
                }
            }
        }

        public event CacheEntryUpdateCallback UpdateCallback
        {
            add
            {
                lock (_locker)
                {
                    _UpdateCallback += value;
                }
            }
            remove
            {
                lock (_locker)
                {
                    _UpdateCallback -= value;
                }
            }
        }
        
        /// <summary>  
        /// 定义在从缓存中移除某个缓存项后触发  
        /// </summary>  
        /// <param name="args">有关已从缓存中移除的缓存项的信息</param>  
        protected virtual void OnRemovedCallback(CacheEntryRemovedArguments args)
        {
            if (_RemovedCallback != null)
                _RemovedCallback(args);
        }

        /// <summary>  
        /// 定义在从缓存中即将移除某个缓存项时触发  
        /// </summary>  
        /// <param name="args">有关将从缓存中移除的缓存项的信息</param>  
        protected virtual void OnUpdateCallback(CacheEntryUpdateArguments args)
        {
            if (_UpdateCallback != null)
                _UpdateCallback(args);
        }

        #endregion
        
        /// <summary>
        /// 获取Catch元素
        /// </summary>
        /// <typeparam name="T">所获取的元素的类型</typeparam>
        /// <param name="key">元素的键</param>
        /// <returns>特定的元素值</returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("不合法的key!");
            if (!_cache.Contains(key))
                throw new ArgumentException("获取失败,不存在该key!");
            if (!(_cache[key] is T))
                throw new ArgumentException("未找到所需类型数据!");
            return (T)_cache[key];
        }

        public void Update<T>(string key,T value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("不合法的key!");
            if (!_cache.Contains(key))
                throw new ArgumentException("获取失败,不存在该key!");
            if (!(_cache[key] is T))
                throw new ArgumentException("未找到所需类型数据!");
            lock (_locker) _cache[key] = value;            
        }

        /// <summary>
        /// 添加Catch元素
        /// </summary>
        /// <param name="key">元素的键</param>
        /// <param name="value">元素的值</param>
        /// <param name="slidingExpiration">元素过期时间(时间间隔)</param>
        /// <param name="absoluteExpiration">元素过期时间(绝对时间)</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            var item = new CacheItem(key, value);
            CacheItemPolicy policy = CreatePolicy(slidingExpiration, absoluteExpiration);
            //if (_RemovedCallback!=null)            
            policy.RemovedCallback += OnRemovedCallback;
            //if (_UpdateCallback!=null)            
            //policy.UpdateCallback += OnUpdateCallback;

           // CacheEntryChangeMonitor monitor = _cache.CreateCacheEntryChangeMonitor(_cache[key]);

            lock (_locker)
                return _cache.Add(item, policy);
        }

        /// <summary>
        /// 移出Cache元素
        /// </summary>
        /// <typeparam name="T">待移出元素的类型</typeparam>
        /// <param name="key">待移除元素的键</param>
        /// <returns>已经移出的元素</returns>
        public T Remove<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("不合法的key!");
            if (!_cache.Contains(key))
                throw new ArgumentException("获取失败,不存在该key!");
            var value = _cache.Get(key);
            if (!(value is T))
                throw new ArgumentException("未找到所需类型数据!");
            return (T)_cache.Remove(key);
        }

        /// <summary>
        /// 移出多条缓存数据,默认为所有缓存
        /// </summary>
        /// <typeparam name="T">待移出的缓存类型</typeparam>
        /// <param name="keyList"></param>
        /// <returns></returns>
        public  List<T> RemoveAll<T>(IEnumerable<string> keyList = null)
        {
            if (keyList != null)
                return (from key in keyList
                        where _cache.Contains(key)
                        where _cache.Get(key) is T
                        select (T)_cache.Remove(key)).ToList();
            while (_cache.GetCount() > 0)
                _cache.Remove(MemoryCache.Default.ElementAt(0).Key);
            return new List<T>();
        }

        /// <summary>
        /// 设置过期信息
        /// </summary>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        private CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }
            else
            {
                policy.AbsoluteExpiration = MemoryCache.InfiniteAbsoluteExpiration;
            }

            policy.Priority = CacheItemPriority.Default;
            return policy;
        }
                
    }
}
