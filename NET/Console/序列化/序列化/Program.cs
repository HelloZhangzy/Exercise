using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 序列化
{
    [Serializable]
    public class Product
    {
        private int id;
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(int id) { this.id = id; }
        public override string ToString()
        {
            return String.Format("Id:{0}, Name:{1}, Price:{2}",
            this.id, this.Name, this.Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();          
            Product item = new Product(188) { Price = 4998.5F, Name = "Lumia 920" };
            Stream fs = File.OpenWrite(@"D:\product.obj");
            formatter.Serialize(fs, item);
            fs.Dispose();
            Console.ReadKey();
        }
    }
}
