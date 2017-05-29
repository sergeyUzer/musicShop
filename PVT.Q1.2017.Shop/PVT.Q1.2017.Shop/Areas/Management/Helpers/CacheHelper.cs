namespace PVT.Q1._2017.Shop.Areas.Management.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Caching;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;

    internal static class CacheHelper
    {
        private const string GENRES_CACHE_KEY = "Genres_Cache";
        private const string CURRENCIES_CACHE_KEY = "Currencies_Cache";

        public static ICollection<Genre> GetCachedGenres()
        {
            return HttpContext.Current.Cache[GENRES_CACHE_KEY] as ICollection<Genre>;
        }

        public static void CacheGenres(ICollection<Genre> genres)
        {
            HttpContext.Current.Cache.Add(GENRES_CACHE_KEY, genres, null, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static void ClearCachedGenres()
        {
            HttpContext.Current.Cache.Remove(GENRES_CACHE_KEY);
        }

        public static ICollection<CurrencyViewModel> GetCachedCurrencies()
        {
            return HttpContext.Current.Cache[CURRENCIES_CACHE_KEY] as ICollection<CurrencyViewModel>;
        }

        public static void CacheCurrencies(ICollection<CurrencyViewModel> currencies)
        {
            HttpContext.Current.Cache.Add(CURRENCIES_CACHE_KEY, currencies, null, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static void ClearCachedCurrencies()
        {
            HttpContext.Current.Cache.Remove(CURRENCIES_CACHE_KEY);
        }
    }
}