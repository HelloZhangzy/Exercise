using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class CustomerSnapshot
    {

    }

    public class  Customer
    {
        public string Name;
        public int CustomerNumber;
        public CustomerSnapshot TakeSnapshot()
        {
            return new CustomerSnapshot();
        }
    }

    public  class ReferencePerson
    {

    }

    public class Order
    {
        public DateTime OrderDate;
        public string OrderNumber;
        public Decimal TotalAmount;
        public int OrderType;
        public Order New(int Customer)
        {
            return new Order;
        }
    }

    public class OrderLine
    {
        public decimal Price;
        public int NumberOfUnits;
        public decimal TotalAmount;
    }

    public class Product
    {
        public string Description;
        public decimal unitPrice;
    }

}
