using System;
using System.Threading.Tasks;
using App.DAL.Interfaces;
using App.DAL.EF;
using App.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.Identity;
using System.Data.Entity.Validation;
using System.Diagnostics;
 
using System.Data.Entity.Infrastructure;

namespace App.DAL.Repositories
{
     public class AppUnitOfWork : IUnitOfWork
    {
          AppContext db;

          MyUserManager userRepository;

          MyRoleManager roleRepository;

          UserProfileRepository profileRepository;

          PostRepository postRepository;

          GuestBookRepository guestBookRepository;

         public AppUnitOfWork(string connectionString) 
         {
             this.db = new AppContext(connectionString);
         }

          

         public IPostRepository Posts
         {
             get 
             {
                 if (postRepository == null)
                     postRepository = new PostRepository(db);
                 return postRepository;
             }       
         }

         public IGuestBookRepository GuestBook
         {
             get
             {
                 if (guestBookRepository == null)
                     guestBookRepository = new GuestBookRepository(db);
                 return guestBookRepository;
             }
         }
         public IUserProfileRepository UserProfiles
         {
             get
             {
                 if (profileRepository == null)
                     profileRepository = new UserProfileRepository(db);
                 return profileRepository;
             }
         }
         public MyUserManager Users
         {
             get
             {
                 if (userRepository == null)
                     userRepository = new MyUserManager(new UserStore<User>(db));
                 return userRepository;
             }
         }
         public MyRoleManager Roles
         {
             get
             {
                 if (roleRepository == null)
                     roleRepository = new MyRoleManager(new RoleStore<Role>(db));
                 return roleRepository;
             }
         }

         public async Task SaveAsync()
         {           
                 await db.SaveChangesAsync();            
         }

         public void Save()
         {
                 db.SaveChanges();           
         }

         private bool disposed = false;

         public virtual void Dispose(bool disposing)
         {
             if (!this.disposed)
             {
                 if (disposing)
                 {
                     db.Dispose();
                 }
                 this.disposed = true;
             }
         }

         public void Dispose()
         {
             Dispose(true);
             GC.SuppressFinalize(this);
         }
    }
}
