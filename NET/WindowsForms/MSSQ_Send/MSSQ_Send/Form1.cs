using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQ_Send
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MessageQueue mq;

        private void button1_Click(object sender, EventArgs e)
        {
            mq.Send(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //新建消息循环队列或连接到已有的消息队列
            string path = ".\\private$\\killf";
            if (MessageQueue.Exists(path))
            {
                mq = new MessageQueue(path);
            }
            else
            {
                mq = MessageQueue.Create(path);
            }
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        }
    }
}
