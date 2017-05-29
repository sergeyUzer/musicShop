namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The vote repository.
    /// </summary>
    public interface IVoteRepository : IRepository<Vote>
    {
        /// <summary>
        /// Returns average track rating for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The average track rating for the specified  track.
        /// </returns>
        double GetAverageMark(int trackId);

        /// <summary>
        /// Returns the number of votes for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The number of votes for the specified track.
        /// </returns>
        int GetVotesCount(int trackId);
    }
}