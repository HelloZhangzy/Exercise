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

namespace WpfApplication18
{
    public class School:DependencyObject
    {
        //propdp 生成依赖属性的完型填空
        //propa 生成附加属性的完型填空
        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GradeProperty);
        }

        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new UIPropertyMetadata(0));
    }

    public class Human:DependencyObject
    {
        
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Human human = new Human();
            School.SetGrade(human, 6);
            int grade = School.GetGrade(human);
            MessageBox.Show(grade.ToString());
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Grid grid = new Grid() { ShowGridLines = true };
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            Button bt = new Button() { Content = "OK"};
            grid.Children.Add(bt);
            Grid.SetRow(bt, 1);
            Grid.SetColumn(bt, 1);
            g1.Children.Add(grid);
            Grid.SetRow(g1, 0);
        }
    }
}
