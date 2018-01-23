namespace OrderRepository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public partial class DBOrderContext : DbContext
    {
        public DBOrderContext(): base("name=DBOrderContext"){}

        public virtual DbSet<Customer> CustomerSet { get; set; }
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<OrderLine> OrderLineSet { get; set; }
        public virtual DbSet<CreditCard> CreditCardSet { get; set; }
        public virtual DbSet<category> categorySet { get; set; }
        public virtual DbSet<Item> ItemSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}
