namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using Common.ViewModels;

    /// <summary>
    /// The track price service.
    /// </summary>
    public interface ITrackPriceService
    {
        /// <summary>
        /// Returns the track price in the specified currency and price level.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <returns>
        /// The track price in the specified currency and price level or <b>null</b>.
        /// </returns>
        PriceViewModel GetTrackPrice(int trackId, int? currencyCode = null, int? priceLevelId = null);

        /// <summary>
        /// Returns all track prices for the specified price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <param name="priceLevelId">The price level id.</param>
        /// <returns>All track prices for the specified price level.</returns>
        ICollection<PriceViewModel> GetTrackPrices(int trackId, int priceLevelId);

        /// <summary>
        /// Returns all track prices for the default price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <returns>All track prices.</returns>
        ICollection<PriceViewModel> GetTrackPrices(int trackId);
    }
}