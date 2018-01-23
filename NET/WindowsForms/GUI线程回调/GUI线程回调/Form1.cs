using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI线程回调
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GUIThreadHelper.GUISyncContext = System.Threading.SynchronizationContext.Current;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread tr = new Thread(new ThreadStart(()=> {
                GUIThreadHelper.SyncContextCallback(() =>
                {
                    this.txtMessage.Text = "Test";
                    this.btnTest.Text = "DoTest";
                    this.btnTest.Enabled = true;
                });
            }));
            tr.Start();
        }
    }
}
