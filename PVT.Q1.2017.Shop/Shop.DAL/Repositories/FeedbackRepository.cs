namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The feedback repository.
    /// </summary>
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public FeedbackRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns the number of comments for the specified track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The number of comments for the specified track.
        /// </returns>
        public int GetFeedbacksCount(int trackId)
        {
            return CurrentDbSet.Count(v => v.TrackId == trackId);
        }

        /// <summary>
        /// Adds the specified <paramref name="feedback"/> into Db.
        /// </summary>
        /// <param name="feedback">
        /// The feedback.
        /// </param>
        protected override void Add(Feedback feedback)
        {
            EntityState trackEntryState;
            EntityState userEntryState;

            if (feedback.TrackId == 0 && feedback.Track != null)
            {
                feedback.TrackId = feedback.Track.Id;
            }

            if (feedback.UserId == 0 && feedback.User != null)
            {
                feedback.UserId = feedback.User.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The FeedbackBaseRepository should be SOLID, should only add information about feedbacks! Not about tracks or users!
            DetachNavigationProperty(feedback.Track, out trackEntryState);
            DetachNavigationProperty(feedback.User, out userEntryState);

            feedback.Track = null;
            feedback.User = null;

            // adding the feedback into Db.
            base.Add(feedback);
        }
    }
}