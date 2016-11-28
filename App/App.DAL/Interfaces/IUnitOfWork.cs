using System;
using App.DAL.Entities;
using App.DAL.Identity;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        MyUserManager Users { get; }

        MyRoleManager Roles { get; }
        IRepository<UserProfile> Profiles { get; }
       
        IPostRepository Posts { get; } 

         Task SaveAsync();

         void Save();
    }
}
