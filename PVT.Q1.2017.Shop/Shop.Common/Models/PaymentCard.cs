namespace Shop.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Shop.Infrastructure.Models;
    using Validators;

    /// <summary>
    /// A payment card that can fund a payment.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(PaymentCardValidator))]
    public class PaymentCard : BaseEntity
    {
        /// <summary>
        /// The card number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The card type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The two-digit expiry month for the card.
        /// </summary>
        public int Expire_month { get; set; }

        /// <summary>
        /// The four-digit expiry year for the card.
        /// </summary>
        public int Expire_year { get; set; }

        /// <summary>
        /// The two-digit start month for the card. Required for UK Maestro cards.
        /// </summary>
        public string Start_month { get; set; }

        /// <summary>
        /// The four-digit start year for the card. Required for UK Maestro cards. 
        /// </summary>
        public string Start_year { get; set; }

        /// <summary>
        /// The validation code for the card. Supported for payments but not for saving payment cards for future use.
        /// </summary>
        public string CVV2 { get; set; }

        /// <summary>
        /// The first name of the card holder.
        /// </summary>
        public string First_name { get; set; }

        /// <summary>
        /// The last name of the card holder.
        /// </summary>
        public string Last_name { get; set; }

        /// <summary>
        /// The two-letter country code.
        /// </summary>
        public string Billing_country { get; set; }

        /// <summary>
        /// The billing address for the card.
        /// </summary>
        public string Billing_address { get; set; }

        /// <summary>
        /// The ID of the customer who owns this card account. The facilitator generates and provides this ID. Required when you create or use a stored funding instrument in the PayPal vault.
        /// </summary>
        public string External_customer_id { get; set; }

        /// <summary>
        /// The state of the funding instrument.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The product class of the financial instrument issuer.
        /// </summary>
        public string Card_product_class { get; set; }

        /// <summary>
        /// The date and time until when this instrument can be used fund a payment.
        /// </summary>
        public string Valid_until { get; set; }

        /// <summary>
        /// The one- to two-digit card issue number. Required for UK Maestro cards.
        /// </summary>
        public string Issue_number { get; set; }
    }
}
