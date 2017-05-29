namespace Shop.Common.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation;
    using Models;

    /// <summary>
    /// Instanse for Payment card validator
    /// </summary>
    public class PaymentCardValidator : AbstractValidator<PaymentCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentCardValidator"/> class.
        /// </summary>
        public PaymentCardValidator()
        {
            RuleFor(t => t.Expire_month).NotEmpty();
            RuleFor(t => t.Expire_year).NotEmpty();
            RuleFor(t => t.First_name).NotEmpty().Length(4, 50);
            RuleFor(t => t.Last_name).NotEmpty().Length(4, 50);
            RuleFor(t => t.Valid_until).NotEmpty();
            RuleFor(t => t.CVV2).NotEmpty().Length(3,3);
            RuleFor(t => t.Number).CreditCard();
        }
    }
}
