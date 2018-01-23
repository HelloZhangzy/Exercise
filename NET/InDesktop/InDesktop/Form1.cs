using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;  

namespace InDesktop
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent); 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr pWnd = FindWindow("Progman", null);
            pWnd = FindWindowEx(pWnd, IntPtr.Zero, "SHELLDLL_DefVIew", null);
            pWnd = FindWindowEx(pWnd, IntPtr.Zero, "SysListView32", null);
            SetParent(this.Handle, pWnd);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Groups.Clear();
            listView1.Items.Clear();
            listView1.View = View.LargeIcon;
            ColumnHeader columnHeader0 = new ColumnHeader();
            columnHeader0.Text = "Title";
            columnHeader0.Width = 200;
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Author";
            columnHeader1.Width = 200;
            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Year";
            columnHeader2.Width = 100;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2 });
            ListViewGroup group1 = new ListViewGroup("001");
            ListViewGroup group2 = new ListViewGroup("002");
            listView1.Groups.Add(group1);
            listView1.Groups.Add(group2);

            // Create items and add them to myListView.
            ListViewItem item0 = new ListViewItem(new string[] { "Programming Windows", "Petzold, Charles", "1998" }, 0, group1);
            ListViewItem item1 = new ListViewItem(new string[] 
            {"Code: The Hidden Language of Computer Hardware and Software",
            "Petzold, Charles",
            "2000"}, 0, group1);
            ListViewItem item2 = new ListViewItem(new string[] { "Programming Windows with C#", "Petzold, Charles", "2001" }, 0, group1);
            ListViewItem item3 = new ListViewItem(new string[] 
            {"Coding Techniques for Microsoft Visual Basic .NET", "Connell, John",
            "2001"}, 1, group2);
            ListViewItem item4 = new ListViewItem(new string[] 
            {"C# for Java Developers", "Jones, Allen & Freeman, Adam",
            "2002"}, 1, group2);
            ListViewItem item5 = new ListViewItem(new string[] 
            {"Microsoft .NET XML Web Services Step by Step",
            "Jones, Allen & Freeman, Adam",
            "2002"}, 1, group2);
            listView1.Items.AddRange(
                new ListViewItem[] { item0, item1, item2, item3, item4, item5 });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

    }
}
