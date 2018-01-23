using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFist
{
    class Order
    {
        [Key]
        public int ID { get; set; }

        public string Context { get; set; }

        public UserInfo UserInfo { get; set; }

    }
}
