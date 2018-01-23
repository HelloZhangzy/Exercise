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

namespace WpfApplication16
{
    public class Student:DependencyObject
    {
        //依赖属性声明
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student));
        public string Name { get; set; }

             
    }

    public class Student2:DependencyObject
    {
       

        //依赖属性声明
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student2));
        public string Name { get { return GetValue(Student2.NameProperty) == null ? "4" : GetValue(NameProperty).ToString(); } set { SetValue(Student2.NameProperty, value); } }

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student2 stu2;
        Student2 stu;
        public MainWindow()
        {
            InitializeComponent();
            stu2 = new Student2();
            stu2.SetBinding(Student2.NameProperty, new Binding("Text") { Source = textbox3 });
            textbox5.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu2 });
           // stu2.Name = "dddd";
            //stu2.GetValue(Student2.NameProperty);
           
            //textbox4.SetBinding(TextBox.TextProperty, new Binding("GetValue(Student2.NameProperty)") {Source = stu2, Mode = BindingMode.OneWay });
            //this.DataContext = stu2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student su = new Student();
            su.SetValue(Student.NameProperty, textbox1.Text);
            textbox2.Text = su.GetValue(Student.NameProperty).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu2.Name);
            //stu = new Student2();
            //stu.SetBinding(Student2.NameProperty, new Binding("Text") { Source = textbox3 });
            //textbox5.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb1.Focus();
        }

        private void tb1_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dd");
        }
    }
}
