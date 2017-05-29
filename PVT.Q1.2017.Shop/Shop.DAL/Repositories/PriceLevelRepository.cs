namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The price level repository.
    /// </summary>
    public class PriceLevelRepository : BaseRepository<PriceLevel>, IPriceLevelRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceLevelRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public PriceLevelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns the default price level.
        /// </summary>
        /// <returns>
        /// The default price level.
        /// </returns>
        public PriceLevel GetDefaultPriceLevel()
        {
            return CurrentDbSet.FirstOrDefault();
        }
    }
}