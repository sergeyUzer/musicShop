namespace Shop.BLL.Services.Infrastructure
{
    using Common.ViewModels;

    /// <summary>
    /// The feedback service.
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// Adds a new feedback or updates existent feedback for the specified track.
        /// </summary>
        /// <param name="feedbackViewModel">
        /// The user feedback.
        /// </param>
        void AddOrUpdateFeedback(FeedbackViewModel feedbackViewModel);

        /// <summary>
        /// Returns the feedback which have made the specified user for the track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userDataId">
        /// The user who have left a comment and/or a vote for the track.
        /// </param>
        /// <returns>
        /// The feedback for the <paramref name="trackId"/> which have made the specified <paramref name="userDataId"/>
        /// or <b>null</b> in case if feedback doesn't exist.
        /// </returns>
        FeedbackViewModel GetTrackFeedback(int trackId, int userDataId);

        /// <summary>
        /// Determines whether the specified user have made a feedback for the track.
        /// </summary>
        /// <param name="trackId">
        ///     The track id.
        /// </param>
        /// <param name="userDataId">
        ///     The user data id.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specified user have made a feedback for the track;
        /// otherwise <b>false</b>.
        /// </returns>
        bool FeedbackExists(int trackId, int userDataId);

        /// <summary>
        /// Returns all track feedbacks.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// All track feedbacks.
        /// </returns>
        TrackFeedbacksListViewModel GetTrackFeedbacks(int trackId);
    }
}