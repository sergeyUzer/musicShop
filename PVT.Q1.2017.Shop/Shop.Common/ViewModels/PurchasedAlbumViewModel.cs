namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// The purchased album view model.
    /// </summary>
    public class PurchasedAlbumViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasedAlbumViewModel"/> class.
        /// </summary>
        public PurchasedAlbumViewModel()
        {
            Tracks = new List<PurchasedTrackViewModel>();
        }

        /// <summary>
        /// Album id.
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Album name.
        /// </summary>
        [DisplayName("Название")]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Album cover.
        /// </summary>
        public byte[] Cover
        {
            get; set;
        }

        /// <summary>
        /// The Artist. Optional.
        /// </summary>
        [DisplayName("Исполнитель")]
        public ArtistViewModel Artist
        {
            get; set;
        }

        /// <summary>
        /// The tracks from the album.
        /// </summary>
        public ICollection<PurchasedTrackViewModel> Tracks { get; set; }
    }
}