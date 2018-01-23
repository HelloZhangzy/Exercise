using HtmlParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;


namespace HtmlParse
{
    public partial class Form1 : Form
    {
        ParseTread pt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="")
            {
                return;
            }
            richTextBox1.Clear();
            pt = new ParseTread();
            pt.url = textBox1.Text.Trim();
            pt.OnReturnHref += new ParseTread.ReturnHref(ReturnHref);
            pt.Statr();
        }

        private void ReturnHref(string href)
        {
            this.BeginInvoke(new Action(delegate { richTextBox1.AppendText(href+"\n"); }));            
        }

        private void btnParser_Click(object sender, EventArgs e)
        {
            #region 获得网页的html
            try
            {
                richTextBox1.Text = "";
                string url = textBox1.Text.Trim();
                System.Net.WebClient aWebClient = new System.Net.WebClient();               
                aWebClient.Encoding = Encoding.GetEncoding("GBK");
                string html = Encoding.UTF8.GetString(aWebClient.DownloadData(url));
                richTextBox1.Text = html;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            #region 分析网页html节点
            Lexer lexer = new Lexer(this.richTextBox1.Text);
            Parser parser = new Parser(lexer);
            NodeList htmlNodes = parser.Parse(null);
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add("root");
            TreeNode treeRoot = this.treeView1.Nodes[0];
           for (int i = 0; i < htmlNodes.Count; i++)
            {
                this.RecursionHtmlNode(treeRoot, htmlNodes[i], false);
            }

            #endregion

        }

        private void RecursionHtmlNode(TreeNode treeNode, INode htmlNode, bool siblingRequired)
        {
            if (htmlNode == null || treeNode == null) return;
            //http://www.biquge.cc

            TreeNode current = treeNode;
            TreeNode content;
            //current node
            if (htmlNode is ITag)
            {
                ITag tag = (htmlNode as ITag);
                if (!tag.IsEndTag())
                {
                    string nodeString = tag.TagName;
                    if (tag.Attributes != null && tag.Attributes.Count > 0)
                    {                        
                        if (tag.Attributes["HREF"] != null && nodeString=="A")
                        {
                            if (tag.Children!=null)
                            {                               
                               string Txt="Null";
                               Txt = tag.Children.ToHtml().ToString().Trim();
                                
                                if (Txt.Substring(0, 1) != "<")
                                {
                                    nodeString = nodeString + "  Txt=" + Txt + " href=\"" + tag.Attributes["HREF"].ToString() + "\"";
                                }
                                else
                                    nodeString = "";

                            }
                            else
                                nodeString = nodeString + "  Txt=Null "+ " href=\"" + tag.Attributes["HREF"].ToString() + "\"";

                            //nodeString = tag.Children.ToHtml().ToString();
                            //((Winista.Text.HtmlParser.Tags.CompositeTag)tag).ChildrenHTML
                            if (!string.IsNullOrEmpty(nodeString))
                            {
                                current = new TreeNode(nodeString.Trim());
                                treeNode.Nodes.Add(current);
                            }
                            
                        }
                    }

                    
                }
            }
            //////获取节点间的内容
            if (htmlNode.Children != null && htmlNode.Children.Count > 0)
            {
                this.RecursionHtmlNode(current, htmlNode.FirstChild, true);
                //content = new TreeNode(htmlNode.FirstChild.GetText());
                //treeNode.Nodes.Add(content);
            }

            //////the sibling nodes
            if (siblingRequired)
            {
                INode sibling = htmlNode.NextSibling;
                while (sibling != null)
                {
                    this.RecursionHtmlNode(treeNode, sibling, false);
                    sibling = sibling.NextSibling;
                }
            }
        }
    }

    public class ParseTread
    {
        private bool StopTread = true;
        public string url { get; set; }
        public delegate void ReturnHref(string href);
        public event ReturnHref OnReturnHref;
        Thread td;

        public ParseTread()
        {
            td = new Thread(new ThreadStart(ScanLinks));
        }
       
        public void Statr()
        {
            StopTread = false;
            td.Start();
        }

        protected void ScanLinks()
        {
            try
            {
               //http://www.biquge.cc
                WebClient client = new WebClient();
                client.Encoding = Encoding.GetEncoding("GBK");
                string html = Encoding.UTF8.GetString(client.DownloadData(url)); 
                HtmlTag tag;
                HtmlParseClass parse = new HtmlParseClass(html);
                while (parse.ParseNext("a", out tag))
                {
                    while (StopTread)
                    {
                        break;
                    }
                    string value;
                    if (tag.Attributes.TryGetValue("href", out value))
                    {
                        if (string.IsNullOrEmpty(value.Trim()))
                        {
                            continue;
                        }
                        DoReturnHref(value.Trim());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Stop()
        {
            StopTread = true;
            td.Abort();
        }

        public void DoReturnHref(string href)
        {
            OnReturnHref?.Invoke(href);
        }
    }
}
