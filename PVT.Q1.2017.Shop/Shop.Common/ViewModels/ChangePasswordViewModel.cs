namespace PVT.Q1._2017.Shop.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using global::Shop.Common.Validators;

    /// <summary>
    /// 
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(ChangePasswordValidator))]
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Old password
        /// </summary>
        [Display(Name = "Старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        /// <summary>
        /// New password
        /// </summary>
        [Display(Name = "Новый пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Confirm new password
        /// </summary>
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}