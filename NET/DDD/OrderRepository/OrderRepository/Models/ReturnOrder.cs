namespace OrderRepository.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReturnOrder:Order
    {
        public System.DateTime returnDate { get; set; }
        public string reasson { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
    }
}
