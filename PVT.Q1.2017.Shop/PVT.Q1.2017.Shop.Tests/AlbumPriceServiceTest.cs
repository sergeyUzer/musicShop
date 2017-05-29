using Shop.DAL.Infrastruture;

namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Moq;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Infrastructure.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class AlbumPriceServiceTest
    {
        private readonly IAlbumPriceService _albumPriceService;
        private readonly IRepositoryFactory _factory;

        public AlbumPriceServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _albumPriceService = new AlbumPriceService(_factory);
        }

        [TestMethod]
        public void AddAlbumPricesTest()
        {
            using (var repository = _factory.GetAlbumPriceRepository())
            {
                repository.AddOrUpdate(new AlbumPrice { Price = 9.99m });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetAlbumPriceTest()
        {
            AddAlbumPricesTest(); 
            Assert.IsNotNull(_albumPriceService.GetAlbumPrice(1, 840, 1));

            Mock.Get(_factory.GetAlbumPriceRepository())
                .Verify(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<AlbumPrice, bool>>>(),
                                             It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()), Times.Once);
        }

        [TestMethod]
        public void GetTrackPriceInfoTest()
        {
            AddAlbumPricesTest();
            Assert.IsNotNull(_albumPriceService.GetAlbumPrice(1));

            Mock.Get(_factory.GetAlbumPriceRepository())
                .Verify(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<AlbumPrice, bool>>>(),
                                             It.IsAny<Expression<Func<AlbumPrice, BaseEntity>>[]>()), Times.Once);
        }
    }
}