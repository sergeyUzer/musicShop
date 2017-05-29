namespace PVT.Q1._2017.Shop.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using global::Shop.Common.Models;

    /// <summary>
    /// Rate view model
    /// </summary>
    public class RateViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "Валюта")]
        public IEnumerable<Currency> From { get; set; }

        [Required]
        public int FromId { get; set; }

        [Display(Name = "Целевая валюта")]
        public IEnumerable<Currency> To { get; set; }

        [Required]
        public int ToId { get; set; }

        [Required]
        [Display(Name = "Кросс-курс")]
        public decimal Value { get; set; }

        [Display(Name = "Дата"), Required]
        public DateTime Date { get; set; }
    }
}