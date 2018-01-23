using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFist
{
    class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public String UserName { get; set; }
    }
}
