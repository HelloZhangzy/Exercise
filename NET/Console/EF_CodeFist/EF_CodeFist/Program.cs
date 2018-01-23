using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFist
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建上下文
            DBContext db = new DBContext();
            //创建数据库
            db.Database.CreateIfNotExists();
            Queue<DBContext> DBQ = new Queue<DBContext>();

            //创建表且将字段加入进去
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = "du1";
            //将表加入到数据库中
            db.UserInfo.Add(userInfo);
            //保存之
            db.SaveChanges();
            Console.WriteLine("成功创建数据库和表");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                //Console.WriteLine("Count:{0}==================",i);
                //using(var dbef = new DBContext())
                //{
                //    foreach (var item in dbef.UserInfo.Take(1))
                //    {
                //        Console.WriteLine("ID:{0},Name:{1}", item.ID.ToString(), item.UserName);
                //    }
                //}
                DBQ.Enqueue(new DBContext());
            }
            sw.Stop();
            Console.WriteLine("成功10000,耗时：{0}", sw.ElapsedMilliseconds);
            Console.ReadKey();
            var temp = DBQ.Dequeue();
            foreach (var item in temp.UserInfo)
            {
                Console.WriteLine("ID:{0},Name:{1}", item.ID.ToString(), item.UserName);
            }
            
           
            sw.Reset();
            sw.Start();
            DBContext db2 = new DBContext();
            sw.Stop();
            Console.WriteLine("成功,耗时：{0}", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
