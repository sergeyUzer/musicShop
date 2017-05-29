using Shop.Common.Models;
using Shop.Infrastructure.Repositories;

namespace Shop.DAL.Infrastruture
{
    /// <summary>
    /// The user repository.
    /// </summary>
    public interface IUserDataRepository : IRepository<UserData>
    {
    }
}