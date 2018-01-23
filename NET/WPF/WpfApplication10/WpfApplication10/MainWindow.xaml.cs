using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApplication10
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        student st;
        public MainWindow()
        {
            InitializeComponent();
            st = new student();

            //Binding bd = new Binding();
            //bd.Source = st;
            //bd.Path = new PropertyPath("name");
            //BindingOperations.SetBinding(this.tb1, TextBox.TextProperty, bd);
            //与上面代码等效
            // this.tb1.SetBinding(TextBox.TextProperty,new Binding("name"){ Source=st=new student()});
            // 与上面代码等同
            this.DataContext = st; //设置数据源，同时编写XAML text="{Binding name}",
            List<student> stuList = new List<student>()
            {
                new student() { id=0,Name2="tim",age=29},
                new student() { id=1,Name2="tom",age=28},
                new student() { id=2,Name2="kyle",age=27},
                new student() { id=3,Name2="tony",age=28},
                new student() { id=4,Name2="Vina",age=25}
            };
            //this.DataContext = stuList;
            this.ListBoxStudents.ItemsSource = stuList;
            this.ListBoxStudents.DisplayMemberPath = "Name2";
            this.ListBoxStudents2.ItemsSource = stuList;
            Binding bd = new Binding("SelectedItem.age") { Source = this.ListBoxStudents };
            this.textBoxID.SetBinding(TextBox.TextProperty, bd);

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            st.name = "Count";
        }
    }

    public class student:INotifyPropertyChanged
    {
       // protected event PropertyChangedEventHandler PropertyChanged;

        
        private int _count=0;
        private string Name;

        public event PropertyChangedEventHandler PropertyChanged;

        public int id { get; set; }
        public int age { get; set; }
        public string Name2 { get; set; }
             
        public string name
        {
            get { return this.Name; }
            set
            {
                ++_count;
                //  name =value
                Name = string.Format("Count:{0}", _count); 
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("name"));

                }
            }
        }
               
    }
}
