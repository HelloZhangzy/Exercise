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
using WPF.DazzleUI2.Controls;

namespace DazzleUI2.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : DazzleWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DazzleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DazzleButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void DazzleButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void _C_More(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://cleopard.download.csdn.net/");
        }

        private void _C_Alu(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/user/cleopard/album");
        }
        private void _C_F(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://xuemeilaile.com");
        }
        private void _C_6C(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/1457");
        }
        private void _C_17(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/1425");
        }
        private void _C_13(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/1115");
        }

        private void _C_C2(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/957");
        }

        private void _C_C1(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/669");
        }

        private void _C_C6(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/667");
        }

        private void _C_10J(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/663");
        }

        private void _C_10C(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/631");
        }

        private void _C_6G(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.csdn.net/album/detail/625");
        }
    }
}
