using Shop.Common.Models;
using Shop.Infrastructure.Repositories;

namespace Shop.DAL.Infrastruture
{
    /// <summary>
    /// The album repository
    /// </summary>
    public interface IAlbumRepository : IRepository<Album>
    {
    }
}