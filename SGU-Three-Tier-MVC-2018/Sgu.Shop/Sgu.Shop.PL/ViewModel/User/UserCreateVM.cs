//using Sgu.StudentTesting.PL.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sgu.StudentTesting.PL.ViewModels.User
{
    public class UserCreateVM
    {
        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*(?:-[А-ЯЁ][а-яё]*)?$", ErrorMessage = "Имя должно начинаться с заглавной буквы состоять из символов русского алфавита")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*(?:-[А-ЯЁ][а-яё]*)?$", ErrorMessage = "Фамилия должна начинаться с заглавной буквы состоять из символов русского алфавита")]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*(?:-[А-ЯЁ][а-яё]*)?$", ErrorMessage = "Отчество должно начинаться с заглавной буквы состоять из символов русского алфавита")]
        public string Patronymic { get; set; }

        [MaxLength(50)]
        [Required]
        [Remote("ValidateLogin", "ValidateUser", ErrorMessage = "Данный логин уже зарегестрирован")]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        [Editable(true)]
        public string EMail { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Номер телефона должен иметь формат +xxxx-xxx-xxxx")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
