using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Model;
using DBRepository.DAL;

namespace DBRepository.Repository
{
    class SysUserRepository : ISysUserRepository
    {
        private XEContext context;

        public SysUserRepository(XEContext context)
        {
            this.context = context;
        }

        public void Add(SysUser user)
        {
            context.SysUsers.Add(user);
        }

        public void Delete(int UseID)
        {
            SysUser user= context.SysUsers.Find(UseID);
            context.SysUsers.Remove(user);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public SysUser GetUserByID(int UseID)
        {
            return context.SysUsers.Find(UseID);
        }

        public IEnumerable<SysUser> GetUsers()
        {
            return context.SysUsers.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(SysUser user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
