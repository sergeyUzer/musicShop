namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The currency rate validator
    /// </summary>
    public class CurrencyRateValidator : AbstractValidator<CurrencyRate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRateValidator"/> class.
        /// </summary>
        public CurrencyRateValidator()
        {
            RuleFor(r => r.CrossCourse).GreaterThan(0);
            RuleFor(r => r.CurrencyId).GreaterThan(0);
            RuleFor(r => r.TargetCurrencyId).GreaterThan(0);
        }
    }
}