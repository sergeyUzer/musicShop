namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents all tracks and albums of the artist.
    /// </summary>
    public class ArtistContentViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistTracksListViewModel"/> class.
        /// </summary>
        public ArtistContentViewModel()
        {
            Tracks = new List<TrackViewModel>();
            Albums = new List<AlbumViewModel>();
        }

        /// <summary>
        /// The artist details.
        /// </summary>
        public ArtistDetailsViewModel ArtistDetails { get; set; }

        /// <summary>
        /// All tracks of the artist.
        /// </summary>
        public ICollection<TrackViewModel> Tracks { get; set; }

        /// <summary>
        /// All albums of the artist.
        /// </summary>
        public ICollection<AlbumViewModel> Albums { get; set; }
    }
}