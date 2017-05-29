namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using Common.ViewModels;

    /// <summary>
    /// The album price service.
    /// </summary>
    public interface IAlbumPriceService
    {
        /// <summary>
        /// Returns the album price in the specified currency and price level.
        /// </summary>
        /// <param name="albumId">
        /// The album id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <returns>
        /// The album price in the specified currency and price level or <b>null</b>.
        /// </returns>
        PriceViewModel GetAlbumPrice(int albumId, int? currencyCode = null, int? priceLevelId = null);

        /// <summary>
        /// Returns all album prices for the specified price level.
        /// </summary>
        /// <param name="albumId">The album id.</param>
        /// <param name="priceLevelId">The price level id.</param>
        /// <returns>
        /// All album prices for the specified price level.
        /// </returns>
        ICollection<PriceViewModel> GetAlbumPrices(int albumId, int priceLevelId);

        /// <summary>
        /// Returns all album prices.
        /// </summary>
        /// <param name="albumId">The album id.</param>
        /// <returns>All album prices.</returns>
        ICollection<PriceViewModel> GetAlbumPrices(int albumId);
    }
}