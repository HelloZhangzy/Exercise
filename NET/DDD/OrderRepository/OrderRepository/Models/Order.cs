using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OrderRepository.Models
{    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderLine = new HashSet<OrderLine>();
        }

        public int Id { get; set; }

        public System.DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }

        public virtual Customer Customer { get; set; }

        [NotMapped]
        public Single TotalDiscount
        {
            get
            {
                return 0;// this.OrderLine.Count()
            }
        }

        [NotMapped]
        public Single TotalAmount
        {
            get
            {
                return 0;// this.Lines.Sum(p => p.LineAmount);
            }
        }

        Guid IEntity.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
