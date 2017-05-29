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
    /// The track price service.
    /// </summary>
    public class TrackPriceService : BaseService, ITrackPriceService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackPriceService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        public TrackPriceService(IRepositoryFactory factory) : base(factory)
        {
        }

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
        public PriceViewModel GetTrackPrice(int trackId, int? currencyCode = null, int? priceLevelId = null)
        {
            if (currencyCode == null)
            {
                currencyCode = ServiceHelper.GetDefaultCurrency(Factory).Code;
            }

            if (priceLevelId == null)
            {
                priceLevelId = ServiceHelper.GetDefaultPriceLevel(Factory);
            }

            using (var repository = Factory.GetTrackPriceRepository())
            {
                using (var currencyRatesrepository = Factory.GetCurrencyRateRepository())
                {
                    return PriceHelper.GetTrackPrice(repository, currencyRatesrepository, trackId, currencyCode.Value, priceLevelId.Value);
                }
            }
        }

        /// <summary>
        /// Returns all track prices for the specified price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <param name="priceLevelId">The price level id.</param>
        /// <returns>All track prices for the specified price level.</returns>
        public ICollection<PriceViewModel> GetTrackPrices(int trackId, int priceLevelId)
        {
            ICollection<TrackPrice> trackPrices;
            using (var repository = Factory.GetTrackPriceRepository())
            {
                trackPrices = repository.GetAll(
                                         p => p.TrackId == trackId &&
                                              p.PriceLevelId == priceLevelId,
                                         p => p.Currency);
            }

            return trackPrices.Select(ModelsMapper.GetPriceViewModel).ToList();
        }

        /// <summary>
        /// Returns all track prices for the default price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <returns>All track prices.</returns>
        public ICollection<PriceViewModel> GetTrackPrices(int trackId)
        {
            ICollection<TrackPrice> trackPrices;
            using (var repository = Factory.GetTrackPriceRepository())
            {
                trackPrices = repository.GetAll(
                                         p => p.TrackId == trackId,
                                         p => p.Currency,
                                         p => p.PriceLevel);
            }

            return trackPrices.Select(ModelsMapper.GetPriceViewModel).ToList();
        }
    }
}