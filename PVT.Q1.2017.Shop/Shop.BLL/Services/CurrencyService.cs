namespace Shop.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;
    using Helpers;
    using Infrastructure;

    /// <summary>
    /// The currency service.
    /// </summary>
    public class CurrencyService : BaseService, ICurrencyService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        public CurrencyService(IRepositoryFactory factory) : base(factory)
        {
            DefaultCurrency = ServiceHelper.GetDefaultCurrency(factory);
        }

        /// <summary>
        /// Gets the default currency.
        /// </summary>
        public CurrencyViewModel DefaultCurrency { get; private set; }

        /// <summary>
        /// Returns the currency with the specified <paramref name="code"/>.
        /// </summary>
        /// <param name="code">
        /// The currency numeric code (see ISO 421).
        /// </param>
        /// <returns>
        /// The currency with the specified <paramref name="code"/> or <b>null</b> if currency doesn't exist.
        /// </returns>
        public CurrencyViewModel GetCurrencyByCode(int code)
        {
            Currency currency;
            using (var repositry = Factory.GetCurrencyRepository())
            {
                currency = repositry.FirstOrDefault(c => c.Code == code);
            }

            return ModelsMapper.GetCurrencyViewModel(currency);
        }

        /// <summary>
        /// Returns the currency with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// The currency name (see ISO 421).
        /// </param>
        /// <returns>
        /// The currency with the specified <paramref name="name"/> or <b>null</b> if currency doesn't exist.
        /// </returns>
        public CurrencyViewModel GetCurrencyByName(string name)
        {
            Currency currency;
            using (var repositry = Factory.GetCurrencyRepository())
            {
                currency = repositry.FirstOrDefault(c => c.ShortName.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            return ModelsMapper.GetCurrencyViewModel(currency);
        }

        /// <summary>
        /// Returns all registered currencies.
        /// </summary>
        /// <returns>
        /// All registered currencies.
        /// </returns>
        public ICollection<CurrencyViewModel> GetCurrencies()
        {
            ICollection<Currency> allCurrencies;
            using (var repositry = Factory.GetCurrencyRepository())
            {
                allCurrencies = repositry.GetAll();
            }

            return allCurrencies.Select(ModelsMapper.GetCurrencyViewModel).ToList();
        }

        /// <summary>
        /// Determines whether a currency with the specified <paramref name="name"/> exists.
        /// </summary>
        /// <param name="name">
        /// The currency name (see ISO 421).
        /// </param>
        /// <returns>
        /// <b>true</b> if a currency with the specified <paramref name="name"/> exists;
        /// otherwise <b>false</b>.
        /// </returns>
        public bool CurrencyExists(string name)
        {
            using (var repositry = Factory.GetCurrencyRepository())
            {
                return repositry.Exist(c => c.ShortName.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Determines whether a currency with the specified numeric <paramref name="code"/> exists.
        /// </summary>
        /// <param name="code">
        /// The currency numeric code (see ISO 421).
        /// </param>
        /// <returns>
        /// <b>true</b> if a currency with the specified <paramref name="code"/> exists;
        /// otherwise <b>false</b>.
        /// </returns>
        public bool CurrencyExists(int code)
        {
            using (var repositry = Factory.GetCurrencyRepository())
            {
                return repositry.Exist(c => c.Code == code);
            }
        }

        /// <summary>
        /// Determines whether the specified <paramref name="currency"/> already exists.
        /// </summary>
        /// <param name="currency">
        ///     The currency.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specified <paramref name="currency"/> already exists;
        /// otherwise <b>false</b>.
        /// </returns>
        public bool CurrencyExists(CurrencyViewModel currency)
        {
            if (currency == null)
            {
                return false;
            }

            using (var repositry = Factory.GetCurrencyRepository())
            {
                return repositry.Exist(c => c.Code == currency.Code ||
                                            c.ShortName.Equals(currency.ShortName.Trim(), StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Returns the currency with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The currency id.</param>
        /// <returns>
        /// The currency with the specified <paramref name="id"/> or <b>null</b> if currency doesn't exist.
        /// </returns>
        public Currency GetCurrency(int id)
        {
            using (var repositry = Factory.GetCurrencyRepository())
            {
                return repositry.GetById(id);
            }
        }
    }
}