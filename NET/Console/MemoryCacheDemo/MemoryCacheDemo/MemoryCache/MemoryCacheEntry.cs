using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cache.Interface;
using Cache.ChangeMoniter;

namespace Cache
{
    internal class MemoryCacheEntry : IRemoveCache
    {
        #region 变量
        private MemoryCache _memoryCache;
        #endregion

        #region 属性
        public MemoryCachePolicy CachePolicy { set; get; }
        public object Value { set; get; }
        public string Key { set; get; }
        #endregion

        #region 构造函数
        public MemoryCacheEntry(MemoryCache memoryCache, string key, object value, MemoryCachePolicy policy)
        {
            this._memoryCache = memoryCache;
            this.Key = key;
            this.Value = value;
            this.CachePolicy = policy;
        }
        #endregion

        /// <summary> 刷新对象激活时间 </summary>  
        public void RefreshActivityTime()
        {
            switch (CachePolicy.PolicyType)
            {
                case PolicyType.FileChange:
                    CachePolicy.FileChangeMoniter.RefreshActivityTime(DateTime.Now);
                    break;
                case PolicyType.TimeChange:
                    CachePolicy.TimeChangeMoniter.RefreshActivityTime(DateTime.Now);
                    break;
                case PolicyType.Custom:
                    CachePolicy.CustomChangeMoniters.RefreshActivityTime(DateTime.Now);
                    break;
            }
        }

        /// <summary>删除缓存对象</summary>  
        /// <param name="cacheName"></param>  
        /// <param name="key"></param>  
        private void RemoveCache(string cacheName, string key)
        {
            this._memoryCache.RemoveCache(cacheName, key);
        }

        #region IRemoveCache接口方法
        public void CheckExpireAndRemove()
        {
            bool isRemove = false;
            if (CachePolicy != null)
            {
                switch (CachePolicy.PolicyType)
                {
                    case PolicyType.FileChange:
                        isRemove = CachePolicy.FileChangeMoniter.IsExpire();
                        break;
                    case PolicyType.TimeChange:
                        isRemove = CachePolicy.TimeChangeMoniter.IsExpire();
                        break;
                    case PolicyType.Custom:
                        isRemove = CachePolicy.FileChangeMoniter.IsExpire();
                        break;
                }
            }

            if (isRemove)
            {
                //回调删除缓存对象  
                RemoveCache(this._memoryCache.Name, Key);
            }
        }
        #endregion
    }  
}
