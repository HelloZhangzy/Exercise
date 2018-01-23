using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
            worker.WorkerReportsProgress = true;//报告完成进度
            worker.WorkerSupportsCancellation = true;//允许用户终止后台线程

            worker.DoWork += (sender, e) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i, i);
                }
            };
            worker.ProgressChanged += (sender, e) =>
            {
                Console.WriteLine(string.Format("完成百分比。。。{0}", e.ProgressPercentage));
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                if (!e.Cancelled && e.Error == null)
                {
                    Console.WriteLine("处理成功，请按任意键返回。");
                }

                else
                {
                    Console.WriteLine("处理中断，请按任意键返回。");
                }
            };
            worker.RunWorkerAsync();
            Console.Read();
        }
    }
}
