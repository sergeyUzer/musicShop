namespace Shop.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Validators;
    using ViewModels;
    /// <summary>
    /// 
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(LoginViewValidator))]
    public class LoginViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Электронная почта или логин")]
        [Remote("IsUserNotExist", "Account", "User", ErrorMessage = "Такой пользователь не зарегистрирован в магазине")]
        public string UserIdentity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}