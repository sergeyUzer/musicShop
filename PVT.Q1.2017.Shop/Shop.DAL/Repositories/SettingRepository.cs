namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
