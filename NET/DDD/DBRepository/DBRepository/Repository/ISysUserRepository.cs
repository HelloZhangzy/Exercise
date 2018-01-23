using DBRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
   public  interface ISysUserRepository:IDisposable
    {
        IEnumerable<SysUser> GetUsers();
        SysUser GetUserByID(int UseID);

        void Add(SysUser user);
        void Update(SysUser user);
        void Delete(int UseID);

        void Save();
    }
}
