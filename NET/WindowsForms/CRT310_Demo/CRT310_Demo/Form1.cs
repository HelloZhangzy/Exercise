using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CRT310_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbCom.SelectedIndex = 3;
            cbbaund.SelectedIndex = 3;
        }

        private int iComHandle;
        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            
        }

        private void btnYesCard_Click(object sender, EventArgs e)
        {
            int mi = CRT310_DLL_Objects.CRT310_CardSetting(iComHandle, 0x33,0x31);
            MessageBox.Show(mi.ToString());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            int mi=CRT310_DLL_Objects.CRT310_Reset(iComHandle, 0x31);
            MessageBox.Show(mi.ToString());

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            int mi = CRT310_DLL_Objects.CRT310_CardSetting(iComHandle, 0x31, 0x31);
            MessageBox.Show(mi.ToString());
        }

        private void btnInCard_Click(object sender, EventArgs e)
        {

            int mi = CRT310_DLL_Objects.CRT310_CardPosition(iComHandle, 0x33);
            MessageBox.Show(mi.ToString());
        }

        private void btnOutCard_Click(object sender, EventArgs e)
        {
            int mi = CRT310_DLL_Objects.CRT310_MovePosition(iComHandle, 0x30);
            MessageBox.Show(mi.ToString());
        }

        private void btnCheckCard_Click(object sender, EventArgs e)
        {
            byte CardType=0; byte CardInfor=0;
            int mi = CRT310_DLL_Objects.CRT_R_DetectCard(iComHandle,ref CardType,ref CardInfor);
            if (mi==0)
            {
                MessageBox.Show("cardType:" + CardType.ToString() + "，CardInfo:" + CardInfor.ToString() );
            }
            MessageBox.Show(mi.ToString());
        }

        private void btnOpenCard_Click(object sender, EventArgs e)
        {
            int mi = CRT310_DLL_Objects.CRT_IC_CardOpen(iComHandle);
            MessageBox.Show(mi.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mi = CRT310_DLL_Objects.CRT_IC_CloseCard(iComHandle);
            MessageBox.Show(mi.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sPwd;
            byte[] bPwd = new byte[2];
            sPwd = tbData.Text;
            if (sPwd.Length<4)
            {
                return;
            }
            bPwd[0]= Convert.ToByte(sPwd.Substring(0,2), 16);
            bPwd[1] = Convert.ToByte(sPwd.Substring(2, 2), 16);
            int mi = CRT310_DLL_Objects.AT88SC102_VerifyPWD(iComHandle, bPwd);
            MessageBox.Show(mi.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sPwd;
            byte[] bPwd = new byte[2];
            sPwd = tbData.Text;
            if (sPwd.Length < 4)
            {
                return;
            }
            bPwd[0] = Convert.ToByte(sPwd.Substring(0, 2), 16);
            bPwd[1] = Convert.ToByte(sPwd.Substring(2, 2), 16);
            int mi = CRT310_DLL_Objects.AT88SC102_WritePWD(iComHandle,0, bPwd);
            MessageBox.Show(mi.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr bData= Marshal.AllocHGlobal(12); 
            IntPtr bData2= Marshal.AllocHGlobal(10);
            IntPtr bData3= Marshal.AllocHGlobal(10);

            int mi = CRT310_DLL_Objects.AT88SC102_Read(iComHandle,0,2,12, bData);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(Marshal.PtrToStringAnsi(bData));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(b.ToString("x"));
            }
            richTextBox1.AppendText("公共区：" + sb.ToString().Substring(0,24)+"\n");

            mi = CRT310_DLL_Objects.AT88SC102_Read(iComHandle, 1, 22, 10, bData2);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            byte[] ba1 = System.Text.ASCIIEncoding.Default.GetBytes(Marshal.PtrToStringAnsi(bData2));
            StringBuilder sb1 = new StringBuilder();
            foreach (byte b in ba1)
            {
                sb1.Append(b.ToString("x"));
            }                  
            richTextBox1.AppendText("应用区一：" + sb1.ToString().Substring(0, 20) + "\n");

            mi = CRT310_DLL_Objects.AT88SC102_Read(iComHandle, 2, 92, 10, bData3);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            byte[] ba2= System.Text.ASCIIEncoding.Default.GetBytes(Marshal.PtrToStringAnsi(bData3));
            StringBuilder sb2= new StringBuilder();
            foreach (byte b in ba2)
            {
                sb2.Append(b.ToString("x"));
            }
            richTextBox1.AppendText("应用区二：" + sb2.ToString().Substring(0,20) + "\n");
            MessageBox.Show(mi.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sData ="00"+tbData.Text;
            byte[] bData = new byte[10];
            byte[] bData2 = new byte[10];
            byte[] bData3 = new byte[10];
            sData = sData.Substring(sData.Length - 2, 2);
            for (int i = 0; i < 10; i++)
            {
                bData[i] = Convert.ToByte(sData, 16);
                bData2[i] = Convert.ToByte(sData, 16);
                bData2[i] += 1;
                bData3[i] = Convert.ToByte(sData, 16);
                bData3[i] += 2;
            }
            
            int mi = CRT310_DLL_Objects.AT88SC102_Security1Clear(iComHandle, 0, 2, 8);
            mi = CRT310_DLL_Objects.AT88SC102_Write(iComHandle, 0, 2, 8, bData);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            mi = CRT310_DLL_Objects.AT88SC102_Security1Clear(iComHandle, 1, 22, 10);
            mi = CRT310_DLL_Objects.AT88SC102_Write(iComHandle, 1, 22, 10, bData2);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            mi = CRT310_DLL_Objects.AT88SC102_Security1Clear(iComHandle, 2, 92, 10);
            mi = CRT310_DLL_Objects.AT88SC102_Write(iComHandle, 2, 92, 10, bData3);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }            
            MessageBox.Show(mi.ToString());
        }

        private void btnOpenCom_Click_1(object sender, EventArgs e)
        {
            if (cbbaund.SelectedIndex < 0 || cbCom.SelectedIndex < 0)
            {
                return;
            }
            iComHandle = CRT310_DLL_Objects.CommOpenWithBaut(cbCom.Text, uint.Parse(cbbaund.Text));
            if (iComHandle <= 0)
            {
                return;
            }
            else
            {
                btnOpenCom.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sPwd;
            byte[] bPwd = new byte[3];
            sPwd = tb42Data.Text;
            if (sPwd.Length < 6)
            {
                return;
            }
            bPwd[0] = Convert.ToByte(sPwd.Substring(0, 2), 16);
            bPwd[1] = Convert.ToByte(sPwd.Substring(2, 2), 16);
            bPwd[2] = Convert.ToByte(sPwd.Substring(4, 2), 16);
            int mi = CRT310_DLL_Objects.SLE4442_VerifyPWD(iComHandle, bPwd);
            MessageBox.Show(mi.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sPwd;
            byte[] bPwd = new byte[3];
            sPwd = tb42Data.Text;
            if (sPwd.Length < 6)
            {
                return;
            }
            bPwd[0] = Convert.ToByte(sPwd.Substring(0, 2), 16);
            bPwd[1] = Convert.ToByte(sPwd.Substring(2, 2), 16);
            bPwd[2] = Convert.ToByte(sPwd.Substring(4, 2), 16);
            int mi = CRT310_DLL_Objects.SLE4442_WritePWD(iComHandle, bPwd);
            MessageBox.Show(mi.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IntPtr bData = Marshal.AllocHGlobal(20);          

            int mi = CRT310_DLL_Objects.SLE4442_Read(iComHandle,32,20,bData);
            if (mi != 0)
            {
                MessageBox.Show(mi.ToString());
                return;
            }
            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(Marshal.PtrToStringAnsi(bData));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(b.ToString("x"));
            }
            richTextBox1.AppendText("数据：" + sb.ToString().Substring(0, 40) + "\n");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sData = "00" + tbData.Text;
            byte[] bData = new byte[20];            
            sData = sData.Substring(sData.Length - 2, 2);
            for (int i = 0; i < 20; i++)
            {
                bData[i] = Convert.ToByte(sData, 16);              
            }

            int mi = CRT310_DLL_Objects.SLE4442_Write(iComHandle,  32, 20,bData);
            MessageBox.Show(mi.ToString());
        }
    }
}
