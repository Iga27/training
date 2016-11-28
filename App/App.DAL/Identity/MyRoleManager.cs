using App.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//repository
namespace App.DAL.Identity
{
    public class MyRoleManager: RoleManager<Role>
    {
        public MyRoleManager(RoleStore<Role> rstore) : base(rstore)
        {

        }
    }
}
