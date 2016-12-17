using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.Entities;
using System.Data.Entity;

namespace App.DAL.EF
{ //проблема в :DbContext
    public class AppContext : IdentityDbContext<User>
     
    {
        public AppContext(string conectionString) : base(conectionString)
        {
        }
       // public DbSet<User> Users { get; set; }

       // public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }  

        public DbSet<Post> Posts { get; set; }

        public DbSet<GuestBookMessage> GuestBookMessages { get; set; }

        static AppContext()  //потом удалить
        {
            Database.SetInitializer<AppContext>(new AppDbInitializer());
        }
    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppContext> //былоIfModelChanges //потом удалить (проверь,не используется ли бд в данный момент)
    {
        protected override void Seed(AppContext db)
        {
            db.Posts.Add(new Post { Description = "недалеко", Category = "курьерские услуги", Price = 220 });
            db.Posts.Add(new Post { Description = "еда", Category = "курьерские услуги", Price = 820 });
            db.Posts.Add(new Post { Description = "большой пакет", Category = "другое", Price = 880 });
            db.Posts.Add(new Post { Description = "починить кран", Category = "Ремонт", Price = 560 });
            db.SaveChanges();
        }
    }
}
