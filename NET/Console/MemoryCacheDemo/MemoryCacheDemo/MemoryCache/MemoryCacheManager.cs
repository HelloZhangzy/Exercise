using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cache.Interface;
using Cache.ChangeMoniter;

namespace Cache
{
    /// <summary>  
    /// MemoryCache的管理工具类  
    /// 该类是单例类  
    /// </summary>  
    internal class MemoryCacheManager
    {
        private static MemoryCacheManager _memoryCacheManager;
        private Dictionary<string, MemoryCache> _cacheManager = new Dictionary<string, MemoryCache>();
        private static readonly object lockobj = new object();

        private MemoryCacheManager() { }

        public static MemoryCacheManager GetManager()
        {
            lock (lockobj)//控制多线程的并发问题  
            {
                if (_memoryCacheManager == null)
                {
                    _memoryCacheManager = new MemoryCacheManager();
                }
            }
            return _memoryCacheManager;
        }

        /// <summary>将缓存对象存入缓存管理器</summary>  
        /// <param name="memoryCache">MemoryCache对象</param>  
        public void Add(MemoryCache memoryCache)
        {
            lock (lockobj)
            {
                if (_cacheManager.ContainsKey(memoryCache.Name))
                {
                    _cacheManager.Remove(memoryCache.Name);
                }
                _cacheManager.Add(memoryCache.Name, memoryCache);
            }
        }

        /// <summary>获取memoryCacheName对应的MemoryCache对象</summary>  
        /// <param name="memoryCacheName">MemoryCache名称</param>  
        /// <returns></returns>  
        public MemoryCache Get(string memoryCacheName)
        {
            if (_cacheManager.ContainsKey(memoryCacheName))
            {
                return _cacheManager[memoryCacheName];
            }
            else
            {
                throw new Exception("MemoryCache缓存对象找不到！");
                //return default(MemoryCache);  
            }
        }

        /// <summary>判断当前的MemoryCache是否存在</summary>  
        /// <param name="memoryCacheName"></param>  
        /// <returns></returns>  
        public bool ContainCache(string memoryCacheName)
        {
            if (_cacheManager.ContainsKey(memoryCacheName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>MemoryCacheManager索引器</summary>  
        /// <param name="memoryCacheName">MemoryCache名称</param>  
        /// <returns></returns>  
        public MemoryCache this[string memoryCacheName]
        {
            get
            {
                if (_cacheManager.ContainsKey(memoryCacheName))
                {
                    return _cacheManager[memoryCacheName];
                }
                else
                {
                    throw new Exception("MemoryCache缓存对象找不到！");
                    //return default(MemoryCache);  
                }
            }
        }


    }  
}
