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
    [FluentValidation.Attributes.Validator(typeof(ForgotPassworValidator))]
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Электронная почта или логин")]
        public string UserIdentity { get; set; }
    }
}