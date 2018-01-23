using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 资源文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly(); // 获得当前执行的程序集
            string[] nameArray = asm.GetManifestResourceNames(); // 获得资源名称
            foreach (string name in nameArray)
            {
                richTextBox1.AppendText(name+ "\n");
                richTextBox1.AppendText("------------------\n");
                using (Stream s = asm.GetManifestResourceStream(name))
                {
                    richTextBox1.AppendText(s.Length.ToString()+ "\n");
                }    
                
            }
        }
    }
}
