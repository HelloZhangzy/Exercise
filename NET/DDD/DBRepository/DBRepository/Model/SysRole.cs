using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Model
{
    public class SysRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}
