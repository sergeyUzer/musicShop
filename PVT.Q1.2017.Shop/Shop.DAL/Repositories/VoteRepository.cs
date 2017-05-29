namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The vote repository.
    /// </summary>
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoteRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public VoteRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns the number of votes for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The number of votes for the specified track.
        /// </returns>
        public int GetVotesCount(int trackId)
        {
            return CurrentDbSet.Count(v => v.TrackId == trackId);
        }

        /// <summary>
        /// Returns average track rating for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The average track rating for the specified  track.
        /// </returns>
        public double GetAverageMark(int trackId)
        {
            return CurrentDbSet.Any(v => v.TrackId == trackId) ? CurrentDbSet.Where(v => v.TrackId == trackId).Average(v => v.Mark) : 0d;
        }

        /// <summary>
        /// Adds the specified <paramref name="vote"/> into Db.
        /// </summary>
        /// <param name="vote">
        /// The vote to add.
        /// </param>
        protected override void Add(Vote vote)
        {
            EntityState trackEntryState;
            EntityState userEntryState;

            if (vote.TrackId == 0 && vote.Track != null)
            {
                vote.TrackId = vote.Track.Id;
            }

            if (vote.UserId == 0 && vote.User != null)
            {
                vote.UserId = vote.User.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The VoteBaseRepository should be SOLID, should only add information about vote! Not about track or user!
            DetachNavigationProperty(vote.Track, out trackEntryState);
            DetachNavigationProperty(vote.User, out userEntryState);

            vote.Track = null;
            vote.User = null;

            // adding the vote into Db.
            base.Add(vote);
        }
    }
}