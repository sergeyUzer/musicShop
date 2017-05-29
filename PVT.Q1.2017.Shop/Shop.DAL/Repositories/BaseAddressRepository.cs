namespace Shop.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The base address repository
    /// </summary>
    public class BaseAddressRepository : BaseRepository<BaseAddress>, IBaseAddressRepository
    {
        /// <summary>
        /// Default ctor on dbContext
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public BaseAddressRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns all entities from the repository.
        /// </summary>
        /// <returns>
        /// All entities from the repository.
        /// </returns>
        protected ICollection<BaseAddress> GetAll()
        {
            var result = CurrentDbSet;
            return result.ToList();
        }

        /// <summary>
        /// Gets all entity by some filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns></returns>
        protected ICollection<BaseAddress> GetAll(Expression<Func<BaseAddress, bool>> filter)
        {
            IQueryable<BaseAddress> query = CurrentDbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
