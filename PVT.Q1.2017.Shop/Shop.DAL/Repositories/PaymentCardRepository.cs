namespace Shop.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastruture;
    using Shop.Common.Models;
    using Shop.Infrastructure.Repositories;

    /// <summary>
    /// Repository for PaymentCard 
    /// </summary>
    public class PaymentCardRepository : BaseRepository<PaymentCard>, IPaymentCardRepository
    {
        /// <summary>
        /// Default ctor on dbContext
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public PaymentCardRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns all entities from the repository.
        /// </summary>
        /// <returns>
        /// All entities from the repository.
        /// </returns>
        protected ICollection<PaymentCard> GetAll()
        {
            var result = CurrentDbSet;
            return result.ToList();
        }

        /// <summary>
        /// Gets all entity by some filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns></returns>
        protected ICollection<PaymentCard> GetAll(Expression<Func<PaymentCard, bool>> filter)
        {
            IQueryable<PaymentCard> query = CurrentDbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
