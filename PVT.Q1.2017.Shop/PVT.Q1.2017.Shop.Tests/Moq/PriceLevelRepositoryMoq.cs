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

    public class PriceLevelRepositoryMoq
    {
        private readonly Mock<IPriceLevelRepository> _mock;
        private readonly List<PriceLevel> _priceLevels = new List<PriceLevel>();

        public PriceLevelRepositoryMoq()
        {
            _mock = new Mock<IPriceLevelRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_priceLevels);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PriceLevel, BaseEntity>>[]>()))
                 .Returns(_priceLevels);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PriceLevel, bool>>>()))
                 .Returns(_priceLevels);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<PriceLevel, bool>>>(),
                                     It.IsAny<Expression<Func<PriceLevel, BaseEntity>>[]>()))
                 .Returns(_priceLevels);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<PriceLevel, bool>>>()))
                 .Returns(() => _priceLevels.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<PriceLevel, bool>>>(),
                                             It.IsAny<Expression<Func<PriceLevel, BaseEntity>>[]>()))
                 .Returns(() => _priceLevels.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _priceLevels.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<PriceLevel, BaseEntity>>[]>()))
                 .Returns(() => _priceLevels.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<PriceLevel, bool>>>()))
                 .Returns(() => _priceLevels.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<PriceLevel, bool>>>()))
                 .Returns(() => _priceLevels.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<PriceLevel>())).Callback(() => _priceLevels.Add(new PriceLevel
            {
                Id = _priceLevels.Count + 1,
                Name = $"PriceLevel{_priceLevels.Count + 1}"
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<PriceLevel>())).Callback(() =>
            {
                if (_priceLevels.Any())
                {
                    _priceLevels.RemoveAt(_priceLevels.Count - 1);
                }
            });

            _mock.Setup(m => m.GetDefaultPriceLevel()).Returns(new PriceLevel { Id = 1, Name = "Some Price Level" });
        }

        public IPriceLevelRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}