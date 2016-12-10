using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Entities;

namespace App.DAL.Interfaces
{
    public interface IPostRepository: IRepository<Post>
    {
        IEnumerable<Post> GetAll(int page);
        IEnumerable<Post> GetAll();
        Post Get(int id);
        IEnumerable<Post> Find(Func<Post, Boolean> predicate,int page);

        void Delete(int id);
       //здесь взял Update и delete
        int Count();
    }
}
