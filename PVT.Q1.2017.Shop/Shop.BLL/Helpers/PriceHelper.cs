namespace Shop.BLL.Helpers
{
    using System;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;

    /// <summary>
    /// The price helper.
    /// </summary>
    internal static class PriceHelper
    {
        /// <summary>
        /// Returns the track price in the specified currency and price level.
        /// </summary>
        /// <param name="repository">
        /// The track price repository.
        /// </param>
        /// <param name="currencyRatesrepository">
        /// The currency rates repository.
        /// </param>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level id.
        /// </param>
        /// <returns>
        /// The track price in the specified <paramref name="currencyCode"/> for the specified  <paramref name="priceLevelId"/> or <b>null</b>.
        /// </returns>
        internal static PriceViewModel GetTrackPrice(
            ITrackPriceRepository repository,
            ICurrencyRateRepository currencyRatesrepository,
            int trackId,
            int currencyCode,
            int priceLevelId)
        {
            var price = repository.FirstOrDefault(
                                                  p => p.TrackId == trackId &&
                                                       p.PriceLevelId == priceLevelId &&
                                                       p.Currency.Code == currencyCode,
                                                  p => p.Currency,
                                                  p => p.PriceLevel);

            // if price is not exist for the specified currency then we'll try to find price in any other currency
            if (price == null)
            {
                price = repository.FirstOrDefault(
                                                  p => p.TrackId == trackId &&
                                                       p.PriceLevelId == priceLevelId,
                                                  p => p.Currency);
                if (price != null)
                {
                    PriceViewModel targetPrice;
                    if (TryConvertToTargetPrice(
                                                currencyRatesrepository,
                                                price.Price,
                                                price.Currency.Code,
                                                currencyCode,
                                                out targetPrice))
                    {
                        return targetPrice;
                    }
                }
            }

            return ModelsMapper.GetPriceViewModel(price);
        }

        /// <summary>
        /// Returns the album price in the specified currency and price level.
        /// </summary>
        /// <param name="albumPriceRepository">
        /// The repository.
        /// </param>
        /// <param name="currencyRatesRepository">
        /// The currency rates repository.
        /// </param>
        /// <param name="albumId">
        /// The album id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level id.
        /// </param>
        /// <returns>
        /// The album price in the specified currency and price level or <b>null</b>.
        /// </returns>
        internal static PriceViewModel GetAlbumPrice(
            IAlbumPriceRepository albumPriceRepository,
            ICurrencyRateRepository currencyRatesRepository,
            int albumId,
            int currencyCode,
            int priceLevelId)
        {
            var price = albumPriceRepository.FirstOrDefault(
                                          p => p.AlbumId == albumId &&
                                               p.PriceLevelId == priceLevelId &&
                                               p.Currency.Code == currencyCode,
                                          p => p.Album,
                                          p => p.Currency,
                                          p => p.PriceLevel);

            // if price is not exist for the specified currency then we'll try to find price in any other currency
            if (price == null)
            {
                price = albumPriceRepository.FirstOrDefault(
                                                  p => p.AlbumId == albumId &&
                                                       p.PriceLevelId == priceLevelId ,
                                                  p => p.Currency);
                if (price != null)
                {
                    PriceViewModel targetPrice;
                    if (TryConvertToTargetPrice(
                                                currencyRatesRepository,
                                                price.Price,
                                                price.Currency.Code,
                                                currencyCode,
                                                out targetPrice))
                    {
                        return targetPrice;
                    }
                }
            }

            return ModelsMapper.GetPriceViewModel(price);
        }

        /// <summary>
        /// Tries to convert price to price in the specified currency via a cross-cource.
        /// </summary>
        /// <param name="repository">
        /// The currency rates repository.
        /// </param>
        /// <param name="amount">
        /// The price amount.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="targetCurrencyCode">
        /// The target currency code.
        /// </param>
        /// <param name="targetPrice">
        /// The convertion result.
        /// </param>
        internal static bool TryConvertToTargetPrice(
            ICurrencyRateRepository repository,
            decimal amount,
            int currencyCode,
            int targetCurrencyCode,
            out PriceViewModel targetPrice)
        {
            var rate = GetCurrencyRate(repository, currencyCode, targetCurrencyCode);
            if (rate != null)
            {
                targetPrice = new PriceViewModel
                {
                    // financial rounding to even
                    Amount = Math.Round(rate.CrossCourse * amount, 2, MidpointRounding.ToEven),
                    Currency = ModelsMapper.GetCurrencyViewModel(rate.TargetCurrency)
                };
                return true;
            }

            targetPrice = null;
            return false;
        }

        /// <summary>
        /// Tries to find currency rate for the specified currencies.
        /// </summary>
        /// <param name="repository">
        /// The currency rates repository.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="targetCurrencyCode">
        /// The target currency code.
        /// </param>
        /// <returns>
        /// The currency rate or <b>null</b> if a rate not found.
        /// </returns>
        private static CurrencyRate GetCurrencyRate(
            ICurrencyRateRepository repository,
            int currencyCode,
            int targetCurrencyCode)
        {
            return repository.FirstOrDefault(
                                             r => r.Currency.Code == currencyCode &&
                                                  r.TargetCurrency.Code == targetCurrencyCode,
                                             r => r.Currency,
                                             r => r.TargetCurrency);
        }
    }
}