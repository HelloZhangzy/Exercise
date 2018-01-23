using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfApplication21
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearCommand clearCmd = new ClearCommand();
            ctrlClear.Command = clearCmd;
            ctrlClear.CommandTarget = minview;            
        }
    }

    public interface IView
    {
        bool IsChanged { get; set; }

        void SetBinding();
        void Refresh();
        void Clear();
        void Save();
    }

    public class ClearCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event EventHandler CanexecutedChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if (view != null)
            {
                view.Clear();
            }
        }
    }

    public class myCommandSource : UserControl, ICommandSource
    {
        public ICommand Command
        {
            get; set;
        }

        public object CommandParameter
        {
            get; set;
        }

        public IInputElement CommandTarget
        {
            get;set;         
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (CommandTarget!=null)
            {
                Command.Execute(CommandTarget);
            }
        }
    }

}
