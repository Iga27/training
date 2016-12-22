using App.DAL.Entities;
using System;
using System.Collections.Generic;
 

namespace App.DAL.Interfaces
{
    public interface IGuestBookRepository
    {
        IEnumerable<GuestBookMessage> GetAll();

        void Add(GuestBookMessage gb);
    }
}
