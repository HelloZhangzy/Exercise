using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Interface
{
    /// <summary>  
    /// 定义了调用了MemoryCache回调函数删除缓存对象的接口  
    /// </summary>  
    internal interface IRemoveCache
    {
        /// <summary>  
        /// 判断缓存对象是否过期并移除  
        /// </summary>  
        /// <returns></returns>  
        void CheckExpireAndRemove();
    }  
}
