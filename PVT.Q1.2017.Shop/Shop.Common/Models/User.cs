namespace Shop.Common.Models
{
    using System;
    using Infrastructure.Enums;
    using Infrastructure.Models;

    /// <summary>
    /// Basic user model for registration in the shop
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Users login (nickname)
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Users password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Users e-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Users birth date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Users role in this shop
        /// </summary>
        public UserRoles UserRole { get; set; }

        /// <summary>
        /// Id of specific country in the database
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Verification of email confirmation
        /// </summary>
        public bool ConfirmedEmail { get; set; }
    }
}
