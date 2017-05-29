namespace PVT.Q1._2017.Shop.Tests.Moq
{
    using global::Moq;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    class SettingRepositoryMoq
    {
        private readonly List<Setting> _setting = new List<Setting>();
        private readonly Mock<ISettingRepository> _mock;

        public SettingRepositoryMoq()
        {
            _setting.Add(new Setting { DefaultCurrencyId = 1, DefaultCurrency = new Currency { Code = 840, ShortName = "USD", FullName = "US Dollar"} });

            _mock = new Mock<ISettingRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_setting);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Setting, BaseEntity>>[]>()))
                 .Returns(_setting);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Setting, bool>>>()))
                 .Returns(_setting);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Setting, bool>>>(),
                                     It.IsAny<Expression<Func<Setting, BaseEntity>>[]>()))
                 .Returns(_setting);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<Setting, bool>>>()))
                 .Returns(() => _setting.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Setting, bool>>>(),
                                             It.IsAny<Expression<Func<Setting, BaseEntity>>[]>()))
                 .Returns(() => _setting.FirstOrDefault());

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<Setting, bool>>>()))
                 .Returns(() => _setting.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<Setting, bool>>>()))
                 .Returns(() => _setting.Count);

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _setting.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<Setting, BaseEntity>>[]>()))
                 .Returns(() => _setting.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<Setting>())).Callback(() => _setting.Add(new Setting
            {
                Id = _setting.Count + 1
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<Setting>())).Callback(() =>
            {
                if (_setting.Any())
                {
                    _setting.RemoveAt(_setting.Count - 1);
                }
            });
        }

        public ISettingRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}
