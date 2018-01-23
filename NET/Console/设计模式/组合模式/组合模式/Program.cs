using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //针对抽象构件编程  
            AbstractFile file1, file2, file3, file4, file5, folder1, folder2, folder3, folder4;

            folder1 = new Folder("Sunny的资料");
            folder2 = new Folder("图像文件");
            folder3 = new Folder("文本文件");
            folder4 = new Folder("视频文件");

            file1 = new ImageFile("小龙女.jpg");
            file2 = new ImageFile("张无忌.gif");
            file3 = new TextFile("九阴真经.txt");
            file4 = new TextFile("葵花宝典.doc");
            file5 = new VideoFile("笑傲江湖.rmvb");

            folder2.add(file1);
            folder2.add(file2);
            folder3.add(file3);
            folder3.add(file4);
            folder4.add(file5);
            folder1.add(folder2);
            folder1.add(folder3);
            folder1.add(folder4);

            //从“Sunny的资料”节点开始进行杀毒操作  
            folder1.killVirus();
            Console.ReadKey();          
        }
    }

    //抽象文件类：抽象构件  
    abstract class AbstractFile
    {
        public abstract void add(AbstractFile file);
        public abstract void remove(AbstractFile file);
        public abstract AbstractFile getChild(int i);
        public abstract void killVirus();
    }

    //图像文件类：叶子构件  
    class ImageFile : AbstractFile
    {
        private String name;

        public ImageFile(String name)
        {
            this.name = name;
        }

        public override void add(AbstractFile file)
        {

            Console.WriteLine("对不起，不支持该方法！");
        }

        public override void remove(AbstractFile file)
        {
            Console.WriteLine("对不起，不支持该方法！");
        }

        public override AbstractFile getChild(int i)
        {
            Console.WriteLine("对不起，不支持该方法！");
            return null;
        }

        public override void killVirus()
        {
            //模拟杀毒  
            Console.WriteLine("----对图像文件'" + name + "'进行杀毒");
        }
    }

    //文本文件类：叶子构件  
    class TextFile : AbstractFile
    {
        private String name;

        public TextFile(String name)
        {
            this.name = name;
        }

        public override void add(AbstractFile file)
        {
            Console.WriteLine("对不起，不支持该方法！");
        }

        public override void remove(AbstractFile file)
        {
            Console.WriteLine("对不起，不支持该方法！");
        }

        public override AbstractFile getChild(int i)
        {
            Console.WriteLine("对不起，不支持该方法！");
            return null;
        }

        public override void killVirus()
        {
            //模拟杀毒  
            Console.WriteLine("----对文本文件'" + name + "'进行杀毒");
        }
    }

    //视频文件类：叶子构件  
    class VideoFile : AbstractFile
    {
        private String name;

        public VideoFile(String name)
        {
            this.name = name;
        }

        public override void add(AbstractFile file)
        {
            Console.WriteLine("对不起，不支持该方法！");
        }

        public override void remove(AbstractFile file)
        {
            Console.WriteLine("对不起，不支持该方法！");
        }

        public override AbstractFile getChild(int i)
        {
            Console.WriteLine("对不起，不支持该方法！");
            return null;
        }

        public override void killVirus()
        {
            //模拟杀毒  
            Console.WriteLine("----对视频文件'" + name + "'进行杀毒");
        }
    }

    //文件夹类：容器构件  
    class Folder : AbstractFile
    {
        //定义集合fileList，用于存储AbstractFile类型的成员  
        private List<AbstractFile> fileList = new List<AbstractFile>();
        private String name;

        public Folder(String name)
        {
            this.name = name;
        }

        public override void add(AbstractFile file)
        {
            fileList.Add(file);
        }

        public override void remove(AbstractFile file)
        {
            fileList.Remove(file);
        }

        public override AbstractFile getChild(int i)
        {
            return (AbstractFile)fileList[i];
        }

        public override void killVirus()
        {
            Console.WriteLine("****对文件夹'" + name + "'进行杀毒");  //模拟杀毒  

            //递归调用成员构件的killVirus()方法  
            foreach (Object obj in fileList)
            {           
                ((AbstractFile)obj).killVirus();
            }
        }
    }
}
