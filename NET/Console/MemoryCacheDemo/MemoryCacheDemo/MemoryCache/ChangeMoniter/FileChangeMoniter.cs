using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using System.IO;    
using Cache.Interface;

namespace Cache.ChangeMoniter
{
    public class FileChangeMoniter : IMoniter
    {
        #region 变量
        private FileSystemWatcher fileWatcher = null;//文件监视器对象  
        private string _filePath = string.Empty;
        private DateTime _activityTime;//对象的激活时间  
        private bool _isRemove = false;//该缓存对象是否移除  
        #endregion

        #region 属性
        /// <summary>  
        /// 文件路径  
        /// </summary>  
        public string FilePath
        {
            get { return _filePath; }
        }
        public DateTime ActivityTime
        {
            get { return _activityTime; }
        }
        #endregion

        #region 构造函数
        public FileChangeMoniter(string filePath)
        {
            this._filePath = filePath;
            SetFileWatcher();
        }
        #endregion

        #region 文件监视器
        /// <summary>  
        /// 设置文件监视器  
        /// </summary>  
        private void SetFileWatcher()
        {
            fileWatcher = new FileSystemWatcher();
            fileWatcher.Path = this.FilePath.Substring(0, this.FilePath.LastIndexOf(@"\"));
            fileWatcher.Filter = this.FilePath.Substring(this.FilePath.LastIndexOf(@"\") + 1, this.FilePath.Length - 1 - this.FilePath.LastIndexOf(@"\"));
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.EnableRaisingEvents = true;

            fileWatcher.Changed += fileWatcher_Changed;

        }

        /// <summary>  
        /// 文件修改事件  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            _isRemove = true;
        }
        #endregion

        #region IMoniter接口方法
        // 判断对象是否过期  
        public bool IsExpire()
        {
            return this._isRemove;
        }

        // 刷新对象激活时间  
        public void RefreshActivityTime(DateTime time)
        {
            this._activityTime = time;
        }
        #endregion
    }
}