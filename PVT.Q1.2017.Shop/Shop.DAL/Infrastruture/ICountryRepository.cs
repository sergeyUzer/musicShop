namespace Shop.DAL.Infrastruture
{
    using Shop.Common.Models;
    using Shop.Infrastructure.Repositories;

    /// <summary>
    /// 
    /// </summary>
    public interface ICountryRepository : IRepository<Country>
    {
        void MarkAsDeleted(int id);
    }
}
