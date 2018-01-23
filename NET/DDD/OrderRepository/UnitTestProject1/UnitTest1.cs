using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderRepository.Models;
using OrderRepository;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        public void CreateCustomer()
        {
            Customer c = Customer.CreateCustomer(0, new Name(), new Address(), new Address(), "def", "sdf", DateTime.Now);
            Assert.IsNotNull(c.CreditCard);
        }

    }
}
