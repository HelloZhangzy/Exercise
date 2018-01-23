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

namespace WpfApplication19
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.gridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.buttonRight_Click));
            this.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedhandler));
            Student2.AddNameChangeHandler(this, new RoutedEventHandler(this.StudentNameChangedhandler2));
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
        }

        private void timeButton_ReportTime(object sender, ReportTimeEventArgs e)
        {            
            string timeStr = e.ClickTime.ToString("yyyy-mm-dd HH:mm:ss");
            string content = string.Format("{0}到达{1}", timeStr, (sender as FrameworkElement).Name);
            this.ListBox.Items.Add(content);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student() { id = 101, Name = "Tim" };
            stu.Name = "Tom";
            RoutedEventArgs arg = new RoutedEventArgs(Student.NameChangedEvent, stu);
            button1.RaiseEvent(arg);
        }

        private void StudentNameChangedhandler(object sender,RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student).id.ToString());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Student2 stu = new Student2() { id = 101, Name = "Tim" };
            stu.Name = "Tom";
            RoutedEventArgs arg = new RoutedEventArgs(Student2.NameChangedEvent, stu);
            button2.RaiseEvent(arg);
        }

        private void StudentNameChangedhandler2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student2).id.ToString());
        }
    }

    class ReportTimeEventArgs:RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent,source) { }
        public DateTime ClickTime { get; set; }
    }

   public class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Direct, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));

        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);            
        }
    }

    public class Student
    {
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(Student));

        public int id { get; set; }
        public string Name { get; set; }
    }

    public class Student2
    {
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(Student2));
        public static void AddNameChangeHandler(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e!=null)
            {
                e.AddHandler(Student2.NameChangedEvent, h);
            }
        }
        public static void RemoveNameChangeHandler(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e!=null)
            {
                e.RemoveHandler(Student2.NameChangedEvent, h);
            }
        }
        public int id { get; set; }
        public string Name { get; set; }
    }
}
