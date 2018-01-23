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

namespace MSSQ_Receive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MessageQueue mq;

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
            mq.ReceiveCompleted += mq_ReceiveCompleted;
            mq.BeginReceive();
        }


        void mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageQueue mq = (MessageQueue)sender;
            System.Messaging.Message m = mq.EndReceive(e.AsyncResult);
            //处理消息
            string str = m.Body.ToString();
            this.richTextBox1.Invoke(new Action<string>(ShowMsg), str);
           // this.richTextBox1.AppendText(str + Environment.NewLine);

            //继续下一条消息
            mq.BeginReceive();
        }
        private void ShowMsg(string msg)
        {
            this.richTextBox1.AppendText( msg + Environment.NewLine);
            return;
        }
    }
}
