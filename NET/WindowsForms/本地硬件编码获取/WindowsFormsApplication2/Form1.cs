using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            string FileString = @"d:\TR.ini";
            if (File.Exists(FileString))
            {
                //FileStream fs=new FileStream()
                File.Delete(FileString);
            }                                    
            FileStream fi=File.Create(FileString);
            fi.Close();                                
            File.SetAttributes(FileString, FileAttributes.Hidden| FileAttributes.System);                           
        }        


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = GetHardDiskSerialNumber();
        }       

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = getLocalMac();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = GetCPUSerialNumber();
        }
        //获取CPU序列号
        public string GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Processor");
                string sCPUSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sCPUSerialNumber = mo["ProcessorId"].ToString().Trim();
                }
                return sCPUSerialNumber;
            }
            catch
            {
                return "";
            }
        }

        public string GetHardDiskSerialNumber()
        {
            try
            {

                string sHardDiskSerialNumber = "";                
                ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                ManagementObjectCollection mocHD = mcHD.GetInstances();
                foreach (ManagementObject m in mocHD)
                {                    
                    if (m["DeviceID"].ToString() == "D:" || m["DeviceID"].ToString() == "E:")
                    {
                        sHardDiskSerialNumber += m["VolumeSerialNumber"].ToString();
                    }
                }
                return sHardDiskSerialNumber.Trim();
            }
            catch
            {
                return "";
            }
        }


        public string getLocalMac()
        {
            string mac = null;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac += mo["MacAddress"].ToString() + "  ";
            }
            return (mac);
        }

        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns></returns>
        public string GetPhysicalMemory()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }
            return st;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = GetPhysicalMemory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text=RSAEncrypt("",textBox1.Text);
        }



        /// RSA加密(公钥加密)
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string publickey, string content)
        {
            publickey = @"<RSAKeyValue><Modulus>1q2Vm6BUtigEE9lq/pRJhYr117pyuRp34jc/ZU3d5Bg/exqpEFyAAH5BHlfAwFO+i40mw8hOchwyQKyXXUi7n+OlsnO4qrTa0YL4IEkJkyNJ/eevRSTFhH3VRzuSaNjF7PQ8eo9LR373FJo2znmIckikA8Yjs6glt30cxvObhA8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA解密（私钥解密）
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string privatekey, string content)
        {
            privatekey = @"<RSAKeyValue><Modulus>1q2Vm6BUtigEE9lq/pRJhYr117pyuRp34jc/ZU3d5Bg/exqpEFyAAH5BHlfAwFO+i40mw8hOchwyQKyXXUi7n+OlsnO4qrTa0YL4IEkJkyNJ/eevRSTFhH3VRzuSaNjF7PQ8eo9LR373FJo2znmIckikA8Yjs6glt30cxvObhA8=</Modulus><Exponent>AQAB</Exponent><P>96z2G8BlKdpN4MvGq8APGmZd23viXgHJ/SD9LBAeV93CIJMteVzoflv8JDbMFhWWn8giykbwmjDeH9GkVpwcUQ==</P><Q>3eS0/RhV3fAwvDXAaoHVzH1Kk+IVlJoRSbcDdjEbDRVBxzhI3fr76pQ9JaPji+nTQXr08mWn7muf0nX3p/ZiXw==</Q><DP>V8VyvijzcN6NRMHSWSFJ+OgYEOUZNolZxJvBPLFFn4vV9OdTcTPsrIL6mvbUYmsqItuxAJAdSfdRcGNB4vOV0Q==</DP><DQ>xxcX1SbqlFGYSKap2GZaIDoimgF2f3ilHlDZCEkTDnAOLuOvbYxuT5FmM8mStsy7wbrC4GKZhHCIW9uAs/F7XQ==</DQ><InverseQ>yDuqtxBK89fNCLkioZ97UC3RjBNYzzWwLGJ1MPJnXP1MBbzIrhrheIr42XiL9rYUR+kFZADi/mKgsKng7CEdQg==</InverseQ><D>oNAVYyf+bRmavFfAy4W/cXb/5CM57ylBpsamCbgDwOrdGtWE0cnI5RWuqBEqRag184nAAScahGZUype/J1TlnmeDX2MWnw7wTHkRef9ND1sVeW8Q0BgEl0qm/ey5oSdNVeBJBNT40D/e0QjoiP4CG7Z9JzOL8lh0ThOOzYgSwuE=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = RSADecrypt("", textBox2.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] keys = new string[2];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            textBox1.Text = rsa.ToXmlString(true);//私钥
            textBox2.Text = rsa.ToXmlString(false);//公钥
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }

}
