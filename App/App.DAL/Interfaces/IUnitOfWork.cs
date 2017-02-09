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
        IUserProfileRepository UserProfiles { get; }
       
        IPostRepository Posts { get; }

        IMessageRepository Messages { get; }

        IGuestBookRepository GuestBook { get; }

         Task SaveAsync();

         void Save();
    }
}
