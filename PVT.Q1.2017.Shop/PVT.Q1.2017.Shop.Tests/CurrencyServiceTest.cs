namespace PVT.Q1._2017.Shop.Tests
{
    using System.Linq;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CurrencyServiceTest
    {
        private readonly ICurrencyService _currencyService;
        private readonly IRepositoryFactory _factory;

        public CurrencyServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _currencyService = new CurrencyService(_factory);
        }

        [TestMethod]
        public void AddCurrenciesTest()
        {
            int currencyCode = 840;
            string currencyName = "USD";

            using (var repository = _factory.GetCurrencyRepository())
            {
                repository.AddOrUpdate(new Currency { ShortName = currencyName, Code = currencyCode });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetCurrenciesListTest()
        {
            AddCurrenciesTest();
            Assert.IsTrue(_currencyService.GetCurrencies().Any());
        }

        [TestMethod]
        public void GetCurrencyByCodeTest()
        {
            AddCurrenciesTest();
            Assert.IsNotNull(_currencyService.GetCurrencyByCode(840));
        }

        [TestMethod]
        public void GetCurrencyByNameTest()
        {
            AddCurrenciesTest();
            Assert.IsNotNull(_currencyService.GetCurrencyByName("byn"));
        }

        [TestMethod]
        public void GetCurrencyInfoTest()
        {
            AddCurrenciesTest();
            Assert.IsNotNull(_currencyService.DefaultCurrency);
        }
    }
}