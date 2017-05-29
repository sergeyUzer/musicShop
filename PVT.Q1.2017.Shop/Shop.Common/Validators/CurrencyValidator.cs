namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The currency validator
    /// </summary>
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValidator"/> class.
        /// </summary>
        public CurrencyValidator()
        {
            RuleFor(c => c.ShortName).NotEmpty().Length(3).Matches("^[A-Z]{3}$");
            RuleFor(c => c.Code).GreaterThan(0).LessThanOrEqualTo(999);
        }
    }
}