namespace Shop.Common.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents all feedbacks list for the track.
    /// </summary>
    public class TrackFeedbacksListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackFeedbacksListViewModel"/> class.
        /// </summary>
        public TrackFeedbacksListViewModel()
        {
            Feedbacks = new List<FeedbackViewModel>();
        }

        /// <summary>
        /// The track details.
        /// </summary>
        public TrackDetailsViewModel TrackDetails
        {
            get; set;
        }

        /// <summary>
        /// All feedbacks for the track.
        /// </summary>
        public ICollection<FeedbackViewModel> Feedbacks
        {
            get; set;
        }
    }
}