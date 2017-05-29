namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The genre validator
    /// </summary>
    public class GenreValidator : AbstractValidator<Genre>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreValidator"/> class.
        /// </summary>
        public GenreValidator()
        {
            RuleFor(g => g.Name).NotEmpty().Matches(@"^\S+(\s\S+)*$");
        }
    }
}