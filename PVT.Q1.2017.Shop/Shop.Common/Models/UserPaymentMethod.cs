// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPaymentMethod.cs" company="PVT Q1 2017">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the UserPaymentMethod type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shop.Common.Models
{
    using Infrastructure.Models;
    using Validators;
    
    /// <summary>
    /// Define settings for user payment methods
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(UserPaymentMethodValidator))]
    public class UserPaymentMethod : BaseEntity
    {
        /// <summary>
        /// Gets or sets Name for type of payment method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets User for payment method settings
        /// </summary>
        public UserData User { get; set; }
                
        /// <summary>
        /// Gets or sets alias for this user payment method settings
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets default currency 
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Description for payment method
        /// </summary>
        public string Description { get; set; }
    }
}
