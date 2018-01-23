using DBRepository.DAL;
using DBRepository.Model;
using DBRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    class Program
    {
        static void Main(string[] args)
        {            
            XEContext db = new XEContext();
            Console.WriteLine("=========== SysUsers ==================");
            var user = db.SysUsers;
            foreach (var item in user)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("=========== SysRole ==================");
            var role = db.SysRoles;
            foreach (var item in role)
            {
                Console.WriteLine(string.Format("ID={0},Name={1},CName={2},Description={3},ModifiedDate={4}", item.ID,item.Name,item.CName,item.Description,item.ModifiedDate));
            }

            Console.WriteLine("=========== SysUserRoles ==================");
            var userRoles = db.SysUserRoles;
            foreach (var item in userRoles)
            {
                Console.WriteLine(string.Format("SysUserID={0},SysRoleID={1},ModifiedDate={2},UserName={3}",item.SysUserID,item.SysRoleID,item.ModifiedDate,item.SysUser.Name));
            }
          

            Console.WriteLine("=========== ISysUserRepository(非泛型仓储) ==================");

            ISysUserRepository userRe = new SysUserRepository(db);

            foreach (var item in userRe.GetUsers())
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("=========== IRepository（泛型仓储） ==================");
            IRepository<SysUser> su = new Repository<SysUser>(db);
            foreach (var item in su.Get())
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("=========== UnitOfWork（处理仓储上下文一致性） ==================");

            UnitOfWork uow = new UnitOfWork();           
            foreach (var item in uow.SysUserRepository.Get())
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("=========== IRepository（泛型仓储） Query ==================");

            foreach (var item in uow.SysUserRepository.Query(t => t.ID > 1).OrderByDescending(i => i.ID))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("=========== IRepository（泛型仓储） Query2 ==================");
            foreach (var item in uow.SysUserRoleRepository.Query(t => t.SysUser.ID == 1))
            {
                Console.WriteLine(item.SysUser.ToString());
            }

            Console.ReadLine();
        }
    }
}
