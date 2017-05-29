namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The artist validator.
    /// </summary>
    public class ArtistValidator : AbstractValidator<Artist>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistValidator"/> class.
        /// </summary>
        public ArtistValidator()
        {
            RuleFor(a => a.Name).NotEmpty().Matches(@"^\S+(\s\S+)*$");
        }
    }
}