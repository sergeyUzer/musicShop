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

    public class UserRepositoryMoq
    {
        private readonly Mock<IUserRepository> _mock;
        private readonly List<User> _users = new List<User>();

        public UserRepositoryMoq()
        {
            _mock = new Mock<IUserRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_users);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<User, BaseEntity>>[]>()))
                .Returns(_users);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(_users);

            _mock.Setup(
                       m =>
                           m.GetAll(It.IsAny<Expression<Func<User, bool>>>(),
                                    It.IsAny<Expression<Func<User, BaseEntity>>[]>()))
                .Returns(_users);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                 .Returns(() => _users.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>(),
                                             It.IsAny<Expression<Func<User, BaseEntity>>[]>()))
                 .Returns(() => _users.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(() => _users.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(), It.IsAny<Expression<Func<User, BaseEntity>>[]>()))
                .Returns(() => _users.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>()))
                 .Returns(() => _users.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<User, bool>>>()))
                 .Returns(() => _users.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<User>())).Callback(() => _users.Add(new User
            {
                Id = _users.Count + 1
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<User>())).Callback(() =>
            {
                if (_users.Any())
                {
                    _users.RemoveAt(_users.Count - 1);
                }
            });
        }

        public IUserRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}