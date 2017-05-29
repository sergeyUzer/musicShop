namespace PVT.Q1._2017.Shop.Tests.Moq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Moq;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;

    public class PaymentTransactionRepositoryMoq
    {
        private readonly Mock<IPaymentTransactionRepository> _mock;
        private readonly List<PaymentTransaction> _paymentTransactions = new List<PaymentTransaction>();

        public PaymentTransactionRepositoryMoq()
        {
            _mock = new Mock<IPaymentTransactionRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_paymentTransactions);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PaymentTransaction, BaseEntity>>[]>()))
                .Returns(_paymentTransactions);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PaymentTransaction, bool>>>()))
                .Returns(_paymentTransactions);

            _mock.Setup(
                       m =>
                           m.GetAll(It.IsAny<Expression<Func<PaymentTransaction, bool>>>(),
                                    It.IsAny<Expression<Func<PaymentTransaction, BaseEntity>>[]>()))
                .Returns(_paymentTransactions);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<PaymentTransaction, bool>>>()))
                 .Returns(() => _paymentTransactions.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<PaymentTransaction, bool>>>(),
                                             It.IsAny<Expression<Func<PaymentTransaction, BaseEntity>>[]>()))
                 .Returns(() => _paymentTransactions.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(() => _paymentTransactions.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                      It.IsAny<Expression<Func<PaymentTransaction, BaseEntity>>[]>()))
                .Returns(() => _paymentTransactions.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<PaymentTransaction, bool>>>()))
                 .Returns(() => _paymentTransactions.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<PaymentTransaction, bool>>>()))
                 .Returns(() => _paymentTransactions.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<PaymentTransaction>())).Callback(() => _paymentTransactions.Add(new PaymentTransaction
            {
                Id = _paymentTransactions.Count + 1
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<PaymentTransaction>())).Callback(() =>
            {
                if (_paymentTransactions.Any())
                {
                    _paymentTransactions.RemoveAt(_paymentTransactions.Count - 1);
                }
            });
        }

        public IPaymentTransactionRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}