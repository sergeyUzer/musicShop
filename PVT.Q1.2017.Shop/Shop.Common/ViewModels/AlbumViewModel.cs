namespace Shop.Common.ViewModels
{
    /// <summary>
    /// The album view model.
    /// </summary>
    public class AlbumViewModel
    {
        /// <summary>
        /// Album id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Album name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Artist. Optional.
        /// </summary>
        public ArtistViewModel Artist { get; set; }

        /// <summary>
        /// Album price.
        /// </summary>
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

        /// <summary>
        /// The album cover.
        /// </summary>
        public byte[] Cover { get; set; }
    }
}