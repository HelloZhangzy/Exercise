namespace OrderRepository.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        [NotMapped]
        public decimal LineAmount { get
            {
                if (this.Order is SalesOrder)
                    return this.Item.SalesPrice * this.Quantity - this.Discount;
                else
                    return -(this.Item.SalesPrice * this.Quantity - this.Discount);
            } }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }

    }
}
