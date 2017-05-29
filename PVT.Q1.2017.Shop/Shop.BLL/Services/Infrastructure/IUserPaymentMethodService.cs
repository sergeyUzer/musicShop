namespace Shop.BLL.Services.Infrastructure
{
    using System.Collections.Generic;
    using Shop.Common.Models;

    /// <summary>
    /// The UserPaymentMethod service
    /// </summary>
    public interface IUserPaymentMethodService
    {
        /// <summary>
        /// Returns all UserPaymentMethods that the specified <paramref name="user"/> have ever made.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// All UserPaymentMethods that the specified <paramref name="user"/> have ever made.
        /// </returns>
        ICollection<UserPaymentMethod> UserPaymentMethodsByUser(UserData user);
    }
}