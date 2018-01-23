using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;

namespace Weather
{
     

    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent();
        }     
        
      
        private static void displaynode(XmlNode node)
        {
            XmlNodeList nodes = node.ChildNodes;
            XmlAttributeCollection att = nodes[0].Attributes;
            foreach (XmlAttribute at in att)
            {
                MessageBox.Show(at.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            //从Google上提取天气信息XML 
            string msXml = wc.DownloadString("http://www.google.com/ig/api?hl=zh_cn&weather=chengdu");
            // MessageBox.Show(msXml);            
            //使用XmlDocument载入天气XML
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(msXml);
                //readxml = XmlTextReader.Create(msXml);
                XmlNodeList nodes = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes;
                //nodes = nodes[1].ChildNodes[0]
                foreach (XmlNode n in nodes)
                {
                    XmlNodeList tnodes = n.ChildNodes;
                    foreach (XmlNode tn in tnodes)
                    {
                        XmlAttributeCollection att = tn.Attributes;
                        foreach (XmlAttribute at in att)
                        {
                            if (n.Name == "forecast_information")
                            {
                                if (tn.Name == "postal_code")
                                {
                                    label1.Text = at.Value.ToString();
                                }                              
                            }
                            if (n.Name == "current_conditions")
                            {
                                if (tn.Name == "condition")//当前状态
                                {
                                    label3.Text ="当前："+ at.Value.ToString();
                                }
                                if (tn.Name == "temp_c")//当前温度
                                {
                                    label2.Text = at.Value.ToString() + "度";
                                }
                                if (tn.Name == "humidity")//湿度
                                {
                                    label5.Text = at.Value.ToString();
                                }
                                if (tn.Name == "icon")//图片
                                {
                                    pictureBox1.LoadAsync("http://www.google.com" + at.Value.ToString());
                                }
                                if (tn.Name == "wind_condition")//风向
                                {
                                    label4.Text = at.Value.ToString();
                                }

                                //- <current_conditions>
                                //<condition data="多云" /> 
                                //<temp_f data="91" /> 
                                //<temp_c data="33" /> 
                                //<humidity data="湿度： 36%" /> 
                                //<icon data="/ig/images/weather/cn_cloudy.gif" /> 
                                //<wind_condition data="风向： 西南、风速：1 米/秒" /> 
                                //</current_conditions>
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }           
    

    }
}
