namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents all albums of the artist.
    /// </summary>
    public class ArtistAlbumsListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistAlbumsListViewModel"/> class.
        /// </summary>
        public ArtistAlbumsListViewModel()
        {
            Albums = new List<AlbumViewModel>();
        }

        /// <summary>
        /// The artist details.
        /// </summary>
        public ArtistDetailsViewModel ArtistDetails { get; set; }

        /// <summary>
        /// All albums of the artist.
        /// </summary>
        public ICollection<AlbumViewModel> Albums { get; set; }
    }
}