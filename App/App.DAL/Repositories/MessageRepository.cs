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
    public class MessageRepository: IMessageRepository
    {
         private AppContext db;

        public MessageRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dialog> GetDialogs(string currentUser)  
        {
            return db.Dialogs.Where(m => m.RecipientId==currentUser || m.SenderId==currentUser).Include(m => m.Messages).ToList(); //reader;  
        }

        public int Create(Dialog item)
        {
            db.Dialogs.Add(item);
            return item.DialogId;
        }

        public void AddMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }

    }
}
