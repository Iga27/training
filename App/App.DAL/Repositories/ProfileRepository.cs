using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Interfaces;
using App.DAL.Entities;
using App.DAL.EF;
using System.Data.Entity;

namespace App.DAL.Repositories
{
    public class ProfileRepository : IRepository<UserProfile> , IDisposable
    {
         private AppContext db;

         public ProfileRepository(AppContext context)
        {
            this.db = context;
        }

        
         public void Create(UserProfile profile)
        {
            db.UserProfiles.Add(profile);
            db.SaveChanges(); //добавил
        }

         public void Dispose() //это добавил и :IDisposable
         {
             db.Dispose();
         }
     
    }
}
