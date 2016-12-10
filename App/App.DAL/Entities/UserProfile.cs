using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Info{ get; set; }

        public string CategoriesOfWork { get; set; }

       // [Required]
        public virtual  User User { get; set; } //может и не виртуал

        // [HiddenInput(DisplayValue = false)]
        public string File { get; set; }

    }
}
