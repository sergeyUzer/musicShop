namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The album price validator
    /// </summary>
    public class AlbumPriceValidator : AbstractValidator<AlbumPrice>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumPriceValidator"/> class.
        /// </summary>
        public AlbumPriceValidator()
        {
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.AlbumId).GreaterThan(0);
            RuleFor(p => p.CurrencyId).GreaterThan(0);
            RuleFor(p => p.PriceLevelId).GreaterThan(0);
        }
    }
}