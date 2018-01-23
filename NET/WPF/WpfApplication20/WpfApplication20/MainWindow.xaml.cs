using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication20
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitalizeCommand();
        }
        private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(MainWindow));

        private void InitalizeCommand()
        {
            ////把命令赋值给命令源（发送者）并指定快捷键
            button1.Command = this.clearCmd;

            //声明键盘命令Alt+C
            clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定目标
            button1.CommandTarget = textBoxA;

            ////创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = clearCmd;
            cb.CanExecute +=new CanExecuteRoutedEventHandler(cb_CanExecute); ;
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);
            
            ////把命令关联安置在外围控件上
            ////标志着Stackpanel范围内按动Alt+C 均能将textBoxA清空
            stackPanel.CommandBindings.Add(cb);
        }

        void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            //textBoxA为空时命令不可用
            if (string.IsNullOrEmpty(textBoxA.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //避免继续向上传而降低程序性能
            e.Handled = true;
        }

        void cb_Executed(object sender,ExecutedRoutedEventArgs e)
        {
            //Thread.Sleep(3000);
            textBoxA.Clear();
            e.Handled = true;          
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                e.CanExecute = false;
            }
            else
                e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            if (e.Parameter.ToString()=="Teacher")
            {
                this.ListBoxNewItems.Items.Add(string.Format("New Teacher:{0},学而不厌、诲人不倦。",name));
            }
            else
                if (e.Parameter.ToString()=="Student")
            {
                ListBoxNewItems.Items.Add(string.Format("New Student:{0},好好学习、天天向上。", name));
            }
        }
    }
}
