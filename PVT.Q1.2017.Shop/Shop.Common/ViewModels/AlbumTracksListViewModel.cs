namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents all tracks list from the album.
    /// </summary>
    public class AlbumTracksListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumTracksListViewModel"/> class.
        /// </summary>
        public AlbumTracksListViewModel()
        {
            Tracks = new List<TrackViewModel>();
        }

        /// <summary>
        /// The album details.
        /// </summary>
        public AlbumDetailsViewModel AlbumDetails { get; set; }

        /// <summary>
        /// All tracks from the album.
        /// </summary>
        public ICollection<TrackViewModel> Tracks { get; set; }
    }
}