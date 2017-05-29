namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The vote validator
    /// </summary>
    public class VoteValidator : AbstractValidator<Vote>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoteValidator"/> class.
        /// </summary>
        public VoteValidator()
        {
            RuleFor(v => v.Mark).GreaterThan(0);
            RuleFor(v => v.TrackId).GreaterThan(0);
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}