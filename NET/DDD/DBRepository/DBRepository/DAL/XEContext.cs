using DBRepository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.DAL
{
    public class XEContext : DbContext
    {
        public XEContext():base("DBStr")
        {
            Console.WriteLine("DBStr");
        }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove< PluralizingTableNameConvention> ();

            //Database.SetInitializer<XEContext>(new XEInitializer());
        }
    }
}
