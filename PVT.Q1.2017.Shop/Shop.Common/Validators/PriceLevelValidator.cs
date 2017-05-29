namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The price level validator
    /// </summary>
    public class PriceLevelValidator : AbstractValidator<PriceLevel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceLevelValidator"/> class.
        /// </summary>
        public PriceLevelValidator()
        {
            RuleFor(l => l.Name).NotEmpty().Matches(@"^\S+(\s\S+)*$");
        }
    }
}