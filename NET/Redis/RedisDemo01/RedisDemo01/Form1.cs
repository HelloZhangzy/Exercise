using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using StackExchange.Redis;
using ServiceStack.Redis;

namespace RedisDemo01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_OpenDB_Click(object sender, EventArgs e)
        {
            //RedisClient rc = new RedisClient("",6379,"123456");
            //var t= rc.GetAllKeys();
            //foreach (var item in t)
            //{               
            //    richTextBox1.AppendText(item);
            //}
            //return;
            //System.Diagnostics.Process.Start(@"D:\Program Files\Redis\redis-server.exe");//此处为Redis的存储路径
            lblShow.Text = "Redis已经打开！";
            //RedisManager.GetClient();
            using (var redisClient = RedisManager.GetClient())
            {              
                redisClient.RemoveAll(redisClient.GetAllKeys());
                
                var user = redisClient.GetTypedClient<User>();
                if (user.GetAll().Count > 0)
                    user.DeleteAll();

                var qiujialong = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "qiujialong",
                    Job = new Job { Position = ".NET" }
                };
                var chenxingxing = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "chenxingxing",
                    Job = new Job { Position = ".NET" }
                };
                var luwei = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "luwei",
                    Job = new Job { Position = ".NET" }
                };
                var zhourui = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "zhourui",
                    Job = new Job { Position = "Java" }
                };
                
                var userToStore = new List<User> { qiujialong, chenxingxing, luwei, zhourui };
                user.StoreAll(userToStore);

                lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
            }
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                if (user.GetAll().Count > 0)
                {
                    var htmlStr = string.Empty;
                    foreach (var u in user.GetAll())
                    {
                        htmlStr = "ID=" + u.Id + " 姓名：" + u.Name + " 所在部门：" + u.Job.Position+"\n";
                        richTextBox1.AppendText(htmlStr);
                    }
                }
                lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPosition.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();

                    var newUser = new User
                    {
                        Id = user.GetNextSequence(),
                        Name = txtName.Text,
                        Job = new Job { Position = txtPosition.Text }
                    };
                    var userList = new List<User> { newUser };
                    user.StoreAll(userList);

                    if (user.GetAll().Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in user.GetAll())
                        {
                            htmlStr = "<li>ID=" + u.Id + " 姓名：" + u.Name + " 所在部门：" + u.Job.Position + "</li>" + "\n";
                            richTextBox1.AppendText(htmlStr);
                        }                       
                    }
                    lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRedisId.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();
                    user.DeleteById(txtRedisId.Text);

                    if (user.GetAll().Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in user.GetAll())
                        {
                            htmlStr = "<li>ID=" + u.Id + " 姓名：" + u.Name +  " 所在部门：" + u.Job.Position + "</li>" + "\n";
                            richTextBox1.AppendText(htmlStr);
                        }
                        
                    }
                    lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScreenPosition.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();
                    var userList = user.GetAll().Where(x => x.Job.Position.Contains(txtScreenPosition.Text)).ToList();

                    if (userList.Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in userList)
                        {
                            htmlStr += "<li>ID=" + u.Id + " 姓名：" + u.Name + " 所在部门：" + u.Job.Position + "</li>" + "\n";
                            richTextBox1.AppendText(htmlStr);
                        }                        
                    }
                    lblShow.Text = "筛选后共有：" + userList.Count.ToString() + "人！";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
