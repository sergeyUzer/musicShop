namespace Shop.Common.ViewModels
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The album details view model.
    /// </summary>
    public class AlbumDetailsViewModel
    {
        /// <summary>
        /// Album id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Album name.
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        /// Album cover.
        /// </summary>
        public byte[] Cover { get; set; }

        /// <summary>
        /// Album release date.
        /// </summary>
        [DisplayName("Релиз")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// The Artist. Optional.
        /// </summary>
        [DisplayName("Исполнитель")]
        public ArtistViewModel Artist { get; set; }

        /// <summary>
        /// Album price.
        /// </summary>
        [DisplayName("Стоимость")]
        public PriceViewModel Price { get; set; }

        /// <summary>
        /// The number of the tracks from the album.
        /// </summary>
        public int TracksCount { get; set; }

        /// <summary>
        /// The album owner id.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the album is ordered.
        /// </summary>
        public bool IsOrdered { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the album is purchased.
        /// </summary>
        public bool IsPurchased { get; set; }
    }
}