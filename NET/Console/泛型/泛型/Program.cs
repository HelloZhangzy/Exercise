using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    public class SortHelper<T>
    {
        public void BubbleSort(T[] array)
        {            
            int length = array.Length;
            for (int i = 0; i <= length - 2; i++)
            {
                for (int j = length - 1; j >= 1; j--)
                {                    
                    // 对两个元素进行交换
                    //if (Convert.ToInt32(array[j]) < Convert.ToInt32(array[j-1]))
                    //{
                    //    T temp = array[j];
                    //    array[j] = array[j - 1];
                    //    array[j - 1] = temp;
                    //}
                }
            }
        }
    }

    public class Book:IComparable
    {
        private int price;
        private string title;
        public Book() { }
        public Book(int price, string title)
        {
            this.price = price;
            this.title = title;
        }
        public int Price { get { return this.price; } }
        public string Title { get { return this.title; } }

        public int CompareTo(object obj)
        {
            Book book2 = (Book)obj;
            return this.Price.CompareTo(book2.Price);
        }
    }
    class Program
    {

        const int ListSize = 500000;

        static void Main(string[] args)
        {
            SortHelper<byte> sort = new SortHelper<byte>();
            byte[] array = { 8, 1, 4, 7, 3 };
            sort.BubbleSort(array);
            string sTemp = "";
            Console.WriteLine(array.Count());
            for (int i = 0; i < array.Count(); i++)
            {
                sTemp += array[i].ToString()+"  ";
            }

            Console.WriteLine(sTemp);

            Console.WriteLine((100).ToString("X4"));


            Console.WriteLine("---------------------------------");

            Book[] bookArray = new Book[2];
            Book book1 = new Book(30, "HTML5 解析 ");
            Book book2 = new Book(21, "JavaScript 实战 ");
            bookArray[0] = book1;
            bookArray[1] = book2;
            SortHelper<Book> sorter = new SortHelper<Book>();
            sorter.BubbleSort(bookArray);
            foreach (Book b in bookArray)
            {
                Console.WriteLine("Price:{0}", b.Price);
                Console.WriteLine("Title:{0}\n", b.Title);
            }

            UseArrayList();
            UseGenericList();          

            Console.ReadKey();
        }
        private static void UseArrayList()
        {
            ArrayList list = new ArrayList();
            long startTicks = DateTime.Now.Ticks;
            for (int i = 0; i < ListSize; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < ListSize; i++)
            {
                int value = (int)list[i];
            }
            long endTicks = DateTime.Now.Ticks;
            Console.WriteLine("使用ArrayList，耗时：{0} ticks", endTicks - startTicks);
        }
        private static void UseGenericList()
        {
            List<int> list = new List<int>();
            long startTicks = DateTime.Now.Ticks;
            for (int i = 0; i < ListSize; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < ListSize; i++)
            {
                int value = list[i];
            }
            long endTicks = DateTime.Now.Ticks;
            Console.WriteLine("使用List<int>，耗时：{0} ticks", endTicks - startTicks);
        }
        public void BubbleSort<T>(T[] array)
        {
            int length = array.Length;
            for (int i = 0; i <= length - 2; i++)
            {
                for (int j = length - 1; j >= 1; j--)
                {
                    //// 对两个元素进行交换
                    //if (array[j]. array[j - 1])
                    //{
                    //    T temp = array[j];
                    //    array[j] = array[j - 1];
                    //    array[j - 1] = temp;
                    //}
                }
            }
        }
    }
}
