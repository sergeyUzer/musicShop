namespace PVT.Q1._2017.Shop.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using global::Shop.Common.Validators;

    /// <summary>
    /// 
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(UserPersonalValidator))]
    public class UserPersonalViewModel
    {
        /// <summary>
        /// Users first name
        /// </summary>
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Users last name
        /// </summary>
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
      
        /// <summary>
        /// Users sex
        /// </summary>
        [Display(Name = "Пол")]
        public string Sex { get; set; }

        /// <summary>
        /// Users birth date
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        [Display(Name = "Страна")]
        //public string Country { get; set; }
        public int? CountryId { get; set; }

        /// <summary>
        /// Users phone
        /// </summary>
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}