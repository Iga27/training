using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.WEB.Models
{
    public class UserProfileViewModel
    {

        //возможно здсь не нужны атрибуты(а в DAL)
        public string Id { get; set; }

        [Required]
        [Display(Name = "Меня зовут")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Обо мне")]
        public string Info { get; set; }

        [Required]
        [Display(Name = "Виды выполняемых работ")]
        public string CategoriesOfWork { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string File { get; set; }
    }
}