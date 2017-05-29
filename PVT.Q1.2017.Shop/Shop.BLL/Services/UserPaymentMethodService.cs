namespace Shop.BLL.Services
{
    using System.Collections.Generic;
    using Common.Models;
    using DAL.Infrastruture;
    using Infrastructure;

    /// <summary>
    /// The user payment method service
    /// </summary>
    public class UserPaymentMethodService : BaseService, IUserPaymentMethodService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPaymentMethodService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        public UserPaymentMethodService(IRepositoryFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Returns all payment methods available for the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        ///  All payment methods available for the specified <paramref name="user"/>.
        /// </returns>
        public ICollection<UserPaymentMethod> UserPaymentMethodsByUser(UserData user)
        {
            if (user != null)
            {
                using (var repository = Factory.GetUserPaymentMethodRepository())
                {
                    return repository.GetAll(a => a.User.Equals(user));
                }
            }

            return null;
        }
    }
}
