namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// CartView model
    /// </summary>
    public class CartViewModel
    {
        /// <summary>
        /// Gets or sets a Collection of tracks for View
        /// </summary>
        public int CurrentUserId { get; set; }

        /// <summary>
        /// Gets or sets a Collection of tracks for View
        /// </summary>
        public ICollection<TrackDetailsViewModel> Tracks { get; set; }

        /// <summary>
        /// Gets or sets a Collection of Albums for View
        /// </summary>
        public ICollection<AlbumDetailsViewModel> Albums { get; set; }

        /// <summary>
        /// Get total price of cart
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Get currency short name
        /// </summary>
        public string CurrencyShortName { get; set; }

        /// <summary>
        /// Cart is empty or not
        /// </summary>
        public bool IsEmpty { get; set; }

        public CartViewModel()
        {
            Tracks = new List<TrackDetailsViewModel>();
            Albums = new List<AlbumDetailsViewModel>();
            IsEmpty = true;
        }
    }
}
