using Shop.Common.Models;
using Shop.Infrastructure.Repositories;

namespace Shop.DAL.Infrastruture
{
    /// <summary>
    /// The price level repository.
    /// </summary>
    public interface IPriceLevelRepository : IRepository<PriceLevel>
    {
        /// <summary>
        /// Returns the default price level.
        /// </summary>
        /// <returns>
        /// The default price level.
        /// </returns>
        PriceLevel GetDefaultPriceLevel();
    }
}