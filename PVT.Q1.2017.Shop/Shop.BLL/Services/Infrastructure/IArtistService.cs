namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using Common.ViewModels;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The artist service.
    /// </summary>
    public interface IArtistService
    {
        /// <summary>
        /// Returns the artist details.
        /// </summary>
        /// <param name="id">The artist id.</param>
        /// <returns>
        /// The information about artist with the specified <paramref name="id"/> or <b>null</b> if artist doesn't exist.
        /// </returns>
        ArtistDetailsViewModel GetArtistDetails(int id);

        /// <summary>
        /// Returns all registered tracks for the specified artist using the specified currency and price level for track price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
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
        /// All registered tracks with price for the specified artist.
        /// </returns>
        ArtistTracksListViewModel GetTracks(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered albums for the specified artist using the specified currency and price level for album price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
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
        /// All registered albums with price for the specified artist.
        /// </returns>
        ArtistAlbumsListViewModel GetAlbums(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered tracks and albums for the specified artist using the specified currency and price level for the price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
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
        /// All registered tracks and albums with price for the specified artist.
        /// </returns>
        ArtistContentViewModel GetContent(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered artists.
        /// </summary>
        /// <returns>
        /// All registered artists.
        /// </returns>
        ICollection<ArtistViewModel> GetArtists();

        /// <summary>
        /// Returns all registered artists.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <returns>
        /// All registered artists.
        /// </returns>
        PagedResult<ArtistViewModel> GetArtists(int page, int pageSize);

        /// <summary>
        /// Returns all registered artists with detailed information.
        /// </summary>
        /// <returns>
        /// All registered artists with detailed information.
        /// </returns>
        ICollection<ArtistDetailsViewModel> GetDetailedArtistsList();

        /// <summary>
        /// Returns all registered artists with detailed information.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <returns>
        /// All registered artists with detailed information.
        /// </returns>
        PagedResult<ArtistDetailsViewModel> GetDetailedArtistsList(int page, int pageSize);
    }
}