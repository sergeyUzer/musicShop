using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Services.Infrastructure;
using Shop.DAL.Infrastruture;
using PVT.Q1._2017.Shop.Tests.Moq;
using Shop.BLL.Services;

namespace PVT.Q1._2017.Shop.Tests
{
    /// <summary>
    /// Summary description for PaymentServiceTest
    /// </summary>
    [TestClass]
    public class PaymentServiceTest
    {

        private readonly IPaymentService _paymentService;
        private readonly IRepositoryFactory _factory;
      
        public PaymentServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _paymentService = new PaymentService(_factory);
        }
               
        [TestMethod]
        public void TestPaymentWithPayPal_InvalidArgument()
        {
            var result = _paymentService.PaymentWithPaypal(null, null);
            Assert.AreSame("Failure", result);
        }
    }
}
