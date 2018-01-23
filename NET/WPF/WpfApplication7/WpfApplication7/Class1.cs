using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApplication7
{
    public class Song
    {
        #region Members
        string _artistName;
        string _songTitle;
        int _count;
        #endregion

        #region Properties
        ///<summary>
        /// 艺术家名称
        ///</summary>
        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }
        ///<summary>
        /// 歌曲标题
        ///</summary>
        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; }
        }
        #endregion
    }

    public class SongViewModel : INotifyPropertyChanged
    {

        #region 构造函数
        /// <summary>
        /// 构造缺省的SongViewModel实例
        /// </summary>
        public SongViewModel()
        {
            _song = new Song { ArtistName = "Unknown", SongTitle = "Unknown", count = 0 };
        }
        #endregion

        #region 成员
        Song _song;
        #endregion

        #region 属性
        public Song Song
        {
            get { return _song; }
            set { _song = value; }
        }

        public string ArtistName
        {
            get { return Song.ArtistName; }
            set
            {
                if (Song.ArtistName != value)
                {
                    Song.ArtistName = value;
                    RaisePropertyChanged("ArtistName");
                }
            }
        }
        public int count
        {
            get { return Song.count; }
            set
            {
                if (Song.count != value)
                {
                    Song.count = value;
                    RaisePropertyChanged("count");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanged 方法
        private void RaisePropertyChanged(string propertyName)
        {
            //得到一个副本以预防线程问题
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ICommand UpdateArtistName
        {
            get
            {
                ICommand cmd = new RelayCommand(() =>
                {
                    ++count;
                    ArtistName = string.Format("Elvis({0})", count);
                   
                });
                return cmd;
            }
        }

    }
    public class RelayCommand : ICommand
    {
        #region 成员
        readonly Func<Boolean> _canExecute;
        readonly Action _execute;
        #endregion

        #region 构造函数
        public RelayCommand(Action execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand 成员

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute();
        }

        #endregion
    }
}
