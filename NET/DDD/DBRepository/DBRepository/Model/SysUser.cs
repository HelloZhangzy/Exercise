using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Model
{
   public partial class SysUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<SysUserRole> SysUserRoles { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0},Name={1},CName={2},Email={3},ModifieDate={4}", ID, Name, CName, Email, ModifiedDate);
        }
    }
}
