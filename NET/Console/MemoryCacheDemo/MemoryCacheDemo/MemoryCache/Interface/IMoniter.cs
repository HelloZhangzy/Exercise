using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Cache.Interface
{
    /// <summary>  
    /// Moniter的回调方法接口  
    /// </summary>  
   public interface IMoniter
    {
        /// <summary>  
        /// 当前对象是否过期  
        /// </summary>  
        /// <returns></returns>  
        bool IsExpire();

        /// <summary>  
        /// 刷新激活时间  
        /// </summary>  
        void RefreshActivityTime(DateTime time);
    }  
}
