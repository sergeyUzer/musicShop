namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// Repository of Purchased Album
    /// </summary>
    public class PurchasedAlbumRepository : BaseRepository<PurchasedAlbum>, IPurchasedAlbumRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasedAlbumRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public PurchasedAlbumRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
