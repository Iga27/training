using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "заполните поле Почта")]
        [Display(Name = "Почта")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неправильный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "заполните поле Пароль")]
        [Display(Name = "Ваш пароль")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 16 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "заполните поле Подтверждение пароля")]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "заполните поле Имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }   ///////

        [Required(ErrorMessage = "заполните поле Возраст")]
        [Display(Name = "Ваш возраст")]
        [Range(0, 200, ErrorMessage = "Недопустимый возраст")]
        public int ? Age { get; set; }
       
        
    }
}