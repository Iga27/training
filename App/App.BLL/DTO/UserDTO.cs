using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      //  public string UserName { get; set; } //логин
        public string Name { get; set; }  //обычное имя
        public int Age { get; set; }
        public string Info { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
