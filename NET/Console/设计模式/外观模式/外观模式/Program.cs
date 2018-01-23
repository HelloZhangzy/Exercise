using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 外观模式
{
    class Program
    {
        static void Main(string[] args)
        {
            EncryptFacade ef = new EncryptFacade();
            ef.FileEncrypt("src.txt", "des.txt");
            Console.Read();
        }
    }

    class FileReader
    {
        public string Read(string fileNameSrc)
        {
            Console.Write("读取文件，获取明文：");
            FileStream fs = null;
            StringBuilder sb = new StringBuilder();
            try
            {               
                Console.WriteLine(fileNameSrc);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("文件不存在！");
            }
            catch (IOException e)
            {
                Console.WriteLine("文件操作错误！");
            }
            return fileNameSrc;
        }
    }

    class CipherMachine
    {
        public string Encrypt(string plainText)
        {
            Console.Write("数据加密，将明文转换为密文：");
            string es = "";
            char[] chars = plainText.ToCharArray();
            foreach (char ch in chars)
            {
                string c = (ch % 7).ToString();
                es += c;
            }
            Console.WriteLine(es);
            return es;
        }
    }

    class FileWriter
    {
        public void Write(string encryptStr, string fileNameDes)
        {
            Console.WriteLine("保存密文，写入文件。");
            FileStream fs = null;
            try
            {
                Console.WriteLine(encryptStr);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("文件不存在！");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("文件操作错误！");
            }
        }
    }

    class EncryptFacade
    {
        //维持对其他对象的引用  
        private FileReader reader;
        private CipherMachine cipher;
        private FileWriter writer;

        public EncryptFacade()
        {
            reader = new FileReader();
            cipher = new CipherMachine();
            writer = new FileWriter();
        }

        //调用其他对象的业务方法  
        public void FileEncrypt(string fileNameSrc, string fileNameDes)
        {
            string plainStr = reader.Read(fileNameSrc);
            string encryptStr = cipher.Encrypt(plainStr);
            writer.Write(encryptStr, fileNameDes);
        }
    }
}
