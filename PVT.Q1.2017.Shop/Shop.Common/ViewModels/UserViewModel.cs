namespace Shop.Common.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Validators;
    using Models;

    /// <summary>
    /// 
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(UserRegistrationValidator))]
    public class UserViewModel
    {
        /// <summary>
        /// Users login (nickname)
        /// </summary>
        [Display(Name = "Логин")]
        [Remote("IsLoginUnique", "Account", "User", ErrorMessage = "Такой логин уже существует")]
        public string Login { get; set; }

        /// <summary>
        /// Users password
        /// </summary>
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Confirm password
        /// </summary>
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Users e-mail
        /// </summary>
        [Display(Name = "Адрес почты")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailUnique", "Account", "User", ErrorMessage = "Такой адрес уже зарегистрирован в магазине")]
        public string Email { get; set; }   
    }
}