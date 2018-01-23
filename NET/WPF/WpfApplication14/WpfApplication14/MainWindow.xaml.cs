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
using System.ComponentModel;
using System.Globalization;

namespace WpfApplication14
{
    
    public class Human
    {
        public string Name { get; set; }
        [TypeConverterAttribute(typeof(strToHuman))]
        public Human Child { get; set; }
    }
    
    public class strToHuman:TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                Human h = new Human();
                h.Name = value as string;
                return h;

            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Human h = (Human)this.TryFindResource("human");
            //MessageBox.Show(h.Name+"    "+h.Child.Name);
        }
    }

    
}
