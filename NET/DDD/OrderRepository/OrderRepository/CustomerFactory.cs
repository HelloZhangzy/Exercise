using OrderRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepository
{
    public partial class Customer
    {
        //internal override bool IsChangeTracked => throw new NotImplementedException();

        public static Customer CreateCustomer(global::System.Int32 id, Name name, Address billingAddress,
                                            Address deliveryAddress, global::System.String loginName,
                                            global::System.String loginPassword, global::System.DateTime dayOfBirth)
        {
            Customer customer = new Customer();
            customer.Id = id;

            customer.Name = name;

            customer.BillingAddress = billingAddress;

            customer.DeliverAddress = deliveryAddress;

            customer.LoginName = loginName;
            customer.LoginPassword = loginPassword;
            customer.DayOfBirth = dayOfBirth.ToString();
            return customer;
        }       
    }
}
