using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "заполните поле Почта")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "заполните поле Пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}