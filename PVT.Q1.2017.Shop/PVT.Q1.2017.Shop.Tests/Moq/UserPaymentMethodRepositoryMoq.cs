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

    public class UserPaymentMethodRepositoryMoq
    {
        private readonly Mock<IUserPaymentMethodRepository> _mock;
        private readonly List<UserPaymentMethod> _userPaymentMethods = new List<UserPaymentMethod>();

        public UserPaymentMethodRepositoryMoq()
        {
            _mock = new Mock<IUserPaymentMethodRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_userPaymentMethods);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<UserPaymentMethod, BaseEntity>>[]>()))
                .Returns(_userPaymentMethods);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>()))
                .Returns(_userPaymentMethods);

            _mock.Setup(
                       m =>
                           m.GetAll(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>(),
                                    It.IsAny<Expression<Func<UserPaymentMethod, BaseEntity>>[]>()))
                .Returns(_userPaymentMethods);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>()))
                 .Returns(() => _userPaymentMethods.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>(),
                                             It.IsAny<Expression<Func<UserPaymentMethod, BaseEntity>>[]>()))
                 .Returns(() => _userPaymentMethods.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(() => _userPaymentMethods.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                      It.IsAny<Expression<Func<UserPaymentMethod, BaseEntity>>[]>()))
                .Returns(() => _userPaymentMethods.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>()))
                 .Returns(() => _userPaymentMethods.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<UserPaymentMethod, bool>>>()))
                 .Returns(() => _userPaymentMethods.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<UserPaymentMethod>())).Callback(() => _userPaymentMethods.Add(new UserPaymentMethod
            {
                Id = _userPaymentMethods.Count + 1
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<UserPaymentMethod>())).Callback(() =>
            {
                if (_userPaymentMethods.Any())
                {
                    _userPaymentMethods.RemoveAt(_userPaymentMethods.Count - 1);
                }
            });
        }

        public IUserPaymentMethodRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}