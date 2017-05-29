namespace Shop.Common.Models
{
    using System.Collections.Generic;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// The currency model.
    /// </summary>
    [Validator(typeof(CurrencyValidator))]
    public class Currency : BaseEntity
    {
        /// <summary>
        /// ISO 4217 litteral code of currency
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Full name of currency
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// ISO 4217 numeric code of currency
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the graphic currency symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Currency rates
        /// </summary>
        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }

        /// <summary>
        /// Target currency rates
        /// </summary>
        public virtual ICollection<CurrencyRate> TargetCurrencyRates { get; set; }

        /// <summary>
        /// Get all users
        /// </summary>
        public virtual ICollection<UserData> Users { get; set; }

        /// <summary>
        /// Get all album prices
        /// </summary>
        public virtual ICollection<AlbumPrice> AlbumPrices { get; set; }

        /// <summary>
        /// Get all track prices
        /// </summary>
        public virtual ICollection<TrackPrice> TrackPrices { get; set; }
    }
}