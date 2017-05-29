namespace Shop.Common.ViewModels
{
    using System;
    using System.ComponentModel;

    using Shop.Common.Validators.Infrastructure;

    /// <summary>
    /// The track view model.
    /// </summary>
    public class TrackDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the track id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the track name.
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the track release date.
        /// </summary>
        [DisplayName("Релиз")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the track image.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets the track file.
        /// </summary>
        public byte[] TrackSample { get; set; }

        /// <summary>
        /// Gets or sets the track duration.
        /// </summary>
        [DisplayName("Продолжительность")]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// The track artist.
        /// </summary>
        [DisplayName("Исполнитель")]
        public ArtistViewModel Artist { get; set; }

        /// <summary>
        /// The track genre.
        /// </summary>
        [DisplayName("Жанр")]
        public GenreViewModel Genre { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [DisplayName("Стоимость")]
        public PriceViewModel Price { get; set; }

        /// <summary>
        /// Track rating.
        /// </summary>
        public RatingViewModel Rating { get; set; }

        /// <summary>
        /// The number of albums where the current track exist.
        /// </summary>
        public int AlbumsCount { get; set; }

        /// <summary>
        /// The track owner id.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the track is ordered.
        /// </summary>
        public bool IsOrdered { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the track is purchased.
        /// </summary>
        public bool IsPurchased { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }
    }
}