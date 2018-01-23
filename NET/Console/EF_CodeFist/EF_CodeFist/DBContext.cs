using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFist
{
    class DBContext:DbContext
    {

        public DBContext() : base("name=Demo")
        { }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Order> Orders { get; set; }    
    }
}
