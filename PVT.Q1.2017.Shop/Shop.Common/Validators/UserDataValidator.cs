namespace Shop.Common.Validators
{
    using FluentValidation;
    using Models;

    /// <summary>
    /// The user data validator
    /// </summary>
    public class UserDataValidator : AbstractValidator<UserData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataValidator"/> class.
        /// </summary>
        public UserDataValidator()
        {
            RuleFor(u => u.CurrencyId).GreaterThan(0);
            RuleFor(u => u.PriceLevelId).GreaterThan(0);
        }
    }
}