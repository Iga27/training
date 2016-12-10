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
    public class UserProfileRepository : IUserProfileRepository //, IDisposable
    {
        private AppContext db;

        public UserProfileRepository(AppContext context)
        {
            this.db = context;
        }

        public UserProfile Get(string id)
        {
            return db.UserProfiles.Find(id);
        }
        
        public void Create(UserProfile profile) //вроде не нужен
        {
            db.UserProfiles.Add(profile);
            db.SaveChanges(); //добавил
        }

         public void Update(UserProfile item) //rename in AddOrUpdate
         {

             db.Entry(item).State = EntityState.Modified;
             if(item.File==null)
             db.Entry(item).Property(x => x.File).IsModified = false;
         }

         public void Delete(string id)
         {
             UserProfile userProfile = db.UserProfiles.Find(id);
             if (userProfile != null)
                 db.UserProfiles.Remove(userProfile);
         }


        

        /* public void Dispose() //это добавил и :IDisposable
         {
             db.Dispose();
         }*/
     
    }
}
