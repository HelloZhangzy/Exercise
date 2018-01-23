using AxMPOSUSBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace GWReadCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gw.OnSmitUsbChanged += SmitUsbChanged;
            gw.OnLog += SmitLog;
            gw.OnSmitPosMsg += SmitPosMsg;
        }
        private void AppendData(string Data)
        {
            try
            {
                memoEdit1.Invoke(new Action(() => { memoEdit1.MaskBox.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "==>" + Data + "\n"); memoEdit1.MaskBox.AppendText("\n"); }));
            }
            catch (Exception ex)
            { }
        }

        #region  CMD 声明
        const int MSG_TYPE_DEVICE_INFO=0x4001;// 读设备信息
        const int MSG_TYPE_EX_IC_SET_TYPE=0x2222;//   设置电卡卡类型
        const int MSG_TYPE_EX_IC_CHECK=0x2223;//     电卡检查
        const int MSG_TYPE_EX_IC_POWER_ON=0x2224;//     电卡上电
        const int MSG_TYPE_EX_IC_POWER_OFF=0x2225;//     电卡下电
        const int MSG_TYPE_EX_IC_COMMUNICATION=0x2226;//     电卡通讯
        const int MSG_TYPE_EX_NFC_SET_TYPE=0x2227;//   NFC 设置类型
        const int MSG_TYPE_EX_NFC_POWER_ON=0x2228;//    NFC 上电
        const int MSG_TYPE_EX_NFC_POWER_OFF=0x2229;//  NFC 下电
        const int MSG_TYPE_EX_NFC_COMMUNICATION=0x222A;//   NFC 通讯
        const int MSG_TYPE_EX_PBOC_SET_SIMPLE_PROCESS=0x2246;// NFC 读取卡号
        const int MSG_TYPE_GET_FIRMWARE_INFO=0x400F;//  获取固件信息
        const int MSG_TYPE_UPDATE_FIRMWARE=0x4010;//    固件升级
        const int MSG_TYPE_UPDATE_SCHEDULE=0x4011;//   查询升级进度
        const int MSG_TYPE_XLCARD_EXTERNAL_AUTH=0x6000;//   外部认证
        const int MSG_TYPE_XLCARD_DEVICE_AUTH=0x6001;//  设备认证
        const int MSG_TYPE_XLCARD_GET_TSK=0x6002;//  获取传输密钥
        const int MSG_TYPE_XLCARD_READ_GAS_CARD=0x6003;//  燃气卡读数据
        const int MSG_TYPE_XLCARD_WRITE_GAS_CARD=0x6004;//  燃气卡写数据
        const int MSG_TYPE_XLCARD_VERIFY_GAS_CARD=0x6005;//  燃气卡密码校验
        const int MSG_TYPE_XLCARD_GET_RANDOM=0x6006;// 获取随机数
        const int MSG_TYPE_XLCARD_SYNC_AUTH_KEY=0x6007;//    同步认证密钥
        const int MSG_TYPE_XLCARD_DETECT_GAS_CARD=0x6008;//   检测插卡
        const int MSG_TYPE_XLBUSCARD_INIT=0x6009;//  公交卡初始化
        const int MSG_TYPE_XLBUSCARD_RECORD_QUERY=0x600A;//   公交卡查询记录
        const int MSG_TYPE_XLBUSCARD_CHECK=0x600B;//  公交卡检查可行性
        const int MSG_TYPE_XLBUSCARD_RECHARGE_REQUEST=0x600C;//   公交卡充值申请
        const int MSG_TYPE_XLBUSCARD_RECHARGE=0x600D;//  公交卡充值确认
        #endregion

        #region 反馈值声明
        //00  处理成功
        //01  处理失败
        //60     连接失败
        //61     参数出错
        //62     长度错误
        //64     TYPE错误
        //91     读取数据失败
        //92     读取刷卡数据超时
        //93     读取磁条卡刷卡失败
        //95     外部认证失败
        //96     写数据失败
        //97     公钥灌装失败
        //98     生成密钥对失败
        //99     终端取消交易
        //A0     终端使用IC卡交易
        //70     芯片类型出错
        //71     漏帧出错
        //72     签名帧长度过长
        //73     未签名帧长度过长
        //74     帧数据未加密错误
        //75     帧头帧尾的帧长度不相等
        //76     验签失败
        //10     CRC校验出错
        //11     LRC校验错误
        //12     COMMAND 错误
        //40     有冲正
        //41     无冲正
        //51     解密数据失败
        //52     加密数据失败
        //53     数据重放
        //54     随机数校验失败
        //55     MAC校验失败
        //56     MAC校验失败
        //57     请求刷卡
        //58     带IC芯片卡
        //59  未检测到卡
        //5A 电池电量低
        //5B IC 卡上电失败
        #endregion


        private void ExecCmd(int cmd, string data)
        {
            gw.exec(cmd, data);
        }

        public void SmitUsbChanged(object sender, _DMPOSUSBEvents_OnSmitUsbChangedEvent e)
        {
            AppendData(e.param);
        }

        public void SmitLog(object sender, _DMPOSUSBEvents_OnLogEvent e)
        {
            AppendData(e.message);
        }

        public void SmitPosMsg(object sender, _DMPOSUSBEvents_OnSmitPosMsgEvent e)
        {
            if (e.msgType!=4096)
            {
                AppendData(e.msgData);
            }            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AppendData("Device Init:" + gw.SMiT_POS_Init());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AppendData("Device Num:" + gw.SMiT_POS_Scan().ToString());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            AppendData("Device Connect:" + gw.SMiT_POS_Connect().ToString());
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            AppendData("Device Disconnect:" + gw.SMiT_POS_Disconnect().ToString());
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            AppendData("Device Name:"+ gw.SMiT_POS_GetName());
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            AppendData("Device Version:" + gw.GetVersion());
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            AppendData("Device Deinit:" + gw.SMiT_POS_Deinit());
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            // ExecCmd(MSG_TYPE_DEVICE_INFO, "");
            AppendData("Device Info:" + gw.SMiT_POS_ReadDeviceInfo());
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            string temp = "{\"num\":16}";
            AppendData("Random:" + gw.SMiT_POS_GetRandom(temp));
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ExecCmd(MSG_TYPE_XLCARD_EXTERNAL_AUTH, "");
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            string temp = "{\"pub_key\":\"4A233C40D189C8226B0CA292C785F169E2E71F241B323C3C2D53F2FBBCD5C4216681F49032437F2FA4517912B2010F19430CB60B5136FC4BC7FC0827D961F3256CDBC883D338A13748E8E583B2AC43E8E0DB3A2A44FAA1B70A531AEC79E6F7658DDB1A44F57BAB45FF3EA59482B9948A48BE313FD8662D6EC50A44AAB1984671\"}";
            ExecCmd(MSG_TYPE_XLCARD_GET_TSK, temp);
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            textEdit2.Text = Encrypt_DES16(textEdit1.Text,"12345678");
        }

        static string strKey = "12345678";
        static string strIV = "Edward.K";       

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            textEdit1.Text = Decrypt_DES16(textEdit2.Text,"12345678");
        }

        public static string Encrypt_DES16(string str_in_data, string str_DES_KEY) //数据为十六进制
        {
            try
            {
                byte[] shuju = new byte[8];
                byte[] keys = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    shuju[i] = Convert.ToByte(str_in_data.Substring(i * 2, 2), 16);
                    keys[i] = Convert.ToByte(str_DES_KEY.Substring(i * 2, 2), 16);
                }
                DES desEncrypt = new DESCryptoServiceProvider();
                desEncrypt.Mode = CipherMode.ECB;
                //desEncrypt.Key = ASCIIEncoding.ASCII.GetBytes(str_DES_KEY);
                desEncrypt.Key = keys;
                byte[] Buffer;
                Buffer = shuju;//ASCIIEncoding.ASCII.GetBytes(str_in_data);
                ICryptoTransform transForm = desEncrypt.CreateEncryptor();
                byte[] R;
                R = transForm.TransformFinalBlock(Buffer, 0, Buffer.Length);
                string return_str = "";
                foreach (byte b in R)
                {
                    return_str += b.ToString("X2");
                }
                return_str = return_str.Substring(0, 16);
                return return_str;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string Decrypt_DES16(string str_in_data, string str_DES_KEY)//数据和密钥为十六进制
        {
            byte[] shuju = new byte[8];
            byte[] keys = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                shuju[i] = Convert.ToByte(str_in_data.Substring(i * 2, 2), 16);
                keys[i] = Convert.ToByte(str_DES_KEY.Substring(i * 2, 2), 16);
            }
            DES desDecrypt = new DESCryptoServiceProvider();
            desDecrypt.Mode = CipherMode.ECB;
            desDecrypt.Key = keys;
            desDecrypt.Padding = System.Security.Cryptography.PaddingMode.None;
            byte[] Buffer = shuju;
            ICryptoTransform transForm = desDecrypt.CreateDecryptor();
            byte[] R;
            R = transForm.TransformFinalBlock(Buffer, 0, Buffer.Length);
            string return_str = "";
            foreach (byte b in R)
            {
                return_str += b.ToString("X2");
            }
            return return_str;
        }
    }
}
