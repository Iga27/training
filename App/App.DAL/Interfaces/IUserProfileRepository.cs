using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        void Delete(string id);

        UserProfile Get(string id);
    }
}
