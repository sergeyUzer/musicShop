namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The album validator
    /// </summary>
    public class AlbumValidator : AbstractValidator<Album>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumValidator"/> class.
        /// </summary>
        public AlbumValidator()
        {
            RuleFor(a => a.Name).NotEmpty().Matches(@"^\S+(\s\S+)*$");
            RuleFor(a => a.ArtistId).GreaterThan(0).When(a => a.ArtistId.HasValue);
        }
    }
}