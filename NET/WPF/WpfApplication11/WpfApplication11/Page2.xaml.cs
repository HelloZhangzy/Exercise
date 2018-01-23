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

namespace WpfApplication11
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        List<student> st = new List<student>()
        {
            new student() {id=0,Name="Tim",Age=29},
            new student() {id=1,Name="Tom",Age=28},
            new student() {id=2,Name="Kyle",Age=27},
            new student() {id=3,Name="Tony",Age=26}
        };
        class student
        {
            public int id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

       
        public Page2()
        {
            InitializeComponent();
            this.DataContext = Enumerable.Range(0, 4).Select(i => new { Id = i, Name = "Name - " + i, Money = 100 });
            this.dataGrid.ItemsSource = ;
        }           

}
}
