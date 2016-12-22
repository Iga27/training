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
    public class PostRepository : IPostRepository
    {
        private AppContext db;

        public int pageSize = 5;
        public PostRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Post> GetAll(int page) //IQueryable
        {
            return db.Posts.Include(m => m.User).OrderByDescending(d => d.Date)  
                .Skip((page-1)*pageSize).Take(pageSize);               
        }

       public IEnumerable<Post> GetAll()
       {
           return db.Posts.Include(m => m.User).OrderByDescending(d => d.Date);       
       }


        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

       public  void Create(Post item)
        {
            db.Posts.Add(item);
        }

       public  IEnumerable<Post> Find(Func<Post, Boolean> predicate,int page)
        {
            return db.Posts.Include(m => m.User).Where(predicate).OrderByDescending(d => d.Date)  
                .Skip((page - 1) * pageSize).Take(pageSize);  
        }
       

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

       public  void Delete(int id)
        {
            Post post=db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);             
        }

        public int Count()
       {
           return db.Posts.Count();
       }

    }
}
