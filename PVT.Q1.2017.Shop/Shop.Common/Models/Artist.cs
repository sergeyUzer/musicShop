namespace Shop.Common.Models
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// The artist.
    /// </summary>
    [Validator(typeof(ArtistValidator))]
    public class Artist : BaseEntity
    {
        /// <summary>
        /// Artist name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Artist biography.
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Artist birthday.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Artist photo.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// All tracks of the current artist.
        /// </summary>
        public virtual ICollection<Track> Tracks { get; set; }

        /// <summary>
        /// All albums of the current artist.
        /// </summary>
        public virtual ICollection<Album> Albums { get; set; }
    }
}