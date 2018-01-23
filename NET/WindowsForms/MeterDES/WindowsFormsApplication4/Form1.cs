using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {

        [DllImport("DES.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void DESCrypt(int niMeterType, byte mode, byte[] keyData, byte[] fromData, IntPtr toData);


        [DllImport("DES.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void BlockMAC(int niMeterType, byte[] plain, IntPtr MAC);

        [DllImport("DES.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int GetCRC16_mod(byte[] addr, int length);

        public Form1()
        {
            InitializeComponent();
        }

        protected int DecryptData(string Factor, string Data, string Key, ref string Mac, ref string Result)
        {
            if (Factor.Trim().Count()%16!=0 || Data.Trim().Count()%16!=0)
            {
                return 0;
            }
            byte[] mbKey = new byte[8];
            byte[] mbMac = new byte[8];
            byte[] mbCiphertext = new byte[8];
            byte[] mbPlaintext = new byte[8];
            IntPtr IPtr = Marshal.AllocHGlobal(10);
            string msPlaintext = "";
            try
            {
                //因子
                string msRandom = Factor.Trim();
                //密钥
                string msDESKey = "0000000000000000" + Convert.ToString(Convert.ToInt64(Key.Trim()), 16);
                msDESKey = msDESKey.Substring(msDESKey.Count() - 16);
                //数据
                string msData = Data.Trim();
                int mi = msData.Count();
                StrToHex(msDESKey, 8, ref mbKey);


                StrToHex(msRandom, 8, ref mbCiphertext);

                DESCrypt(0, 1, mbKey, mbCiphertext, IPtr);
                InPtrToHex(IPtr, 8, ref mbPlaintext);
                Array.Copy(mbPlaintext, mbMac, 8);
               // for (int i = 0; i < 8; i++) mbMac[i] = mbPlaintext[i];

                for (int i = 0; i < mi / 16; i++)
                {
                    StrToHex(msData.Substring(i * 16, 16), 8, ref mbCiphertext);
                    BlockMAC(0, mbCiphertext, IPtr);
                    InPtrToHex(IPtr, 8, ref mbMac);
                    DESCrypt(0, 0, mbKey, mbCiphertext, IPtr);
                    InPtrToHex(IPtr, 8, ref mbPlaintext);
                    msPlaintext += HexToStr(mbPlaintext);
                }

                Result = msPlaintext.ToUpper();
                Mac = HexToStr(mbMac).ToUpper();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Marshal.FreeHGlobal(IPtr);
            }
                
            
        }
        protected int EncryptData(string Factor, string Data, string Key, ref string MAC, ref string Result)
        {
            if (Factor.Trim().Count() % 16 != 0 || Data.Trim().Count() % 16 != 0)
            {
                return 0;
            }

            byte[] mbMac = new byte[8];
            byte[] mbKey = new byte[8];
            byte[] mbPlaintext = new byte[8];
            byte[] mbCiphertext = new byte[8];
            IntPtr IPtr = Marshal.AllocHGlobal(10);  
            string msCommandStr = "";
            string msMac = "";

            try
            {
                string msBlockType = "0000000000000000" + Factor.Trim();
                string msKey = "0000000000000000" + Convert.ToString(Convert.ToInt64(Key.Trim()), 16); 
                string msData = "0000000000000000" + Data.Trim();
                int iLen = msData.Count();
                int iHexCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble((double)Data.Trim().Count() / (double)16)));

                msKey = msKey.Substring(msKey.Count() - 16);
                msBlockType = msBlockType.Substring(msBlockType.Count() - 16);

                msData = msData.Substring(iLen - iHexCount * 16);

                StrToHex(msBlockType, 8, ref mbMac);
                StrToHex(msKey, 8, ref mbKey);
                DESCrypt(0, 1, mbKey, mbMac, IPtr);
                InPtrToHex(IPtr, 8, ref mbPlaintext);
                for (int i = 0; i < 8; i++) mbMac[i] = mbPlaintext[i];
                for (int i = 0; i < iHexCount; i++)
                {
                    StrToHex(msData.Substring(i * 16, 16), 8, ref mbPlaintext);
                    DESCrypt(0, 1, mbKey, mbPlaintext, IPtr);
                    InPtrToHex(IPtr, 8, ref mbCiphertext);
                    msCommandStr += HexToStr(mbCiphertext);
                    Marshal.Copy(mbMac, 0, IPtr, 8);
                    BlockMAC(0, mbCiphertext, IPtr);
                    InPtrToHex(IPtr, 8, ref mbMac);
                }
                msMac = HexToStr(mbMac);

                Result = msCommandStr.ToUpper();
                MAC = msMac.ToUpper();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Marshal.FreeHGlobal(IPtr);
            }
        }

        protected int GeneratedCRC(string Data)
        {
            if (Data.Trim().Count()%2!=0)
            {
                return -1;
            }
            byte[] bCrc = new byte[Data.Count() / 2+2];

            StrToHex(Data.Trim(), bCrc.Count() - 2, ref bCrc);

            bCrc[bCrc.Count() - 2] = 0x00;
            bCrc[bCrc.Count() - 1] = 0x00;           

            return GetCRC16_mod(bCrc, bCrc.Count());
        }


        private void StrToHex(string Data,int iLen,ref byte[] OutData)
        {
            string msTemp="";
            for (int i = 0; i < iLen; i++)
            {
                msTemp = Data.Substring(i * 2, 2);
                OutData[i] = Convert.ToByte(msTemp, 16);
            }
        }

        private string HexToStr(byte[] Data)
        {
            string OutData = "";
            string msTemp = "";
            for (int j = 0; j < Data.Count(); j++)
            { 
                msTemp = "00"+Convert.ToString(Data[j], 16);
                msTemp = msTemp.Substring(msTemp.Count() - 2);
                OutData += msTemp;
            }
            return OutData;
        }
        private void InPtrToHex(IntPtr Data,int iLen,ref byte[] OutData )
        {
            for (int i = 0; i < iLen; i++)
            {
                OutData[i] = Marshal.ReadByte(Data, i);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Mac = "", OutData = "";
            if (DecryptData(textBox2.Text, textBox3.Text, textBox1.Text, ref Mac, ref OutData) == 1)
            {
                textBox4.Text = OutData;
                //textBox5.Text = Mac;
                label6.Text = Mac;
            }
            else
                textBox5.Text = "解密失败";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Mac = "", OutData = "";
            if (EncryptData(textBox2.Text, textBox3.Text, textBox1.Text, ref Mac, ref OutData) == 1)
            {
                textBox4.Text = OutData;
                textBox5.Text = Mac;
                
            }
            else
                textBox5.Text = "加密失败";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iCrc = GeneratedCRC(textBox3.Text.Trim()); 

            label6.Text = Convert.ToString(iCrc,16);
        }
    }
}
