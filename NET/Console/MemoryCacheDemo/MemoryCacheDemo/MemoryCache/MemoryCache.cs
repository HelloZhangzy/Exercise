using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cache.Interface;
using Cache.ChangeMoniter;  

namespace Cache
{
    public class MemoryCache
    {
        #region 属性
        private string _name = string.Empty;
        private static readonly object lockobj = new object();
        public string Name
        {
            get { return _name; }
        }

        private Dictionary<string, MemoryCacheEntry> _cache;
        #endregion

        #region 构造函数
        private MemoryCache(string cacheName)
        {
            this._name = cacheName;
            this._cache = new Dictionary<string, MemoryCacheEntry>();
            MemoryCacheManager.GetManager().Add(this);

        }
        #endregion

        #region 默认的MemoryCache
        private static MemoryCache _defaultMemoryCache;

        /// <summary>默认的MemoryCache</summary>  
        public static MemoryCache DefaultCache
        {
            get
            {
                lock (lockobj)//多线程并发锁  
                {
                    if (_defaultMemoryCache == null)
                    {
                        _defaultMemoryCache = new MemoryCache("Default");
                    }
                }
                return _defaultMemoryCache;
            }
        }
        #endregion

        #region 创建一个新的非默认的MemoryCache
        /// <summary>  
        /// 该方法是获取一个新缓存对象  
        /// </summary>  
        /// <param name="cacheName">MemoryCache名字</param>  
        /// <returns></returns>  
        public static MemoryCache GetMemoryCache(string cacheName)
        {
            if (MemoryCacheManager.GetManager().ContainCache(cacheName))
            {
                return MemoryCacheManager.GetManager().Get(cacheName);
            }
            else
            {
                return new MemoryCache(cacheName);
            }
        }
        #endregion

        #region 缓存对象操作方法
        /// <summary>将对象放入缓存</summary>  
        /// <param name="key">缓存对象的key</param>  
        /// <param name="value">需要缓存的对象</param>  
        /// <param name="policy">缓存的处理策略</param>  
        public void SetCache(string key, object value, MemoryCachePolicy policy)
        {
            lock (lockobj)
            {
                MemoryCacheEntry cacheEntry = new MemoryCacheEntry(this, key, value, policy);
                this._cache.Add(key, cacheEntry);

                //刷新激活时间  
                cacheEntry.RefreshActivityTime();
            }
        }

        /// <summary>获取缓存对象</summary>  
        /// <typeparam name="T">缓存对象类型</typeparam>  
        /// <param name="key">缓存对象的key</param>  
        /// <returns></returns>  
        public T GetCache<T>(string key)
        {
            //判断缓存是否过期  
            CheckExpireAndRemove(key);

            if (_cache.ContainsKey(key))
            {
                MemoryCacheEntry cacheEntry = this._cache[key];
                //刷新激活时间  
                cacheEntry.RefreshActivityTime();

                return (T)cacheEntry.Value;
            }
            else
            {
                throw new Exception(string.Format("不存在key为{0}的缓存对象", key));
            }

        }

        /// <summary>从MemoryCache中移除缓存对象</summary>  
        /// <param name="key">缓存对象的key</param>  
        public void RemoveCache(string key)
        {
            if (_cache.ContainsKey(key))
            {
                _cache.Remove(key);
            }
        }

        /// <summary>从MemoryCache中移除缓存对象（供MemoryCacheEntry的回调）</summary>  
        /// <param name="cacheName"></param>  
        /// <param name="key"></param>  
        internal void RemoveCache(string cacheName, string key)
        {
            MemoryCacheManager.GetManager().Get(cacheName).RemoveCache(key);
        }

        public bool ContainCache(string key)
        {
            //判断缓存是否过期  
            CheckExpireAndRemove(key);

            return _cache.ContainsKey(key);
        }

        /// <summary>  
        /// 判断缓存对象是否过期并移除  
        /// </summary>  
        /// <returns></returns>  
        private void CheckExpireAndRemove(string key)
        {
            if (_cache.ContainsKey(key))
            {
                //MemoryCacheEntry cacheEntry = this._cache[key];  
                IRemoveCache cacheEntry = this._cache[key];
                cacheEntry.CheckExpireAndRemove();
            }
        }
        #endregion
    }  
}
