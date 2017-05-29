namespace Shop.Common.Models
{
    using System.Collections.Generic;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// Price level
    /// </summary>
    [Validator(typeof(PriceLevelValidator))]
    public class PriceLevel : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Users 
        /// </summary>
        public virtual ICollection<UserData> Users { get; set; }

        /// <summary>
        /// All track prices related to this price level
        /// </summary>
        public virtual ICollection<TrackPrice> TrackPriceLevels { get; set; }

        /// <summary>
        /// All album prices related to this price level
        /// </summary>
        public virtual ICollection<AlbumPrice> AlbumPriceLevels { get; set; }
    }
}
