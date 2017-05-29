namespace Shop.Common.ViewModels
{
    /// <summary>
    /// The track view model.
    /// </summary>
    public class TrackViewModel
    {
        /// <summary>
        /// Track id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Track name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Track rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// The track artist.
        /// </summary>
        public ArtistViewModel Artist { get; set; }

        /// <summary>
        /// The track price.
        /// </summary>
        public PriceViewModel Price { get; set; }

        /// <summary>
        /// The track album id.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// The album owner id.
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
        /// The track image.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// The number of albums where the current track exist.
        /// </summary>
        public int AlbumsCount { get; set; }
    }
}