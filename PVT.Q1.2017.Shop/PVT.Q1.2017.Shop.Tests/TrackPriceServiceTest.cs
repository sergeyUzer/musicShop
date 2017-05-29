using Shop.DAL.Infrastruture;

namespace PVT.Q1._2017.Shop.Tests
{
    using System.Linq;
    using global::Shop.BLL;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ninject;

    [TestClass]
    public class TrackPriceServiceTest
    {
        #region Fields

        private readonly ITrackPriceService _trackPriceService;
        private readonly IRepositoryFactory _factory;

        #endregion //Fields

        #region Constructors

        public TrackPriceServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _trackPriceService = new TrackPriceService(_factory);
        }

        #endregion //Constructors

        #region Tests

        [TestMethod]
        public void AddTrackPriceTest()
        {
            using (var repository = _factory.GetTrackPriceRepository())
            {
                repository.AddOrUpdate(new TrackPrice { Price = 1.99m });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetTrackPriceTest()
        {
            AddTrackPriceTest();
            Assert.IsNotNull(_trackPriceService.GetTrackPrice(1));
        }

        [TestMethod]
        public void GetTrackPriceInfoTest()
        {
            AddTrackPriceTest();
            Assert.IsNotNull(_trackPriceService.GetTrackPrices(1));
            Assert.IsTrue(_trackPriceService.GetTrackPrices(1).Any());
        }

        #endregion //Tests
    }
}