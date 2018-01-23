using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EF_批量插入性能对比
{
    class Program
    {
        static void Main(string[] args)
        {

            GMNS201Entities db = new GMNS201Entities();            
            var sw = new Stopwatch();
            Console.WriteLine("批量插入：EF一次一条\n");
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                MeterResponseSequence temp = new MeterResponseSequence();
                temp.ArrivalsState = 0;
                temp.BusinessState = 0;
                temp.DeviceCode = i;
                temp.SourceID = i;
                temp.MeterID = i;
                temp.UseID = i;
                temp.ExecState = 0;
                db.MeterResponseSequences.Add(temp);
                db.SaveChanges();
                if (i %100 ==0)  Console.Write(".");
            }
            sw.Stop();
            var date = sw.Elapsed;
            Console.WriteLine(string.Format("总耗时：{0}", date.TotalSeconds));
            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("批量插入：EF批量\n");
            sw.Restart();            
            for (int i = 10000; i < 20000; i++)
            {
                MeterResponseSequence temp = new MeterResponseSequence();
                temp.ArrivalsState = 0;
                temp.BusinessState = 0;
                temp.DeviceCode = i;
                temp.SourceID = i;
                temp.MeterID = i;
                temp.UseID = i;
                temp.ExecState = 0;
                db.MeterResponseSequences.Add(temp);
                if (i % 100 == 0) Console.Write(".");
            }
            db.SaveChanges();
            sw.Stop();
            date = sw.Elapsed;
            Console.WriteLine(string.Format("总耗时：{0}", date.TotalSeconds));

            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine("批量插入：EF批量 AutoDetectChangesEnabled 关闭\n");

          //  using (var tr=db.Database.)
           // {
                try
                {

                    db.Configuration.AutoDetectChangesEnabled = false;
                    sw.Restart();
                    for (int i = 10000; i < 20000; i++)
                    {
                        MeterResponseSequence temp = new MeterResponseSequence();
                        temp.ArrivalsState = 0;
                        temp.BusinessState = 0;
                        temp.DeviceCode = i;
                        temp.SourceID = i;
                        temp.MeterID = i;
                        temp.UseID = i;
                        temp.ExecState = 0;
                        db.MeterResponseSequences.Add(temp);
                        if (i % 100 == 0) Console.Write(".");
                    }
                    db.SaveChanges();
                    sw.Stop();
                    date = sw.Elapsed;
                    Console.WriteLine(string.Format("总耗时：{0}", date.TotalSeconds));
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
           // }


            Console.WriteLine("--------------------------------------------\n");

            Console.WriteLine("\n");
            Console.WriteLine("批量插入：拼Sql批量插入\n");
            sw.Restart();           
            var sql = new StringBuilder();
            for (int i = 20000; i < 30000; i++)
            {
                MeterResponseSequence temp = new MeterResponseSequence();
                temp.ArrivalsState = 0;
                temp.BusinessState = 0;
                temp.DeviceCode = i;
                temp.SourceID = i;
                temp.MeterID = i;
                temp.UseID = i;
                temp.ExecState = 0;
                //生成SQL
                sql.Append(BatchAdd(temp));
                if (i % 100 == 0) Console.Write(".");
            }
            //一次性执行SQL           
            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 0;//永不超时
            db.Database.ExecuteSqlCommand(sql.ToString());           
            sw.Stop();
            date = sw.Elapsed;
            Console.WriteLine(string.Format("总耗时：{0}", date.TotalSeconds));


            Console.ReadLine();
        }

        public static string BatchAdd(MeterResponseSequence entity)
        {
            SqlParameter[] paras =
            {
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@DeviceCode",SqlDbType.BigInt),
                new SqlParameter("@UseID",SqlDbType.Int),
                new SqlParameter("@MeterID",SqlDbType.Int),
                new SqlParameter("@ArrivalsState",SqlDbType.Int),
                new SqlParameter("@ExecState",SqlDbType.Int),
                new SqlParameter("@BusinessState",SqlDbType.Int)
            };

            paras[0].Value = entity.SourceID;
            paras[1].Value = entity.DeviceCode;
            paras[2].Value = entity.UseID;
            paras[3].Value = entity.MeterID;
            paras[4].Value = entity.ArrivalsState;
            paras[5].Value = entity.ExecState;
            paras[6].Value = entity.BusinessState;
            var sb = new StringBuilder();
            sb.Append("INSERT INTO [MeterResponseSequence]([SourceID],[DeviceCode],[UseID],[MeterID],[ArrivalsState],[ExecState],[BusinessState])");
            sb.AppendFormat("values ({0},{1},{2},{3},{4},{5},{6})", paras[0].Value, paras[1].Value, paras[2].Value, paras[3].Value, paras[4].Value, paras[5].Value, paras[6].Value);
            return sb.ToString();
        }
    }
}
