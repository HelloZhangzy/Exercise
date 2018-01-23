using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cache.Interface;
//using MemoryCacheDemo.MemoryCache.Moniter;  
using Cache.ChangeMoniter;

namespace Cache
{
    public class MemoryCachePolicy
    {
        #region 变量
        private PolicyType _policyType;

        #endregion

        #region 属性
        /// <summary>  
        /// Policy类型  
        /// </summary>  
        public PolicyType PolicyType
        {
            get { return _policyType; }
        }

        /// <summary>  
        /// 文件改变Moniter  
        /// </summary>  
        public FileChangeMoniter FileChangeMoniter { set; get; }

        /// <summary>  
        /// 时间改变Moniter  
        /// </summary>  
        public TimeChangeMonitor TimeChangeMoniter { set; get; }

        /// <summary>  
        /// 用来自定义扩展的Moniter  
        /// </summary>  
        public IMoniter CustomChangeMoniters { set; get; }
        #endregion

        #region 构造函数
        public MemoryCachePolicy(PolicyType type)
        {
            this._policyType = type;
        }
        #endregion
    }

    public enum PolicyType
    {
        FileChange = 0,
        TimeChange = 1,
        Custom = 2
    } 
}
