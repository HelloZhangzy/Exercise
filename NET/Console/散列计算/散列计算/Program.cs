using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 散列计算
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainText = "Hello, readers";
            // 初始化对象
            // 也可以：SHA1Managed alg = new SHA1Managed();
            HashAlgorithm alg = HashAlgorithm.Create("SHA128");
            // 将字符串转化为字节数组
            byte[] plainData = Encoding.Default.GetBytes(plainText);
            // 获得摘要
            byte[] hashData = alg.ComputeHash(plainData);
            // 输出结果
            foreach (byte b in hashData)
            {
                Console.Write("{0:X2}", b);
            }
            Console.ReadKey();
        }
    }
}
