namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The currency repository
    /// </summary>
    public interface ICurrencyRepository : IRepository<Currency>
    {
        /// <summary>
        /// Returns the default currency.
        /// </summary>
        /// <returns>
        /// The default currency.
        /// </returns>
        Currency GetDefaultCurrency();
    }
}