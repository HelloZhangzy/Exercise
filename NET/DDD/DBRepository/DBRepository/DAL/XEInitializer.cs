using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DBRepository.Model;

namespace DBRepository.DAL
{
    public class XEInitializer:CreateDatabaseIfNotExists<XEContext>
    {
        protected override void Seed(XEContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser{ ID=1,Name="ZS",CName="张三",Email="zs@aaa.com",Password="1",ModifiedDate=DateTime.Now},
                new SysUser{ ID=2,Name="LS",CName="李四",Email="ls@aaa.com",Password="1",ModifiedDate=DateTime.Now},
                new SysUser{ ID=3,Name="WW",CName="王五",Email="ww@aaa.com",Password="1",ModifiedDate=DateTime.Now}
            };
            context.SysUsers.AddRange(sysUsers);
           // context.SaveChanges();

            var sysRoles = new List<SysRole>
            {
                new SysRole{ID=1,Name="Admin",CName="管理员",Description="administrarors have full authorization to Perform system administration.",ModifiedDate=DateTime.Now},
                new SysRole{ID=2,Name="General Users",CName="一般用户",Description="General Users can access the shared data they are authorized for.",ModifiedDate=DateTime.Now}
            };
            context.SysRoles.AddRange(sysRoles);
            //context.SaveChanges();

            var sysUserRoles = new List<SysUserRole>
            {
                new SysUserRole{ SysUserID=1,SysRoleID=1,ModifiedDate=DateTime.Now},
                new SysUserRole{ SysUserID=1,SysRoleID=2,ModifiedDate=DateTime.Now},
                new SysUserRole{ SysUserID=2,SysRoleID=1,ModifiedDate=DateTime.Now},
                new SysUserRole{ SysUserID=3,SysRoleID=2,ModifiedDate=DateTime.Now}
            };
            context.SysUserRoles.AddRange(sysUserRoles);
            context.SaveChanges();
            //base.Seed(context);
        }            
    }
}
