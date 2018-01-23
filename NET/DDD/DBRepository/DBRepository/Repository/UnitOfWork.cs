using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DBRepository.DAL;
using DBRepository.Repository;
using DBRepository.Model;

namespace DBRepository.Repository
{
    public class UnitOfWork:IDisposable
    {
        private XEContext context = new XEContext();
        private Repository<SysUser> _SysUserRepository;
        private Repository<SysRole> _SysRoleRepository;
        private Repository<SysUserRole> _SysUserRoleRepository;

        public Repository<SysUser> SysUserRepository
        {
            get
            {
                if (this._SysUserRepository == null)
                {
                    this._SysUserRepository = new Repository<SysUser>(context);
                }
                return _SysUserRepository;
            }
        }

        public Repository<SysRole> SysRoleRepository
        {
            get
            {
                if (this._SysRoleRepository == null)
                {
                    this._SysRoleRepository = new Repository<SysRole>(context);
                }
                return _SysRoleRepository;
            }
        }

        public Repository<SysUserRole> SysUserRoleRepository
        {
            get
            {
                if (this._SysUserRoleRepository == null)
                {
                    this._SysUserRoleRepository = new Repository<SysUserRole>(context);
                }
                return _SysUserRoleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
