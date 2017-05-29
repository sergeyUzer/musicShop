namespace PVT.Q1._2017.Shop.Tests.BllServiceTests
{
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Linq;

    [TestClass]
    public class CurrencyRateServiceTest
    {
        private ICurrencyRateService _rateService;

        public CurrencyRateServiceTest()
        {
            _rateService = new CurrencyRateService(new RepositoryFactoryMoq());
        }

        // usd.id = 1
        // eur.id = 2
        [TestMethod]
        public void GetActualRateTest()
        {
            var rates = _rateService.GetActualRates(DateTime.Now);

            // should be one rate for each of currency pair
            Assert.IsTrue(rates.Any());

            // usd/eur = 0.9m should be as actual
            Assert.AreEqual(rates.First(r => r.CurrencyId == 1 && r.TargetCurrencyId == 2).CrossCourse, 0.9m);
        }

        [TestMethod]
        public void GetRateByDate()
        {
            // usd/eur = 0.9m should for current date
            Assert.AreEqual(_rateService.GetRateByDate(1, 2, DateTime.Now), 0.9m);
        }
    }
}
