namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Common.ViewModels;

    using Shop.BLL.Helpers;
    using Shop.Infrastructure.Enums;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The track service
    /// </summary>
    public interface ITrackService
    {
        /// <summary>
        /// Returns the track details using the specified currency and price level for track price.
        /// </summary>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="id">The track id.</param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// The information about track with the specified <paramref name="id"/> or <b>null</b> if track doesn't exist.
        /// </returns>
        TrackDetailsViewModel GetTrackDetails(int id, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered tracks using the specified currency and price level for track price.
        /// </summary>
        /// <param name="currencyCode">
        ///     The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        ///     The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        ///     The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks.
        /// </returns>
        Task<ICollection<TrackViewModel>> GetTracksAsync(int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all registered tracks using the specified currency and price level for track price.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <param name="currencyCode">
        ///     The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        ///     The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        ///     The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks.
        /// </returns>
        PagedResult<TrackViewModel> GetTracks(int page, int pageSize, int? currencyCode = null, int? priceLevel = null, int? userId = null);

        /// <summary>
        /// Returns all albums which contain the specified track using the specified currency and price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All albums which contain the specified track.
        /// </returns>
        TrackAlbumsListViewModel GetAlbums(int trackId, int? currencyCode = null, int? priceLevelId = null, int? userId = null);

        /// <summary>
        /// Return all tracks that the specified user have bought.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// All tracks that the specified user have bought.
        /// </returns>
        Task<ICollection<PurchasedTrackViewModel>> GetPurchasedTracksAsync(int userId);

        /// <summary>
        /// Return all tracks that the specified user have bought.
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
        /// All tracks that the specified user have bought.
        /// </returns>
        PagedResult<PurchasedTrackViewModel> GetPurchasedTracks(int page, int pageSize, int userId);

        /// <summary>
        /// Return a track with the specified id purchased by the specified user.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userProfileId">
        /// The user profile id.
        /// </param>
        /// <returns>
        /// A track with the specified id purchased by the specified user if exists or <b>null</b>.
        /// </returns>
        PurchasedTrackViewModel GetPurchasedTrack(int trackId, int userProfileId);

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="userRole">
        /// The user role.
        /// </param>
        /// <param name="userProfileId">
        /// The user profile id.
        /// </param>
        /// <returns>
        /// </returns>
        TrackAudio GetTrackAudio(int id, UserRoles userRole, int userProfileId);
    }
}