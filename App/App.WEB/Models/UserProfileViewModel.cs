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
        public string Id { get; set; }

        [Display(Name = "Меня зовут")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        [Range(0, 200, ErrorMessage = "Недопустимый возраст")]
        public int ? Age { get; set; }

        [Display(Name = "Обо мне")]
        public string Info { get; set; }

        [Display(Name = "Виды выполняемых работ")]
        public string CategoriesOfWork { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string File { get; set; }
    }
}