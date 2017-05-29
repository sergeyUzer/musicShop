namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// Repository of Ordered Album
    /// </summary>
    public class OrderAlbumRepository : BaseRepository<OrderAlbum>, IOrderAlbumRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlbumRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public OrderAlbumRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Delete OrderAlbum from Repository
        /// </summary>
        /// <param name="model">OrderAlbum to remove</param>
        public override void Delete(OrderAlbum model)
        {
            if (model == null) return;
            this.CurrentDbSet.Remove(model);
            this.SetStateChanged();
        }

        /// <summary>
        /// Add or Update OrderAlbum to Repository
        /// </summary>
        /// <param name="model">OrderAlbum to Add or Update</param>
        public override void AddOrUpdate(OrderAlbum model)
        {
            // if the model exists in Db then we have to update it
            var originalModel = FirstOrDefault(m => m.UserId == model.UserId && m.AlbumId == model.AlbumId);
            if (originalModel != null)
            {
                model.Id = originalModel.Id;
                Update(originalModel, model);
                this.SetStateChanged();
            }
            else
            {
                Add(model);
                this.SetStateChanged();
            }
        }
    }
}
