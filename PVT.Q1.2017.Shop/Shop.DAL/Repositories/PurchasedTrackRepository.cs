namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// Repository of Purchased Track
    /// </summary>
    public class PurchasedTrackRepository : BaseRepository<PurchasedTrack>, IPurchasedTrackRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasedTrackRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public PurchasedTrackRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
