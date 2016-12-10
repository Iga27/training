using System;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Interfaces;
using App.DAL.EF;
using App.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.Identity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
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
             try
             {
                 await db.SaveChangesAsync();
             }
             catch (DbEntityValidationException dbEx) //удалить наверн
             {
                 foreach (var validationErrors in dbEx.EntityValidationErrors)
                 {
                     foreach (var validationError in validationErrors.ValidationErrors)
                     {
                         Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                validationErrors.Entry.Entity.GetType().FullName,
                validationError.PropertyName,
                validationError.ErrorMessage);
                     }
                 }
             }
         }

         public void Save()
         {
             //try
             //{
                 db.SaveChanges();
             //}
           /*  catch (OptimisticConcurrencyException)
             {
                 var context = ((IObjectContextAdapter)db).ObjectContext;
                 context.Refresh(RefreshMode.ClientWins, null);  //вместо null нужно что-то подставить(это вроде параметр к самому методу Save)
                 context.SaveChanges();
             }*/
           
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
