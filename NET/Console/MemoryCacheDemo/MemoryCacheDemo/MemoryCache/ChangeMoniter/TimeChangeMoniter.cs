using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cache.Interface;


namespace Cache.ChangeMoniter
{
    public enum TimeType { Relative_Time, Absolute_Time }

    public class TimeChangeMonitor : IMoniter
    {
        #region 变量
        private DateTime _createTime;//创建时间  
        private DateTime _activityTime;//激活时间  
        private DateTime _disposeTime;//消除时间  
        private TimeSpan _spanTime;//相对时间  
        private TimeType _timeType;
        private bool _isRemove = false;
        #endregion

        #region 属性
        public DateTime CreateTime
        {
            get { return _createTime; }
        }
        public DateTime ActivityTime
        {
            get { return _activityTime; }
        }
        public DateTime DisposeTime
        {
            get { return _disposeTime; }
        }
        public TimeSpan SpanTime
        {
            get { return _spanTime; }
        }

        public TimeType timeType
        {
            get { return _timeType; }
        }
        #endregion

        #region 构造函数
        public TimeChangeMonitor(DateTime disposeTime)
        {
            this._createTime = DateTime.Now;
            this._activityTime = this._createTime;
            this._disposeTime = disposeTime;
            this._timeType = TimeType.Absolute_Time;
        }

        public TimeChangeMonitor(TimeSpan spanTime)
        {
            this._createTime = DateTime.Now;
            this._activityTime = this._createTime;
            this._spanTime = spanTime;
            this._timeType = TimeType.Relative_Time;
        }
        #endregion

        /// <summary>比较绝对时间的过期策略</summary>  
        /// <returns>过期：true,不过期：false</returns>  
        private bool SetAbsoluteTime()
        {
            DateTime nowTime = DateTime.Now;
            if (nowTime.CompareTo(DisposeTime) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>比较相对时间的过期策略</summary>  
        /// <returns>过期:true,不过期:false</returns>  
        private bool SetRelativeTime()
        {
            DateTime endTime = this._activityTime + this._spanTime;
            DateTime nowTime = DateTime.Now;
            if (nowTime.CompareTo(endTime) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region IMoniter接口方法
        // 判断对象是否过期  
        public bool IsExpire()
        {
            switch (_timeType)
            {
                case TimeType.Absolute_Time://绝对时间  
                    _isRemove = SetAbsoluteTime();
                    break;
                case TimeType.Relative_Time://相对时间  
                    _isRemove = SetRelativeTime();
                    break;
            }

            return _isRemove;
        }

        //刷新对象的激活时间  
        public void RefreshActivityTime(DateTime time)
        {
            this._activityTime = time;
        }
        #endregion
    }
}