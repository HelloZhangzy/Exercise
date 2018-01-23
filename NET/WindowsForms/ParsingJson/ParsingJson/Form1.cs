using DevExpress.XtraTreeList.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Xml;

namespace ParsingJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = richTextBox1.Text;
            Dictionary<string, object> data=JsonHelper.DeserializeJsonToObject<Dictionary<string, object>>(json);
            TreeNode Nodes = new TreeNode();
            ShowJson(treeView1.Nodes, data);

            treeView1.ExpandAll();
            treeList1.OptionsView.ShowColumns = false;            
            TreeListNode node = treeList1.AppendNode(null, -1);
             node.SetValue(treeListColumn1, "Root");
            ShowJson(node, data);
            treeList1.ExpandAll();
        }

        class RowMode
        {
            public int ID;
            public int ParentID;
            public string Name;

        }

        private void ShowJson(TreeListNode node, Dictionary<string, object> data)
        {
            foreach (var item in data)
            {
               if (item.Value is JObject)
                {
                    TreeListNode TN = node.TreeList.AppendNode(item.Key, node);
                    TN.SetValue(0, item.Key);
                    Dictionary<string, object> T = JsonHelper.DeserializeJsonToObject<Dictionary<string, object>>(item.Value.ToString());
                    ShowJson(TN, T);                  
                }
                else
                {
                    TreeListNode temp=  node.TreeList.AppendNode(item.Key, node);
                    if (item.Value == null)
                    {                      
                        temp.SetValue(0, item.Key + " : null");
                    }
                    else
                    {                        
                        temp.SetValue(0, item.Key + " ： " + item.Value.ToString());
                    }
                }
            }
        }

        private DataTable ToList(int ParentID,Dictionary<string, object> json)
        {
            DataTable dt = new DataTable();
            int ID = 1;
            foreach (var item in json)
            {
                if (item.Value is JObject)
                {
                    Dictionary<string, object> T = JsonHelper.DeserializeJsonToObject<Dictionary<string, object>>(item.Value.ToString());
                    //dt.Rows
                    //dt.AddRange(ToList(ID+ParentID * 100, T));
                }
                else
                {
                    RowMode temp = new RowMode();
                    temp.ID = ID + ParentID * 100;
                    temp.ID = ParentID;
                    if (item.Value == null)
                        temp.Name = item.Key + ": Null";
                    else
                        temp.Name = item.Key + " : " + item.Value.ToString();

                    dt.Rows.Add(temp);

                }
                ID++;
            }


            return dt;
        }


        private void ShowJson(TreeNodeCollection node,Dictionary<string, object> data)
        {
            foreach (var item in data)
            {
                if (item.Value==null)
                {
                    node.Add(item.Key+" : null");
                }                
                else if (item.Value is JObject)
                {                  
                    TreeNode TN = new TreeNode(item.Key);                 
                    Dictionary<string, object> T = JsonHelper.DeserializeJsonToObject<Dictionary<string, object>>(item.Value.ToString());
                    ShowJson(TN.Nodes, T);                   
                    node.Add(TN);
                }
                else
                {
                    node.Add(item.Key + " ： " + item.Value.ToString());
                }
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                treeView1.SelectedNode.BeginEdit();
            }
        }
    }

    /// <summary>
    /// Json帮助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }
    }

}
