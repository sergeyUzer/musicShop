namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the albums list where the track exists.
    /// </summary>
    public class TrackAlbumsListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackAlbumsListViewModel"/> class.
        /// </summary>
        public TrackAlbumsListViewModel()
        {
            Albums = new List<AlbumViewModel>();
        }

        /// <summary>
        /// The track details.
        /// </summary>
        public TrackDetailsViewModel TrackDetails { get; set; }

        /// <summary>
        /// All albums where the track exists.
        /// </summary>
        public ICollection<AlbumViewModel> Albums { get; set; }
    }
}