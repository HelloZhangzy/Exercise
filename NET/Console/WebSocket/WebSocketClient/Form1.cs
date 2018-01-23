using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocket4Net;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebSocketClient
{
    public partial class Form1 : Form
    {
        private WebSocket websocket = null;
        public Form1()
        {
            InitializeComponent();
        }        

        private  void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Append(e.Message);
        }

        private  void websocket_Closed(object sender, EventArgs e)
        {
            Append("Server disconnect");          
        }

        private  void websocket_Opened(object sender, EventArgs e)
        {
            Append("Server connect");           
        }

         void Append(string message)
        {
            rtxtData.Invoke(new Action(() =>
            {
                try
                {
                    rtxtData.AppendText(message + "\n");
                    rtxtData.AppendText("\n");
                    rtxtData.ScrollToCaret();
                    if (cbAuto.Checked)
                    {
                        Dictionary<string, object> json = JsonConvert.DeserializeObject<Dictionary<string, object>>(message);
                        if (json.ContainsKey("modulation"))
                        {
                            SendData();
                        }
                        else if (json.ContainsKey("cmd"))
                        {
                            if (json["cmd"].ToString().Trim().ToUpper() == "RX")
                            {
                                SendData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                { }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Url = "";
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Url= "wss://cn1.loriot.io/app?token=vnwCMgAAAA1jbjEubG9yaW90LmlvixEUyS6SAyR1Zrj-tZ3fOQ==";
                        break;
                    case 1:
                        Url = "wss://loraflow.io/v1/application/ws?appeui=1616161616161616&token=1v7rwa77f89de547bd9f10ed54e4a&feedback";
                        break;
                }
                websocket = new WebSocket(Url);
                websocket.Opened += websocket_Opened;
                websocket.Closed += websocket_Closed;
                websocket.MessageReceived += websocket_MessageReceived;
                websocket.Open();
                button1.Enabled = false;
                comboBox1.Enabled = false;
            }
            catch(Exception ex)
            {
                rtxtData.AppendText(ex.Message + "\n");
            }
        }

        private void SendData()
        {
            try
            {
                Dictionary<string, object> Down = new Dictionary<string, object>();
                string message;
                if (comboBox1.SelectedIndex == 0)
                {
                    Down.Add("cmd", "tx");
                    Down.Add("confirmed", cbconfirmed.Checked);
                    Down.Add("EUI", txtEUI.Text.Trim());
                    Down.Add("port", int.Parse(txtPort.Text.Trim()));
                    Down.Add("data", txtData.Text.Trim());
                    message = JsonConvert.SerializeObject(Down);
                }
                else
                {
                    Down.Add("deveui", txtEUI.Text.Trim());
                    Down.Add("fport", int.Parse(txtPort.Text.Trim()));
                    Down.Add("data", txtData.Text.Trim());
                    message = JsonConvert.SerializeObject(Down)+"\n";
                }
                
                //string message = JsonConvert.SerializeObject(Down);
                websocket.Send(message);
                rtxtData.AppendText("Send=>" + message + "\n");
                rtxtData.AppendText("\n");
            }
            catch (Exception ex)
            {
                rtxtData.AppendText(ex.Message + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendData();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtData.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            websocket.Close();
            button1.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void txtData_KeyUp(object sender, KeyEventArgs e)
        {
            lblen.Text = txtData.Text.Length.ToString();
        }
    }
}
