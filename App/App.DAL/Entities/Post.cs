using System;
using System.ComponentModel.DataAnnotations;

namespace App.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public DateTime? Date { get; set; }

    }
}
