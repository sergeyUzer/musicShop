namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The track validator.
    /// </summary>
    public class TrackValidator : AbstractValidator<Track>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackValidator"/> class.
        /// </summary>
        public TrackValidator()
        {
            RuleFor(t => t.Name).NotEmpty().Matches(@"^\S+(\s\S+)*$");
            RuleFor(t => t.ArtistId).NotNull().GreaterThan(0);
            RuleFor(t => t.GenreId).GreaterThan(0);
        }
    }
}