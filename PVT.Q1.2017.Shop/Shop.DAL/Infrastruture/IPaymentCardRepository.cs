
namespace Shop.DAL.Infrastruture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Shop.Common.Models;
    using Infrastructure.Repositories;

    public interface IPaymentCardRepository : IRepository<PaymentCard>
    {
    }
}
