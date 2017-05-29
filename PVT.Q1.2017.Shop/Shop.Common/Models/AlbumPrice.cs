namespace Shop.Common.Models
{
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// The album price.
    /// </summary>
    [Validator(typeof(AlbumPriceValidator))]
    public class AlbumPrice : BaseEntity
    {
        /// <summary>
        /// Price for album
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Album id
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Price level id
        /// </summary>
        public int PriceLevelId { get; set; }

        /// <summary>
        /// Currency id
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Album"/>.
        /// </summary>
        public virtual Album Album { get; set; }

        /// <summary>
        /// Get or set <see cref="PriceLevel"/>
        /// </summary>
        public virtual PriceLevel PriceLevel { get; set; }

        /// <summary>
        /// The currency.
        /// </summary>
        public virtual Currency Currency { get; set; }
    }
}