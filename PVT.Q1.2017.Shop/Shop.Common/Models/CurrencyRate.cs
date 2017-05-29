namespace Shop.Common.Models
{
    using System;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    ///     The currency rate.
    /// </summary>
    [Validator(typeof(CurrencyRateValidator))]
    public class CurrencyRate : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRate"/> class.
        /// </summary>
        public CurrencyRate()
        {
            Date = DateTime.Today;
        }

        /// <summary>
        ///     Cross course.
        /// </summary>
        public decimal CrossCourse { get; set; }

        /// <summary>
        /// Date of currency rate
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Currency id
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Target currency id
        /// </summary>
        public int TargetCurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        ///     Gets or sets the target currency.
        /// </summary>
        public virtual Currency TargetCurrency { get; set; }
    }
}