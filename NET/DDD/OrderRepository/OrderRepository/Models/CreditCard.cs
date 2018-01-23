using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace OrderRepository.Models
{
   
    public partial class CreditCard: ICollection
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string HolderName { get; set; }
        public string ExpirationDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
