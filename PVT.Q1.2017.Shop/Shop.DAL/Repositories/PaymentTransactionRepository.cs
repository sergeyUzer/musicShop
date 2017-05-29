namespace Shop.DAL.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Models;
    using System.Data.Entity;
    using Infrastruture;

    public class PaymentTransactionRepository:BaseRepository<PaymentTransaction>, IPaymentTransactionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentTransactionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public PaymentTransactionRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
