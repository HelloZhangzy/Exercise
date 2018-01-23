using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    public class Product
    {
        public int Id { get; set; } // 自增ID
        public string Name { get; set; } // 名称
        public string Code { get; set; } // 主键
        public string Category { get; set; } // 类型
        public decimal Price { get; set; } // 价格
        public DateTime ProduceDate { get; set; } // 生产日期
        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}",
            this.Id.ToString().PadLeft(2), this.Category.PadLeft(15),
            this.Code.PadLeft(7), this.Name.PadLeft(17), this.Price.ToString().PadLeft(8),
            this.ProduceDate.ToString("yyyy-M-d").PadLeft(13));
        }
        public static ProductCollection GetSampleCollection()
        {
            ProductCollection collection = new ProductCollection(
            new Product { Id = 1, Code = "1001", Category = "Red Wine", Name = "Torres Coronas", Price = 285.5m, ProduceDate = DateTime.Parse("1997-12-8") },
            new Product { Id = 3, Code = "2001", Category = "White Spirit", Name = "Mao Tai", Price = 1680m, ProduceDate = DateTime.Parse("2001-5-8") },
            new Product { Id = 4, Code = "2013", Category = "White Spirit", Name = "Wu Liang Ye", Price = 1260m, ProduceDate = DateTime.Parse("2005-8-1") },
            new Product { Id = 8, Code = "3001", Category = "Beer", Name = "TSINGTAO", Price = 6.5m, ProduceDate = DateTime.Parse("2012-4-21") },
            new Product { Id = 11, Code = "1003", Category = "Red Wine", Name = "Borie Noaillan", Price = 468m, ProduceDate = DateTime.Parse("1995-7-6") },
            new Product { Id = 15, Code = "1007", Category = "Red Wine", Name = "Pinot Noir Rose", Price = 710m, ProduceDate = DateTime.Parse("1988-9-10") },
            new Product { Id = 17, Code = "3009", Category = "Beer", Name = "Kingway", Price = 5.5m, ProduceDate = DateTime.Parse("2012-6-13") }
            );
            return collection;
        }
    }

    public class ProductCollection : IEnumerable<Product>
    {
        private Hashtable table;
        public ProductCollection()
        {
            table = new Hashtable();
        }
        public ProductCollection(params Product[] array)
        {
            table = new Hashtable();
            foreach (Product item in array)
            {
                this.Add(item);
            }
        }
        public ICollection Keys
        {
            get { return table.Keys; }
        }
        private string getKey(int index)
        {
            if (index < 0 || index > table.Keys.Count)
                throw new Exception("索引超出了范围");
            string selected = "";
            int i = 0;
            foreach (string key in table.Keys)
            {
                if (i == index)
                {
                    selected = key;
                    break;
                }
                i++;
            }
            return selected;
        }
        public Product this[int index]
        {
            get
            {
                string key = getKey(index);
                return table[key] as Product;
            }
            set
            {
                string key = getKey(index);
                table[key] = value;
            }
        }
        private string getKey(string key)
        {
            foreach (string k in table.Keys)
            {
                if (key == k)
                {
                    return key;
                }
            }
            throw new Exception("不存在此键值");
        }
        public Product this[string key]
        {
            get
            {
                string selected = getKey(key);
                return table[selected] as Product;
            }
            set
            {
                string selected = getKey(key);
                table.Remove(table[selected]);
                this.Add(value);
            }
        }
        public void Add(Product item)
        {
            // 确保Key不能重复
            foreach (string key in table.Keys)
            {
                if (key == item.Code)
                    throw new Exception("产品代码不能重复");
            }
            table.Add(item.Code, item);
        }
        public void Insert(int index, Product item) { }
        public bool Remove(Product item) { return true; }
        public bool RemoveAt(int index) { return true; }
        public void Clear() { table.Clear(); }

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ProductEnumerator(this);
        }

        public int Count { get { return table.Keys.Count; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProductCollection col = Product.GetSampleCollection();
            foreach (Product item in col)
            {
                string line = item.ToString();
                Console.WriteLine(line);
            }
            //for (int i = 0; i <= col.Count - 1; i++)
            //{
            //    string line = col[i].ToString();
            //    Console.WriteLine(line);
            //}
            Console.ReadKey();
        }
    }
}
