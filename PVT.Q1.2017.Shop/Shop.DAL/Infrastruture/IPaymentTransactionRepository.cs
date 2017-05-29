namespace Shop.DAL.Infrastruture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Shop.Common.Models;
    using Shop.Infrastructure.Repositories;

    /// <summary>
    /// Payment transaction repository
    /// </summary>
    public interface IPaymentTransactionRepository: IRepository<PaymentTransaction>
    {
    }
}
