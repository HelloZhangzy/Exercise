using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Model
{
    public class SysUserRole
    {
        [Key,Column(Order=0)]
        [ForeignKey("SysUser")]
        public int SysUserID { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("SysRole")]
        public int SysRoleID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual SysUser SysUser { get; set; }
        public virtual SysRole SysRole { get; set; }             
    }
}
