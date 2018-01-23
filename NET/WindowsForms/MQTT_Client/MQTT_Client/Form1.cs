using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace MQTT_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region HTTP URL Declare
        private const string DefaultURL = "http://120.25.158.182:8000/api/v1";
        private const string APPEUID_POST = DefaultURL + "/application";
        private const string APPEUI_Get_DELETE_PUT = DefaultURL + "/application/{0}";
        private const string APPEUI_Select = DefaultURL + "/application/{0:d}/{1:d}";
        private const string CHANNEL_POST = DefaultURL + "/channel";
        private const string CHANNEL_Select = DefaultURL + "/channel/channelList/{0:d}";
        private const string CHANNEL_Get_DELETE_PUT = DefaultURL + "/channel/{0:d}";
        private const string CHANNELIST_POST = DefaultURL + "/channelList";
        private const string CHANNELIST_Get_PUT = DefaultURL + "/channelList/{0:d}";
        private const string CHANNELIST_DELETE = DefaultURL + "/channelList/{0:d}";
        private const string CHANNELIST_SELETE = DefaultURL + "/channelList/{0:d}/{1:d}";
        private const string GATEWAY_POST_CREATE = DefaultURL + "/GATEWAY";
        private const string GATEWAY_GETNODES = DefaultURL + "/GATEWAY/nodes/{0:d}/{1:d}/{2:d}";
        private const string GATEWAY_GET = DefaultURL + "/GATEWAY/{0:d}";
        private const string GATEWAY_SELECT = DefaultURL + "/GATEWAY/{0:d}/{1:d}";
        private const string GATEWAY_POST_BIND = DefaultURL + "/GATEWAYBIND";
        private const string GATEWAY_POST_UNBIND = DefaultURL + "/GATEWAYUNBIND";
        private const string GATEWAY_DELETE = DefaultURL + "/GATEWAY/{0}";
        private const string NODE_POST = DefaultURL + "/node";
        private const string NODE_GET_APP = DefaultURL + "/node/application/{0}/{1:d}/{2:d}";
        private const string NODE_GET_DELETE_PUT_GET = DefaultURL + "/node/{0}";
        private const string NODE_SELECT = DefaultURL + "/node/{0:d}/{1:d}";
        private const string NODESESSION_POST = DefaultURL + "/nodesession";
        private const string NODESESSION_GET_DEVEUI = DefaultURL + "/nodesession/deveui/{0}";
        private const string NODESESSION_GET_PUT_DELETE = DefaultURL + "/nodesession/{0}";
        private const string TOKEN_POST = DefaultURL + "/token";
        private const string USER_POST = DefaultURL + "/user";
        private const string USER_GET_CHECK = DefaultURL + "/user/check/{0}/{1}";
        private const string USER_SELECT = DefaultURL + "/user/{0}/{0}";
        private const string USER_GET_DELETE = DefaultURL + "/user";
        #endregion

        #region MQTT Topic Declare
        private const string TOPIC_TX = "application/{0}/node/{1}/tx";
        private const string TOPIC_RX = "application/{0}/node/{1}/rx";
        private const string TOPIC_RXInfo = "application/{0}/node/{1}/rxinfo";
        private const string TOPIC_JOIN = "application/{0}/node/{1}/join";
        private const string TOPIC_ACK = "application/{0}/node/{1}/ack";
        private const string TOPIC_ERROR = "application/{0}/node/{1}/error";
        #endregion

        MqttClient client;

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                Dictionary<string, object> json = JsonConvert.DeserializeObject<Dictionary<string, object>>( Encoding.Default.GetString(e.Message));               
                if (json.ContainsKey("data"))
                {
                    string strPath = json["data"].ToString();
                    byte[] bpath = Convert.FromBase64String(strPath);
                    strPath = System.Text.ASCIIEncoding.Default.GetString(bpath);
                    json.Add("PlData", strPath);
                    AutoSend();
                }               
                string message = JsonConvert.SerializeObject(json);
                AppendText("MqttMsgPublishReceived Re=>" +message + "\n");
            }
            catch (Exception ex)
            {
                AppendText("MqttMsgPublishReceived Re=>" + ex.Message + "\n");
            }
        }

        public void  client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            try
            {
                AppendText("MqttMsgPublished Re=>" + e.MessageId.ToString() + "\n");
            }
            catch (Exception ex)
            {
                AppendText(" MqttMsgPublished Re=>" + ex.Message + "\n");
            }
        }
        
        public void  client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            try
            {
                AppendText("MqttMsgSubscribed Re=>" + e.MessageId.ToString() + "\n");
            }
            catch (Exception ex)
            {                
                AppendText("MqttMsgSubscribed Re=>" + ex.Message + "\n");
            }
        }

        public void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            try
            {
                AppendText("MqttMsgUnsubscribed Re=>" + e.MessageId.ToString() + "\n");
            }
            catch (Exception ex)
            {
                AppendText("Re=>" + ex.Message + "\n");
            }
        }

        private void AppendText(string message)
        {           
           richTextBox1.Invoke(new Action(() =>{richTextBox1.AppendText(message);}));           
        }

        private void AutoSend()
        {
            button2.Invoke(new Action(() =>
            {
                if (cbAuto.Checked)
                {
                    button2_Click(button2, null); 
                } 
            }));
        }

        private void SubscribeTopic(string DevEui,string AppEui)
        {           
            try
            {
                string[] topics = new string[5];
                topics[0] = string.Format(TOPIC_ERROR, AppEui, DevEui);
                topics[1] = string.Format(TOPIC_RX, AppEui, DevEui);
                topics[2] = string.Format(TOPIC_RXInfo, AppEui, DevEui);
                topics[3] = string.Format(TOPIC_JOIN, AppEui, DevEui);
                topics[4] = string.Format(TOPIC_ACK, AppEui, DevEui);
                foreach (var item in topics)
	            {
                     richTextBox1.AppendText("SubscribeTopic=>" +item+ "\n");		        
	            }
                int re_i = client.Subscribe(topics, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                richTextBox1.AppendText("Our=>" +re_i.ToString() + "\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Our=>"+ex.Message+"\n");
            }
        }

        private void PublishTopic(string DevEui, string AppEui,string Message)
        {
            try
            {

                string strValue = string.Format(TOPIC_TX, AppEui, DevEui);
                richTextBox1.AppendText("PublishTopic=>" + strValue + "\n");
                richTextBox1.AppendText("PublishTopic=>" + Message + "\n");
                int re_i = client.Publish(strValue, Encoding.UTF8.GetBytes(Message));
                richTextBox1.AppendText("Our=>" + re_i.ToString() + "\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Our=>" + ex.Message + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string IP = txtIP.Text;
                client = new MqttClient(IPAddress.Parse(IP));
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                client.MqttMsgPublished += client_MqttMsgPublished;
                client.MqttMsgSubscribed += client_MqttMsgSubscribed;
                client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;
                string clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);
                richTextBox1.AppendText("服务器连接成功！\n");
                //MessageBox.Show("Ok!");
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                richTextBox1.AppendText("服务器连接失败:"+ex.Message+"\n");
                //MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> Message = new Dictionary<string, object>();
            Message.Add("reference",txtreference.Text);            
            Message.Add("confirmed",cbconfirmed.Checked);
            Message.Add("devEUI", txtmqttDevEui.Text);
            Message.Add("fPort",int.Parse(txtfPort.Text));
            byte[] bytedata = Encoding.UTF8.GetBytes(txtdata.Text);
            string strPath = Convert.ToBase64String(bytedata, 0, bytedata.Length);
            Message.Add("data", strPath);
            PublishTopic(txtmqttDevEui.Text, txtmqttAppeui.Text, JsonConvert.SerializeObject(Message));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string DevEui=txtmqttDevEui.Text;
            string AppEui=txtmqttAppeui.Text;             
            SubscribeTopic( DevEui, AppEui);
        }

        private string HttpRequest(string url, string Method, string json)
        {
            try
            {
                richTextBox2.AppendText("URL=>" + url + "\n");
                richTextBox2.AppendText("In=>" + json + "\n");
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/octet-stream";
                httpWebRequest.Method = Method;
                httpWebRequest.Timeout = 20000;
                byte[] btBodys = Encoding.UTF8.GetBytes(json);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();
                httpWebResponse.Close();
                streamReader.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();
                return responseContent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        private string HttpRequest(string url, string Method)
        {
            try
            {
                richTextBox2.AppendText("URL=>" + url + "\n");
                WebRequest we = WebRequest.Create(url);
                we.Method = Method;
                Stream s = we.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.UTF8);
                return sr.ReadToEnd();                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("appEUI", txtAPPEui.Text);
            data.Add("name", txtAPPName.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>"+HttpRequest(APPEUID_POST, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            string url=string.Format(APPEUI_Get_DELETE_PUT,txtAPPEui.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "DELETE"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string url = string.Format(APPEUI_Select,txtAPPOffset.Text,txtAPPLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string url = string.Format(APPEUI_Get_DELETE_PUT, txtAPPEui.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string url = string.Format(APPEUI_Get_DELETE_PUT, txtAPPEui.Text);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("appEUI", txtAPPEui.Text);
            data.Add("name", txtAPPName.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "PUT", JsonConvert.SerializeObject(data)));
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("channel", int.Parse(txtchannel.Text));
            data.Add("channelListID", txtchannelListid.Text);
            data.Add("frequency", txtfrequen.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(CHANNEL_POST, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNEL_Select, txtchannelListid.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNELIST_DELETE, txtchannelListid.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "DELETE"));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNEL_Select, txtchannel.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNEL_Get_DELETE_PUT,txtChannelID);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("channel", int.Parse(txtchannel.Text));
            data.Add("channelListID", txtchannelListid.Text);
            data.Add("frequency", txtfrequen.Text);
            data.Add("id", txtChannelID.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "PUT", JsonConvert.SerializeObject(data)));
        }

        private void button14_Click(object sender, EventArgs e)
        {            
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("name", txtListName.Text);            
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(CHANNELIST_POST, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNELIST_DELETE, txtListID.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "DELETE"));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNELIST_Get_PUT, txtListID.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNELIST_Get_PUT, txtListID.Text);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("name", (txtListName.Text));
            data.Add("id", txtChannelID.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "PUT", JsonConvert.SerializeObject(data)));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string url = string.Format(CHANNELIST_SELETE, txtListOffset.Text, txtListLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("gatewayAddr", txtGWAddr.Text);
            data.Add("gatewayEUI",txtGWEUI.Text );
            data.Add("gatewaySeq", txtGWSeq.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("\nOut=>" + HttpRequest(GATEWAY_POST_CREATE, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string url = string.Format(GATEWAY_SELECT, txtGWOffset.Text , txtGWLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string url = string.Format(GATEWAY_GETNODES, txtgatewayID.Text , txtGWOffset.Text, txtGWLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string url = string.Format(GATEWAY_DELETE, txtGWEUI.Text );
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "DELETE"));
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string url = string.Format(GATEWAY_GET, txtgatewayID.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("gatewayAddr", txtGWAddr.Text);
            data.Add("gatewayEUI", txtGWEUI.Text);
            data.Add("devAddr", txtDevAddr.Text);
            data.Add("devEUI", txtDevEUI.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("\nOut=>" + HttpRequest(GATEWAY_POST_CREATE, "POST", JsonConvert.SerializeObject(data)));        
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("gatewayAddr", txtGWAddr.Text);
            data.Add("gatewayEUI", txtGWEUI.Text);
            data.Add("devAddr", txtDevAddr.Text);
            data.Add("devEUI", txtDevEUI.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("\nOut=>" + HttpRequest(GATEWAY_POST_CREATE, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("appEUI", txtNodeAppEui.Text );
            data.Add("appKey", txtAppKey.Text);
            data.Add("channelListID", txtNodechannelListID.Text);
            data.Add("devEUI", txtNodeDevEui.Text);
            data.Add("rx1DROffset",txtrx1DROffset.Text );
            data.Add("rx2DR", txtrx2DR.Text);
            data.Add("rxDelay", txtrxDelay.Text);
            data.Add("rxWindow", txtrxWindow.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("\nOut=>" + HttpRequest(NODE_POST, "POST", JsonConvert.SerializeObject(data)));
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string url = string.Format(NODE_GET_APP, txtNodeAppEui.Text,txtNodeOffset.Text,txtNodeLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string url = string.Format(NODE_GET_DELETE_PUT_GET, txtNodeDevEui.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "DELETE"));
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string url = string.Format(NODE_GET_DELETE_PUT_GET, txtNodeDevEui.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string url = string.Format(NODE_GET_DELETE_PUT_GET, txtNodeDevEui.Text);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("appEUI", txtNodeAppEui.Text);
            data.Add("appKey", txtAppKey.Text);
            data.Add("channelListID", txtNodechannelListID.Text);
            data.Add("devEUI", txtNodeDevEui.Text);
            data.Add("rx1DROffset", txtrx1DROffset.Text);
            data.Add("rx2DR", txtrx2DR.Text);
            data.Add("rxDelay", txtrxDelay.Text);
            data.Add("rxWindow", txtrxWindow.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("\nOut=>" + HttpRequest(url, "PUT", JsonConvert.SerializeObject(data)));        
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string url = string.Format(NODE_SELECT, txtNodeOffset.Text,txtNodeLimit.Text);
            richTextBox2.Clear();
            richTextBox2.AppendText("Out=>" + HttpRequest(url, "GET"));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client!=null)
               client.Disconnect();                            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
