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
         public int Id { get; set; }

         [Required]
         [MaxLength(500, ErrorMessage = "Превышено максимальное число символов")]
         [Display(Name = "Описание")]
         public string Description { get; set; }

         [Required]
         [Display(Name = "Категория")]
         public string Category { get; set; }

         [Required]
         [RegularExpression(@"^[0-9]+$", ErrorMessage = "только целые числа")]
         [Display(Name = "Цена")]
         [Range(0, 999999, ErrorMessage = "Недопустимая цена")]
         public int Price { get; set; }

        [Display(Name = "Дата создания(редактирования)")]
         public DateTime ? Date { get; set; } 

         public string UserId { get; set; } 
    }
}