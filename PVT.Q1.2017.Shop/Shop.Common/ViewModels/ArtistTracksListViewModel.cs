namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents all tracks of the artist.
    /// </summary>
    public class ArtistTracksListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistTracksListViewModel"/> class.
        /// </summary>
        public ArtistTracksListViewModel()
        {
            Tracks = new List<TrackViewModel>();
        }

        /// <summary>
        /// The artist details.
        /// </summary>
        public ArtistDetailsViewModel ArtistDetails { get; set; }

        /// <summary>
        /// All tracks of the artist.
        /// </summary>
        public ICollection<TrackViewModel> Tracks { get; set; }
    }
}