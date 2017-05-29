namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The feedback repository.
    /// </summary>
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        /// <summary>
        /// Returns the number of comments for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The number of comments for the specified track.
        /// </returns>
        int GetFeedbacksCount(int trackId);
    }
}