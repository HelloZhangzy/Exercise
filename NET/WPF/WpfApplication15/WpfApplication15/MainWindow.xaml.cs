using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApplication15
{
    public class myButton : Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick();
            Window win = Activator.CreateInstance(this.UserWindowType) as Window;
            if (win != null)
            {
                win.ShowDialog();
            }
        }
    }

    public class student:INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name;}      
            set
            {
                name = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Title = "山高月远";
        public static string Title2 { get; set; }
        public static string ShowText { get { return "水落石出"; } }
        student stu;
        public MainWindow()
        {
            InitializeComponent();
            Title = "   山高路远";
            stu = new student();

            Binding bd = new Binding();
            bd.Source = stu;
            bd.Path = new PropertyPath("Name");
            BindingOperations.SetBinding(this.tb_Name, TextBox.TextProperty, bd);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "Name";
        }
    }

   
}
