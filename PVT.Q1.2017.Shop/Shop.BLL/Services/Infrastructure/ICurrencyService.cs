namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using Common.ViewModels;

    /// <summary>
    /// The currency service.
    /// </summary>
    public interface ICurrencyService
    {
        /// <summary>
        /// The default currency.
        /// </summary>
        CurrencyViewModel DefaultCurrency { get; }

        /// <summary>
        /// Returns the currency with the specified <paramref name="code"/>.
        /// </summary>
        /// <param name="code">
        /// The currency numeric code (see ISO 421).
        /// </param>
        /// <returns>
        /// The currency with the specified <paramref name="code"/> or <b>null</b> if currency doesn't exist.
        /// </returns>
        CurrencyViewModel GetCurrencyByCode(int code);

        /// <summary>
        /// Returns the currency with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// The currency name (see ISO 421).
        /// </param>
        /// <returns>
        /// The currency with the specified <paramref name="name"/> or <b>null</b> if currency doesn't exist.
        /// </returns>
        CurrencyViewModel GetCurrencyByName(string name);

        /// <summary>
        /// Returns all registered currencies.
        /// </summary>
        /// <returns>
        /// All registered currencies.
        /// </returns>
        ICollection<CurrencyViewModel> GetCurrencies();

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
        bool CurrencyExists(string name);

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
        bool CurrencyExists(int code);

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
        bool CurrencyExists(CurrencyViewModel currency);
    }
}