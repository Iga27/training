using App.DAL.EF;
using App.DAL.Entities;
using App.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class GuestBookRepository: IGuestBookRepository
    {
        private AppContext db;

        public GuestBookRepository(AppContext context)
        {
            this.db = context;
        }
        public IEnumerable<GuestBookMessage> GetAll()
        {
            return db.GuestBookMessages.OrderByDescending(m=>m.WhenAdded);
        }

        public void Add(GuestBookMessage gb)
        {
            db.GuestBookMessages.Add(gb);
            db.SaveChanges();
        }
    }
}
