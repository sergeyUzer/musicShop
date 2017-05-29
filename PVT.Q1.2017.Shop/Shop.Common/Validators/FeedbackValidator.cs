namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The feedback validator
    /// </summary>
    public class FeedbackValidator : AbstractValidator<Feedback>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackValidator"/> class.
        /// </summary>
        public FeedbackValidator()
        {
            RuleFor(f => f.TrackId).GreaterThan(0);
            RuleFor(f => f.UserId).GreaterThan(0);
        }
    }
}