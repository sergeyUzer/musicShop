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

    public class AlbumPriceRepositoryMoq
    {
        private readonly List<AlbumPrice> _albumPrices = new List<AlbumPrice>();
        private readonly Mock<IAlbumPriceRepository> _mock;

        public AlbumPriceRepositoryMoq()
        {
            _mock = new Mock<IAlbumPriceRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_albumPrices);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()))
                 .Returns(_albumPrices);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<AlbumPrice, bool>>>()))
                 .Returns(_albumPrices);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<AlbumPrice, bool>>>(),
                                     It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()))
                 .Returns(_albumPrices);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<AlbumPrice, bool>>>()))
                 .Returns(() => _albumPrices.FirstOrDefault());

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<AlbumPrice, bool>>>()))
                 .Returns(() => _albumPrices.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<AlbumPrice, bool>>>()))
                 .Returns(() => _albumPrices.Count);

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<AlbumPrice, bool>>>(),
                                             It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()))
                 .Returns(() => _albumPrices.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _albumPrices.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(), It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()))
                 .Returns(() => _albumPrices.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<AlbumPrice>())).Callback(() => _albumPrices.Add(new AlbumPrice
            {
                Id = _albumPrices.Count + 1,
                Price = _albumPrices.Count + 1.49m
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<AlbumPrice>())).Callback(() =>
            {
                if (_albumPrices.Any())
                {
                    _albumPrices.RemoveAt(_albumPrices.Count - 1);
                }
            });
        }

        public IAlbumPriceRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}