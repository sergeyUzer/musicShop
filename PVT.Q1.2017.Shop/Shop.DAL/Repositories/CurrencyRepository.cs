namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The currency repository
    /// </summary>
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public CurrencyRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns the default currency.
        /// </summary>
        /// <returns>
        /// Default currency.
        /// </returns>
        public Currency GetDefaultCurrency()
        {
            return CurrentDbSet.FirstOrDefault();
        }
    }
}