using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class MyClass
    {
        public static int Add(int x,int y)
        {
            return x + y;
        }
        public  static string GetKey()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            Console.WriteLine(ass.FullName.ToString());
            byte[] pKey = ass.GetName().GetPublicKey();
            byte[] pKeyToken = ass.GetName().GetPublicKeyToken();
            string pKeyString = GetString(pKey);
            string pKeyTokenString = GetString(pKeyToken);
            string result=string.Format("公钥是：{0}\n公钥标识是{1}", pKeyString, pKeyTokenString);
            return result;
        }

        private static string GetString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(string.Format("{0:x}", b));
            }
            return sb.ToString();
        }

    }
}
