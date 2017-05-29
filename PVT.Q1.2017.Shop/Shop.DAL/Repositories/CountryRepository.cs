namespace Shop.DAL.Repositories
{
    using Shop.Common.Models;
    using Shop.DAL.Infrastruture;
    using System.Data.Entity;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext dbContext):base(dbContext)
        {
        }

        void ICountryRepository.MarkAsDeleted(int id)
        {
            base.MarkAsDeleted(id);
        }
    }
}
