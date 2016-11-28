using System;
using System.ComponentModel.DataAnnotations;

namespace App.DAL.Entities
{
     public class Post
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [MaxLength(250, ErrorMessage = "Превышено максимальное число символов")]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }
         [Required]
        public int Price { get; set; }

         
        public string UserId { get; set; } //тип string
         
        public User User { get; set; } 

        //public DateTime Date { get; set; }

    }
}
