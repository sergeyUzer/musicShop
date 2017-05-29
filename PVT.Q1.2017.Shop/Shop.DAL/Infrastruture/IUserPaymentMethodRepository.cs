namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The user payment method repository
    /// </summary>
    public interface IUserPaymentMethodRepository : IRepository<UserPaymentMethod>
    {
    }
}