using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BA_T500_Print_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Com.PortName = cbCom.Text;
            Com.BaudRate = int.Parse(cbBaud.Text);
            Com.Open();
            if (Com.IsOpen)
            {
                button1.Enabled = false;
            }
        }
        private string HexStrToStr(string S)
        {
            int ilen = S.Length;
            string sHex = "";
            string sData = "";           

            while(S.Length>=1)
            {
                if (S.Length<=2)
                {
                    sHex = S;
                    S = "";
                }
                else
                {
                    sHex = S.Substring(0,2);
                    S = S.Substring(2);
                }
               
                int value = Convert.ToInt32(sHex, 16);
                string stringValue = Char.ConvertFromUtf32(value);
                char charValue = (char)value;
                sData += charValue;
            }
            return sData;
        }

        private void SetPrint(string sComm)
        {
            string sData = HexStrToStr(sComm);
            char[] cData = sData.ToCharArray();          
            Com.Write(cData, 0, cData.Length);
            
        }
        private void PrintData(string sData)
        {           
            byte[] cData= Encoding.GetEncoding("GB2312").GetBytes(sData);
            Com.Write(cData, 0, cData.Length);
            SetPrint("a");
        }
        private void button2_Click(object sender, EventArgs e)
        {           
            SetPrint("1b40");
        }

        private void 换行_Click(object sender, EventArgs e)
        {
            SetPrint("a");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetPrint("1b69");            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintData("********************");
            PrintData("----字体测试页面----");
            SetPrint("1b2d1");
            PrintData("fdsakfkldsajklfjlkdsa");
            SetPrint("1b2d2");
            PrintData("fdsakfkldsajklfjlkdsa");
            SetPrint("1b2d0");
            SetPrint("1b451");
            PrintData("fdsakfkldsajklfjlkdsa");
            SetPrint("1b450");
            SetPrint("1b471");
            PrintData("fdsakfkldsajklfjlkdsa");
            SetPrint("1b470");
            SetPrint("1b610");
            PrintData("左对齐");
            SetPrint("1b611");
            PrintData("居中");
            SetPrint("1b612");
            PrintData("右对齐");
            SetPrint("1b610");
            SetPrint("1d2110");
            PrintData("double w");
            SetPrint("1d2100");
            SetPrint("1d2101");
            PrintData("double H");
            SetPrint("1d2100");
            SetPrint("1d2111");
            PrintData("double W H");
            SetPrint("1d2100");
            SetPrint("1d421");
            PrintData("黑底白字");
            SetPrint("1d2111");
            PrintData("黑底白字");
            PrintData("黑底白字");
            SetPrint("1d420");
            SetPrint("1d2100");
            SetPrint("1c2d1");
            PrintData("一点汉字下划线");
            SetPrint("1c2d2");
            PrintData("二点汉字下划线");
            SetPrint("1c2d0");
            SetPrint("1c571");            
            PrintData("四倍角汉字");
            SetPrint("1c570");
            PrintData("********************");            
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("18");
            //Thread.Sleep(3000);
            SetPrint("1b69");
        }

        private void button6_Click(object sender, EventArgs e)
        {          
            SetPrint("1c571");
            SetPrint("1b611");//设置居中           
            PrintData("秦川科技");
            SetPrint("a");            
            SetPrint("1c570");
            SetPrint("1b610");//设置左对齐           
            PrintData("交易编号：201603150000001");
            PrintData("客户编号：QC9568545127");
            PrintData("客户名称：张三");
            PrintData("卡    号：12345678");
            PrintData("充值金额：100");
            PrintData("充值气量：50");
            PrintData("其他费用：80");
            PrintData("交易类型：IC卡充值");
            PrintData("交易时间：" + System.DateTime.Now.ToString());
            PrintData("--------------------------");
            PrintData("支付金额：230");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("a");
            SetPrint("18");
            SetPrint("1b69");
            //Thread.Sleep(3000);
            SetPrint("1d564250");//走纸50毫米后切纸
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetPrint("1b641");
        }
    }

    
}
