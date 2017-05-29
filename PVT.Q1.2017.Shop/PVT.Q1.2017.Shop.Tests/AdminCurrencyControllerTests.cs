using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.DAL.Infrastruture;
using Shop.BLL.Services.Infrastructure;
using System.Collections.Generic;
using Shop.Common.Models;
using PVT.Q1._2017.Shop.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace PVT.Q1._2017.Shop.Tests
{
    using global::Shop.Common.ViewModels;

    [TestClass]
    public class AdminCurrencyControllerTests
    {
        [TestMethod]
        public void Index_Contains_All_Currencies()
        {
            // Arrange - create the mock service
            var currencyRepositoryMoq = new Mock<IRepositoryFactory>();
            var mockService = new Mock<IServiceFactory>();

            mockService.Setup(x => x.GetCurrencyService().GetCurrencies()).Returns(new List<CurrencyViewModel>()
            {
                new CurrencyViewModel {ShortName = "USD", Code = 840},
                new CurrencyViewModel {ShortName = "EUR", Code = 978}
            });

            var controller = new CurrencyController(currencyRepositoryMoq.Object, mockService.Object);

            // Act
            var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result.Model, typeof(List<CurrencyViewModel>));
			Assert.IsTrue(((List<CurrencyViewModel>)result.Model).Count == 2);
		}

        [TestMethod]
        public void Can_Edit_Currency()
        {
            var currencyRepositoryMoq = new Mock<IRepositoryFactory>();
	        var mockService = new Mock<IServiceFactory>();

			// Arrange 
			var controller = new CurrencyController(currencyRepositoryMoq.Object, mockService.Object);

            // Act
	        var result = controller.Edit(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Currencies()
        {
            // Arrange - create the mock repository
            var mockRepository = new Mock<IRepositoryFactory>();
            mockRepository.Setup(x => x.GetCurrencyRepository().GetAll()).Returns(new List<Currency>()
            {
                new Currency { Id = 1, ShortName = "USD" },
                new Currency { Id = 2, ShortName = "Euro" },
                new Currency { Id = 3, ShortName = "BYR" }
            });

            // Arrange - create the mock service
            var mockService = new Mock<IServiceFactory>();

            // Arrange - create the controller
            var target = new CurrencyController(mockRepository.Object, mockService.Object);

            // Act - delete the service
            var result = target.Delete(0);

			// Assert
			Assert.AreEqual("Index", ((RedirectToRouteResult)result).RouteValues["action"]);
        }
    }
}
