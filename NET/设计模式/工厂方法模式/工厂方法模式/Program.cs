using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace 工厂方法模式
{
   public interface IFile
    {
        void New();
        void Save();
    }
    public class DocFile:IFile
    {
        public void New()
        {
            Console.WriteLine("New Doc Create");
        }
        public void Save()
        {
            Console.WriteLine("Save Doc");
        }
    }
    public class TxtFile:IFile
    {
        public void New()
        {
            Console.WriteLine("New Txt Create");
        }
        public void Save()
        {
            Console.WriteLine("Save Txt");
        }
    }

    interface IFileFactory
    {
        IFile Create();
    }
    public class DocFileFactory:IFileFactory
    {
        public IFile Create()
        {
            return new DocFile();
        }
    }
    public class TxtFileFactory:IFileFactory
    {
        public IFile Create()
        {
            return new TxtFile();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFile docFile = (new DocFileFactory()).Create();
            IFile txtFile = (new TxtFileFactory()).Create();
            docFile.New();
            docFile.Save();
            txtFile.New();
            txtFile.Save();
            Console.ReadKey();
        }
    }
}
