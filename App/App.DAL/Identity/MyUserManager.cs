using Microsoft.AspNet.Identity;
using App.DAL.Entities;

namespace App.DAL.Identity
{
    public class MyUserManager : UserManager<User>
    {
        public MyUserManager(IUserStore<User> ustore):base(ustore)
        {

        }
    }
}
