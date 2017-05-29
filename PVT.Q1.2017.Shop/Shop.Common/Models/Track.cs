namespace Shop.Common.Models
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    /// The track.
    /// </summary>
    [Validator(typeof(TrackValidator))]
    public class Track : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the track release date.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// The track image. Optional.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// The track file. Required. We are selling it!
        /// </summary>
        public byte[] TrackFile { get; set; }

        /// <summary>
        /// The track sample. Optional.
        /// </summary>
        public byte[] TrackSample { get; set; }

        /// <summary>
        /// Gets or sets the track duration.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the artist id.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the genre id.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// The owner id.
        /// </summary>
        public int? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        public virtual Artist Artist { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        public virtual Genre Genre { get; set; }

        /// <summary>
        /// The owner of the track.
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Gets or sets the albums which contain the current track.
        /// </summary>
        public virtual ICollection<AlbumTrackRelation> Albums { get; set; }

        /// <summary>
        /// Gets or sets the track prices.
        /// </summary>
        public virtual ICollection<TrackPrice> TrackPrices { get; set; }

        /// <summary>
        /// Gets or sets all user votes for the current track.
        /// </summary>
        public virtual ICollection<Vote> Votes { get; set; }

        /// <summary>
        /// Gets or sets all user feedbacks the current track.
        /// </summary>
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Carts with this Track
        /// </summary>
        public virtual ICollection<OrderTrack> OrderTracks { get; set; }

        /// <summary>
        /// Users who purchased track
        /// </summary>
        public virtual ICollection<PurchasedTrack> PurchasedTracks { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }
    }
}