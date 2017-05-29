namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.ViewModels;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The album service.
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// Returns the album details using the specified currency and price level for album price.
        /// </summary>
        /// <param name="id">The album id.</param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// The information about album with the specified <paramref name="id"/> or <b>null</b> if album doesn't exist.
        /// </returns>
        AlbumDetailsViewModel GetAlbumDetails(int id, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all tracks whitch could be added to the specified album using the specified currency and price level for track price.
        /// </summary>
        /// <param name="albumId">
        /// The album id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All tracks whitch could be added to the specified album using the specified currency and price level for track price.
        /// </returns>
        AlbumTracksListViewModel GetTracksToAdd(int albumId, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered tracks for the specified album using the specified currency and price level for track price.
        /// </summary>
        /// <param name="albumId">The album id.</param>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks with price for the specified album.
        /// </returns>
        AlbumTracksListViewModel GetTracks(int albumId, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered albums using the specified currency and price level for album price.
        /// </summary>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered albums.
        /// </returns>
        ICollection<AlbumViewModel> GetAlbums(int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered albums using the specified currency and price level for album price.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered albums.
        /// </returns>
        PagedResult<AlbumViewModel> GetAlbums(int page, int pageSize, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Return all albums that the specified user have bought.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// All albums that the specified user have bought.
        /// </returns>
        Task<ICollection<PurchasedAlbumViewModel>> GetPurchasedAlbumsAsync(int userId);

        /// <summary>
        /// Return all albums that the specified user have bought.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// All albums that the specified user have bought.
        /// </returns>
        PagedResult<PurchasedAlbumViewModel> GetPurchasedAlbums(int page, int pageSize, int userId);
    }
}