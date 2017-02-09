using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Dialog> GetDialogs(string currentUser); 

        int Create(Dialog item);

        void AddMessage(Message message);
    }
}
