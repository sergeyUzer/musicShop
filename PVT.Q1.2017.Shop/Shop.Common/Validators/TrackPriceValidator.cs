namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The track price validator
    /// </summary>
    public class TrackPriceValidator : AbstractValidator<TrackPrice>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackPriceValidator"/> class.
        /// </summary>
        public TrackPriceValidator()
        {
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.TrackId).GreaterThan(0);
            RuleFor(p => p.CurrencyId).GreaterThan(0);
            RuleFor(p => p.PriceLevelId).GreaterThan(0);
        }
    }
}