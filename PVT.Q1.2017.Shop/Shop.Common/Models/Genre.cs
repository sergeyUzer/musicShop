namespace Shop.Common.Models
{
    using System.Collections.Generic;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// The track genre.
    /// </summary>
    [Validator(typeof(GenreValidator))]
    public class Genre : BaseEntity
    {
        /// <summary>
        /// The genre name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        public ICollection<Track> Tracks { get; set; }
    }
}