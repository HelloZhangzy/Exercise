using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GUI线程回调
{
    public static class  GUIThreadHelper
    {
        public static SynchronizationContext GUISyncContext { get { return _GUISyncContext; }set { _GUISyncContext = value; } }

        private static SynchronizationContext _GUISyncContext = SynchronizationContext.Current;

        /// <summary>
        /// 主要用于GUI线程的同步回调
        /// </summary>
        /// <param name="callback"></param>
        public static void SyncContextCallback(Action callback)
        {
            if (callback == null) return;
            if (GUISyncContext == null)
            {
                callback();
                return;
            }
            GUISyncContext.Post(result => callback(), null);
        }

        /// <summary>
        /// 支持APM异步编程模型的GUI线程的同步回调
        /// </summary>
        public static AsyncCallback SyncContextCallback(AsyncCallback callback)
        {
            if (callback == null) return callback;

            if (GUISyncContext == null) return callback;

            return asynresult => GUISyncContext.Post(result => callback(result as IAsyncResult), asynresult);
        }
    }

}
