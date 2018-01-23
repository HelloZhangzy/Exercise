namespace OrderRepository.Models
{
    using OrderRepository.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Data.Entity.Spatial;
   
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.CreditCard = new HashSet<CreditCard>();
            this.Order = new HashSet<Order>();
            this.Name = new Name();
            this.BillingAddress = new Address();
            this.DeliverAddress = new Address();
        }

        public int Id { get; set; }

        public string LoginName { get; set; }

        public string LoginPassword { get; set; }

        public string DayOfBirth { get; set; }

        public Name Name { get; set; }

        public Address BillingAddress { get; set; }

        public Address DeliverAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditCard> CreditCard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }               
    }
}
