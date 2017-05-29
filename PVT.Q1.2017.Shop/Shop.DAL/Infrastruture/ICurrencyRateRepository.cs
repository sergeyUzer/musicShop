namespace Shop.DAL.Infrastruture
{
    using Shop.Common.Models;
    using Shop.Infrastructure.Repositories;

    /// <summary>
    /// The currency rate repository.
    /// </summary>
    public interface ICurrencyRateRepository : IRepository<CurrencyRate>
    {
    }
}