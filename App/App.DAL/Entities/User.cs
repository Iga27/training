using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace App.DAL.Entities
{
     public class User : IdentityUser
    {
        public ICollection<Post> Posts { get; set; } //это добавил(возможно нужно virtual)
        public virtual UserProfile UserProfile { get; set; }
    }
}
