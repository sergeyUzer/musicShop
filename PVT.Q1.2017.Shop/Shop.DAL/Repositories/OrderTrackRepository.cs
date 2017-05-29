namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// Repository of Ordered Track
    /// </summary>
    public class OrderTrackRepository : BaseRepository<OrderTrack>, IOrderTrackRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTrackRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public OrderTrackRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Delete Order Track from Repository
        /// </summary>
        /// <param name="model">OrderTrack to remove</param>
        public override void Delete(OrderTrack model)
        {
            if (model == null) return;
            this.CurrentDbSet.Remove(model);
            this.SetStateChanged();
        }

        /// <summary>
        /// Add or Update OrderTrack to Repository
        /// </summary>
        /// <param name="model">OrderTrack to Add or Update</param>
        public override void AddOrUpdate(OrderTrack model)
        {
            // if the model exists in Db then we have to update it
            var originalModel = FirstOrDefault(m => m.UserId == model.UserId && m.TrackId == model.TrackId);
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
