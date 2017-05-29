namespace Shop.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;
    using Helpers;
    using Infrastructure;

    /// <summary>
    /// The album price service.
    /// </summary>
    public class AlbumPriceService : BaseService, IAlbumPriceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumPriceService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        public AlbumPriceService(IRepositoryFactory factory) : base(factory)
        {
        }

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
        public PriceViewModel GetAlbumPrice(int albumId, int? currencyCode, int? priceLevelId)
        {
            if (currencyCode == null)
            {
                currencyCode = ServiceHelper.GetDefaultCurrency(Factory).Code;
            }

            if (priceLevelId == null)
            {
                priceLevelId = ServiceHelper.GetDefaultPriceLevel(Factory);
            }

            using (var repository = Factory.GetAlbumPriceRepository())
            {
                using (var currencyRatesrepository = Factory.GetCurrencyRateRepository())
                {
                    return PriceHelper.GetAlbumPrice(repository, currencyRatesrepository, albumId, currencyCode.Value, priceLevelId.Value);
                }
            }
        }

        /// <summary>
        /// Returns all album prices for the specified price level.
        /// </summary>
        /// <param name="albumId">The album id.</param>
        /// <param name="priceLevelId">The price level id.</param>
        /// <returns>
        /// All album prices for the specified price level.
        /// </returns>
        public ICollection<PriceViewModel> GetAlbumPrices(int albumId, int priceLevelId)
        {
            ICollection<AlbumPrice> albumPrices;
            using (var repository = Factory.GetAlbumPriceRepository())
            {
                albumPrices = repository.GetAll(
                                                p => p.AlbumId == albumId &&
                                                     p.PriceLevelId == priceLevelId,
                                                p => p.Currency);
            }

            return albumPrices.Select(ModelsMapper.GetPriceViewModel).ToList();
        }

        /// <summary>
        /// Returns all album prices.
        /// </summary>
        /// <param name="albumId">The album id.</param>
        /// <returns>All album prices.</returns>
        public ICollection<PriceViewModel> GetAlbumPrices(int albumId)
        {
            ICollection<AlbumPrice> albumPrices;
            using (var repository = Factory.GetAlbumPriceRepository())
            {
                albumPrices = repository.GetAll(
                                                p => p.AlbumId == albumId,
                                                p => p.Currency,
                                                p => p.PriceLevel);
            }

            return albumPrices.Select(ModelsMapper.GetPriceViewModel).ToList();
        }
    }
}