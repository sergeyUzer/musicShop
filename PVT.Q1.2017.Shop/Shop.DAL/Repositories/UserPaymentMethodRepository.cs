namespace Shop.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Shop.Common.Models;
    using Shop.Infrastructure.Repositories;
    using Infrastruture;

    /// <summary>
    /// Repository for UserPaymentMethod 
    /// </summary>
    public class UserPaymentMethodRepository : BaseRepository<UserPaymentMethod>, IUserPaymentMethodRepository
    {
        /// <summary>
        /// Default ctor on dbContext
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public UserPaymentMethodRepository(DbContext dbContext) : base(dbContext)
        {            
        }

        /// <summary>
        /// Returns all entities from the repository.
        /// </summary>
        /// <returns>
        /// All entities from the repository.
        /// </returns>
        protected ICollection<UserPaymentMethod> GetAll()
        {
            var result = CurrentDbSet;
            return result.ToList();
        }

        /// <summary>
        /// Gets all entity by some filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns></returns>
        protected ICollection<UserPaymentMethod> GetAll(Expression<Func<UserPaymentMethod, bool>> filter)
        {
            IQueryable<UserPaymentMethod> query = CurrentDbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
