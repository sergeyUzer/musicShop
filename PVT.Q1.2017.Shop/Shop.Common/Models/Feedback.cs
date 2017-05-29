namespace Shop.Common.Models
{
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    ///     The feedback.
    /// </summary>
    [Validator(typeof(FeedbackValidator))]
    public class Feedback : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the user's comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        ///     Gets or sets the track for which the user have written the
        ///     <see cref="Shop.Common.Models.Feedback.Comments" /> .
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        ///     Gets or sets the user who wrote the
        ///     <see cref="Shop.Common.Models.Feedback.Comments" /> .
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the track for which the
        ///     <see cref="Shop.Common.Models.Feedback.User" /> have written the
        ///     <see cref="Shop.Common.Models.Feedback.Comments" /> .
        /// </summary>
        public virtual Track Track
        {
            get; set;
        }

        /// <summary>
        ///     Gets or sets the user who wrote the
        ///     <see cref="Shop.Common.Models.Feedback.Comments" /> .
        /// </summary>
        public virtual UserData User
        {
            get; set;
        }
    }
}