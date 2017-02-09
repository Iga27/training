using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.Entities;
using System.Data.Entity;

namespace App.DAL.EF
{ 
    public class AppContext : IdentityDbContext<User>
     
    {
        public AppContext(string conectionString) : base(conectionString)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }  

        public DbSet<Post> Posts { get; set; }

        public DbSet<GuestBookMessage> GuestBookMessages { get; set; }

        public DbSet<Dialog> Dialogs { get; set; }

        public DbSet<Message> Messages { get; set; }

        /* static AppContext()  //потом удалить
        {
            Database.SetInitializer<AppContext>(new AppDbInitializer());
        } */
    }
        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppContext> //былоIfModelChanges //потом удалить (проверь,не используется ли бд в данный момент)
    {
        protected override void Seed(AppContext db)
        {
             
            db.SaveChanges();
        }
    }   
}
