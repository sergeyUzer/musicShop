using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Common.Models;
using Moq;
using System.Collections.Generic;
using PVT.Q1._2017.Shop.Areas.Payment.Controllers;
using Shop.DAL.Infrastruture;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Linq;
using Shop.BLL.Services.Infrastructure;

namespace PVT.Q1._2017.Shop.Tests
{
    using global::Shop.BLL.Exceptions;
    using global::Shop.BLL.Utils;
    using global::Shop.Common.ViewModels;
    using Moq;
    using System.Web;
    using System.Web.Routing;

    [TestClass]
    public class CartControllerTests
    {
        public Mock<HttpContextBase> TestInitialize()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var session = new HttpSessionMock();
            var currentUser = new CurrentUser(new User { Id = 1 }, 1, 1);
            context
                .Setup(c => c.Request)
                .Returns(request.Object);
            context
                .Setup(c => c.User)
                .Returns(currentUser);
            context
                .Setup(c => c.Session)
                .Returns(session);
            return context;
        }

        [TestMethod]
        public void CartController_ActionIndexTest()
        {
            Mock<ICartService> moqCartService = new Mock<ICartService>();
            moqCartService.Setup(m => m.GetOrderTracks(It.IsAny<int>(), It.IsAny<Nullable<int>>())).Returns(new List<TrackDetailsViewModel>());
            moqCartService.Setup(m => m.GetOrderAlbums(It.IsAny<int>(), It.IsAny<Nullable<int>>())).Returns(new List<AlbumDetailsViewModel>());

            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);
            var result = cartController.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CartController_AddTrackToCart()
        {
            Mock<IOrderTrackRepository> moqOrderTrackRepository = new Mock<IOrderTrackRepository>();

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();
            moqRepositoryFactory.Setup(m => m.GetOrderTrackRepository()).Returns(moqOrderTrackRepository.Object);

            Mock<ICartService> moqCartService = new Mock<ICartService>();
            moqCartService.Setup(m => m.AddTrack(It.Is<int>(u => u > 0), It.Is<int>(t => t >0)));
            moqCartService.Setup(m => m.AddTrack(It.Is<int>(u => u == 0), It.Is<int>(t => t > 0))).Throws<CartServiceException>();
            moqCartService.Setup(m => m.AddTrack(It.Is<int>(u => u > 0), It.Is<int>(t => t == 0))).Throws<CartServiceException>();

            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);

            var result = (RedirectToRouteResult)cartController.AddTrack(3);
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Cart", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var result1 = cartController.AddTrack(0);
            Assert.IsInstanceOfType(result1, typeof(HttpNotFoundResult));
        }
        
        [TestMethod]
         public void CartController_AddAlbumToCart()
         {
            Mock<IOrderTrackRepository> moqOrderTrackRepository = new Mock<IOrderTrackRepository>();

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();
            moqRepositoryFactory.Setup(m => m.GetOrderTrackRepository()).Returns(moqOrderTrackRepository.Object);

            Mock<ICartService> moqCartService = new Mock<ICartService>();
            moqCartService.Setup(m => m.AddAlbum(It.Is<int>(u => u > 0), It.Is<int>(t => t > 0)));
            moqCartService.Setup(m => m.AddAlbum(It.Is<int>(u => u == 0), It.Is<int>(t => t > 0))).Throws<CartServiceException>();
            moqCartService.Setup(m => m.AddAlbum(It.Is<int>(u => u > 0), It.Is<int>(t => t == 0))).Throws<CartServiceException>();

            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);

            var result = (RedirectToRouteResult)cartController.AddAlbum(3);
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Cart", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var result1 = cartController.AddAlbum(0);
            Assert.IsInstanceOfType(result1, typeof(HttpNotFoundResult));
         }

        [TestMethod]
        public void CartController_DeleteTrackFromCart()
        {
            Mock<IOrderTrackRepository> moqOrderTrackRepository = new Mock<IOrderTrackRepository>();

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();
            moqRepositoryFactory.Setup(m => m.GetOrderTrackRepository()).Returns(moqOrderTrackRepository.Object);

            Mock<ICartService> moqCartService = new Mock<ICartService>();
            moqCartService.Setup(m => m.RemoveTrack(It.Is<int>(u => u > 0), It.Is<int>(t => t > 0)));
            moqCartService.Setup(m => m.RemoveTrack(It.Is<int>(u => u == 0), It.Is<int>(t => t > 0))).Throws<CartServiceException>();
            moqCartService.Setup(m => m.RemoveTrack(It.Is<int>(u => u > 0), It.Is<int>(t => t == 0))).Throws<CartServiceException>();

            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);

            var result = (RedirectToRouteResult)cartController.DeleteTrack(3);
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Cart", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var result1 = cartController.DeleteTrack(0);
            Assert.IsInstanceOfType(result1, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void CartController_DeleteAlbumFromCart()
        {
            Mock<IOrderTrackRepository> moqOrderTrackRepository = new Mock<IOrderTrackRepository>();

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();
            moqRepositoryFactory.Setup(m => m.GetOrderTrackRepository()).Returns(moqOrderTrackRepository.Object);

            Mock<ICartService> moqCartService = new Mock<ICartService>();
            moqCartService.Setup(m => m.RemoveAlbum(It.Is<int>(u => u > 0), It.Is<int>(t => t > 0)));
            moqCartService.Setup(m => m.RemoveAlbum(It.Is<int>(u => u == 0), It.Is<int>(t => t > 0))).Throws<CartServiceException>();
            moqCartService.Setup(m => m.RemoveAlbum(It.Is<int>(u => u > 0), It.Is<int>(t => t == 0))).Throws<CartServiceException>();

            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);

            var result = (RedirectToRouteResult)cartController.DeleteAlbum(3);
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Cart", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var result1 = cartController.DeleteAlbum(0);
            Assert.IsInstanceOfType(result1, typeof(HttpNotFoundResult));
         }
        [TestMethod]
        public void CartController_GetOrdersCount()
        {
            IList<OrderTrack> tracks = new List<OrderTrack>
            {
                new OrderTrack { UserId = 1, Track = new Track { Id = 1, Name = "Wide Awake" } },
                new OrderTrack { UserId = 1, Track = new Track { Id = 2, Name = "Be mine" } },
            };

            IList<OrderAlbum> albums = new List<OrderAlbum>
           {
               new OrderAlbum { UserId=1, Album = new Album { Id = 1, Name = "Gold" } },
               new OrderAlbum { UserId=1, Album = new Album { Id = 2, Name = "Platinum" } },
           };

            Mock<IUserDataRepository> moqUserDataRepository = new Mock<IUserDataRepository>();
            moqUserDataRepository.Setup(m => m.GetById(It.Is<int>(t => t > 0))).Returns(new UserData { UserId = 1, OrderTracks = tracks, OrderAlbums = albums });

            Mock<IRepositoryFactory> moqRepositoryFactory = new Mock<IRepositoryFactory>();
            moqRepositoryFactory.Setup(m => m.GetUserDataRepository()).Returns(moqUserDataRepository.Object);

            Mock<ICartService> moqCartService = new Mock<ICartService>();
            Mock<IServiceFactory> moqServiceFactory = new Mock<IServiceFactory>();
            moqServiceFactory.Setup(m => m.GetCartService()).Returns(moqCartService.Object);

            var cartController = new CartController(moqRepositoryFactory.Object, moqServiceFactory.Object);
            var context = TestInitialize();
            cartController.ControllerContext = new ControllerContext(context.Object, new RouteData(), cartController);
            var result = cartController.GetOrdersCount();
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        } 
    }
}