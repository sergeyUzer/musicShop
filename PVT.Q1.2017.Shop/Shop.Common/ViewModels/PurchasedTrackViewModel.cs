namespace Shop.Common.ViewModels
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The purchased track view model.
    /// </summary>
    public class PurchasedTrackViewModel
    {
        /// <summary>
        /// Track id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Track name.
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Track rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the track release date.
        /// </summary>
        [DisplayName("Релиз")]
        public DateTime? ReleaseDate { get; set; }

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
        /// The track media file.
        /// </summary>
        public byte[] TrackFile { get; set; }

        /// <summary>
        /// The track image. Optional.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets the track file name.
        /// </summary>
        public string FileName { get; set; }
    }
}