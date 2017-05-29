namespace Shop.Common.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation;
    using Shop.Common.Models;

    /// <summary>
    /// The user payment method validator.
    /// </summary>
    public class UserPaymentMethodValidator : AbstractValidator<UserPaymentMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPaymentMethodValidator"/> class.
        /// </summary>
        public UserPaymentMethodValidator()
        {
            RuleFor(t => t.Alias).NotEmpty();
            RuleFor(t => t.Currency).NotNull().NotEmpty();
            RuleFor(t => t.Name).NotEmpty().Length(4, 50);
            RuleFor(t => t.User).NotNull();
        }
    }
}
