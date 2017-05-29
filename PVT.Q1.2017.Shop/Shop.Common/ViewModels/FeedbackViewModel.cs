namespace Shop.Common.ViewModels
{
    /// <summary>
    /// The feedback view model.
    /// </summary>
    public class FeedbackViewModel
    {
        /// <summary>
        /// The user id who have leaved the current feedback.
        /// </summary>
        public int UserDataId { get; set; }

        /// <summary>
        /// The track.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// Name of the user who have leaved the current feedback.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Comments of the user who have leaved the current feedback.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Mark of the user who have leaved the current feedback.
        /// </summary>
        public int Mark { get; set; }
    }
}