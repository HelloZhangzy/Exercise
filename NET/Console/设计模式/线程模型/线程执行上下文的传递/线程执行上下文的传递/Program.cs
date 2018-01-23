using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程执行上下文的传递
{
    class Program
    {
        private const string testFile = @"C:\TestContext.txt";

        private static void CreateTestFile()
        {
            if (!File.Exists(testFile))
            {
                FileStream stream = File.Create(testFile);
                stream.Dispose();
            }
        }

        private static void DeleteTestFile()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        // 尝试访问测试文件来测试安全上下文
        private static void JudgePermission(object state)
        {
            try
            {
                // 尝试访问文件
                File.GetCreationTime(testFile);
                // 如果没有异常则测试通过
                Console.WriteLine("权限测试通过");
            }
            catch (SecurityException)
            {
                // 如果出现异常则测试通过
                Console.WriteLine("权限测试没有通过");
            }
            finally
            {
                Console.WriteLine("------------------------");
            }
        }
        static void Main(string[] args)
        {

            try
            {
                CreateTestFile();
                // 测试当前线程的安全上下文
                Console.WriteLine("主线程权限测试：");
                JudgePermission(null);
                // 创建一个子线程 subThread1
                Console.WriteLine("子线程权限测试：");
                Thread subThread1 = new Thread(JudgePermission);
                subThread1.Start();
                subThread1.Join();
                // 现在修改安全上下文，阻止文件访问
                FileIOPermission fip = new FileIOPermission(FileIOPermissionAccess.AllAccess, testFile);
                fip.Deny();
                
               // fip.Demand();
                Console.WriteLine("已成功阻止文件访问");
                // 测试当前线程的安全上下文
                Console.WriteLine("主线程权限测试：");
                JudgePermission(null);
                // 创建一个子线程 subThread2
                Console.WriteLine("子线程权限测试：");
                Thread subThread2 = new Thread(JudgePermission);
                subThread2.Start();
                subThread2.Join();
                // 现在修改安全上下文，允许文件访问
                SecurityPermission.RevertDeny();
                Console.WriteLine("已成功恢复文件访问");
                // 测试当前线程安全上下文
                Console.WriteLine("主线程权限测试：");
                JudgePermission(null);
                // 创建一个子线程 subThread3
                Console.WriteLine("子线程权限测试：");
                Thread subThread3 = new Thread(JudgePermission);
                subThread3.Start();
                subThread3.Join();

                Console.ReadKey();
            }
            finally
            {
                DeleteTestFile();
            }
        }
    }
}
