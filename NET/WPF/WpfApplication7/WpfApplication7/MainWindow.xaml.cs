using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication7
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SongViewModel _viewModel = new SongViewModel();
        int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }
        private void ButtonUpdateArtist_Click(object sender, RoutedEventArgs e)
        {
            ++_count;
            _viewModel.ArtistName = string.Format("Elvis({0})", _count);
        }
        private void ButtonUpdateArtist2_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
