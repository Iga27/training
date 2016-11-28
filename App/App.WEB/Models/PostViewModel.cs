using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.WEB.Models
{
    public class PostViewModel
    {
         //[ScaffoldColumn(false)]
       // [HiddenInput(DisplayValue = false)]
       // [Key]
        //может убрать его вообще из ViewModel
        public int Id { get; set; }
         [Required]
         [Display(Name = "Описание")]
         public string Description { get; set; }
         [Required]
         [Display(Name = "Категория")]
         public string Category { get; set; }
         [Required]
         [Display(Name = "Бюджет")]
         public int Price { get; set; }

        

        // [ScaffoldColumn(false)]
       // [HiddenInput(DisplayValue = false)]
        //[Key]
         public string UserId { get; set; } //? скрытое должно быть

     //   public DateTime? Date { get; set; } //////////
    }
}