using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTO
{
   public class UserProfileDTO
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Info { get; set; }

        public string CategoriesOfWork { get; set; }

        public string PhoneNumber { get; set; }

        public string File { get; set; }
       // public virtual User User { get; set; }
    }
}
