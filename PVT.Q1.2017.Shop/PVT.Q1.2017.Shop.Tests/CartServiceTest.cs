using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PVT.Q1._2017.Shop.Tests.Moq;
using Shop.BLL;
using Shop.BLL.Services;
using Shop.BLL.Services.Infrastructure;
using Shop.Common.Models;
using Shop.DAL.Infrastruture;

namespace PVT.Q1._2017.Shop.Tests
{
	[TestClass]
	public class CartServiceTest
	{
		private readonly ICartService _cartService;
		private readonly IRepositoryFactory _factory;

		public CartServiceTest()
		{
			_factory = new RepositoryFactoryMoq();
			_cartService = new CartService(_factory);
		}

		[TestMethod]
		public void AddCartTest()
		{
            using (var repo = _factory.GetUserDataRepository())
			{
				repo.AddOrUpdate(new UserData() {UserId = 1});
				repo.SaveChanges();

				Assert.IsTrue(repo.GetAll().Any());
			}
		}

		[TestMethod]
		public void AddTrackToCart_Test()
		{
            using (var repo = _factory.GetTrackRepository())
			{
				repo.AddOrUpdate(new Track { Id = 1, Name = "Track1"});
				repo.SaveChanges();
            }
            AddCartTest();
            _cartService.AddTrack(1, 1);
            using (var repo = _factory.GetOrderTrackRepository())
            {
                Assert.IsTrue(repo.Exist(r => r.UserId == 1 && r.TrackId == 1));
            }
        }

	    [TestMethod]
	    public void AddTrackListToCart_Test()
	    {
            using (var repo = _factory.GetTrackRepository())
            {
                repo.AddOrUpdate(new Track { Id = 1 });
                repo.AddOrUpdate(new Track { Id = 2 });
                repo.AddOrUpdate(new Track { Id = 3 });
                repo.SaveChanges();
            }
            AddCartTest();
	        var trackIds = new int[] {1, 2, 3};
            _cartService.AddTrack(1, trackIds);
            using (var repo = _factory.GetOrderTrackRepository())
            {
                var result = repo.GetAll(r => r.UserId == 1);
                Assert.IsTrue(result.Count == 3);
            }
        }

        [TestMethod]
        public void AddAlbumToCart_Test()
        {
            using (var repo = _factory.GetAlbumRepository())
            {
                repo.AddOrUpdate(new Album { Id = 1 });
                repo.SaveChanges();
            }
            AddCartTest();
            _cartService.AddAlbum(1, 1);
            using (var repo = _factory.GetOrderAlbumRepository())
            {
                Assert.IsTrue(repo.Exist(r => r.UserId == 1 && r.AlbumId == 1));
            }
        }

        [TestMethod]
        public void AddAlbumListToCart_Test()
        {
            using (var repo = _factory.GetAlbumRepository())
            {
                repo.AddOrUpdate(new Album { Id = 1 });
                repo.AddOrUpdate(new Album { Id = 2 });
                repo.AddOrUpdate(new Album { Id = 3 });
                repo.SaveChanges();
            }
            AddCartTest();
            var albumIds = new int[] { 1, 2, 3 };
            _cartService.AddAlbum(1, albumIds);
            using (var repo = _factory.GetOrderAlbumRepository())
            {
                var result = repo.GetAll(r => r.UserId == 1);
                Assert.IsTrue(result.Count == 3);
            }
        }

	    [TestMethod]
	    public void RemoveTrackFromCart_Test()
	    {
	        AddTrackToCart_Test();
            _cartService.RemoveTrack(1, 1);
	        using (var repo = _factory.GetOrderTrackRepository())
	        {
	            Assert.IsFalse(repo.Exist(r => r.UserId == 1 && r.TrackId == 1));
	        }
	    }

	    [TestMethod]
	    public void RemoveTrackListFromCart_Test()
	    {
	        AddTrackListToCart_Test();
	        var trackIds = new int[] {1, 2, 3};
            _cartService.RemoveTrack(1, trackIds);
	        using (var repo = _factory.GetOrderTrackRepository())
	        {
	            var result = repo.GetAll(r => r.UserId == 1);
	            Assert.IsFalse(result.Any());
	        }
	    }

	    [TestMethod]
	    public void RemoveAlbumFromCart_Test()
	    {
	        AddAlbumToCart_Test();
            _cartService.RemoveAlbum(1, 1);
	        using (var repo = _factory.GetOrderAlbumRepository())
	        {
	            Assert.IsFalse(repo.Exist(r => r.UserId == 1 && r.AlbumId == 1));
	        }
	    }

	    [TestMethod]
	    public void RemoveAlbumsListFromCart_Test()
	    {
	        AddAlbumListToCart_Test();
	        var albumIds = new int[] {1, 2, 3};
            _cartService.RemoveAlbum(1, albumIds);
	        using (var repo = _factory.GetOrderAlbumRepository())
	        {
	            var result = repo.GetAll(r => r.UserId == 1);
                Assert.IsFalse(result.Any());
	        }
	    }

	    [TestMethod]
	    public void GetOrderTracksIdsInCart_Test()
	    {
	        AddTrackListToCart_Test();
            var result = _cartService.GetOrderTracksIds(1).ToArray();
	        for (int i = 1; i <= 3; i++)
	        {
	            Assert.IsTrue(result[i-1] == i);
	        }
	    }

	    [TestMethod]
	    public void GetOrderAlbumsIdsInCart_Test()
	    {
	        AddAlbumListToCart_Test();
	        var result = _cartService.GetOrderAlbumsIds(1).ToArray();
	        for (int i = 1; i <= 3; i++)
	        {
	            Assert.IsTrue(result[i-1] == i);
	        }
	    }

	    [TestMethod]
	    public void GetOrderTracksInCart_Test()
	    {
	        AddTrackListToCart_Test();
            var result = _cartService.GetOrderTracks(1);
            Assert.IsTrue(result.Count == 3);
	    }

	    [TestMethod]
	    public void GetOrderAlbumsInCart_Test()
	    {
	        AddAlbumListToCart_Test();
            var result = _cartService.GetOrderAlbums(1);
            Assert.IsTrue(result.Count == 3);
	    }

	    [TestMethod]
	    public void RemoveAllInCart_Test()
	    {
	        AddTrackListToCart_Test();
            AddAlbumListToCart_Test();
            _cartService.RemoveAll(1);
	        using (var repo = _factory.GetOrderTrackRepository())
	        {
	            var result = repo.GetAll(r => r.UserId == 1);
	            Assert.IsFalse(result.Any());
	        }

	        using (var repo = _factory.GetOrderAlbumRepository())
	        {
	            var result = repo.GetAll(r => r.UserId == 1);
                Assert.IsFalse(result.Any());
	        }
	    }

	    [TestMethod]
	    public void AcceptPaymentAllItemsInCart_Test()
	    {
	        AddTrackToCart_Test();
            AddAlbumToCart_Test();
	        
            _cartService.AcceptPayment(1);
	      
	        using (var repo = _factory.GetOrderTrackRepository())
	        {
	            Assert.IsFalse(repo.Exist(r => r.UserId == 1 && r.TrackId == 1));
	        }

	        using (var repo = _factory.GetOrderAlbumRepository())
	        {
                Assert.IsFalse(repo.Exist(r => r.UserId == 1 && r.AlbumId == 1));
            }
	    }
    }
    //TODO: test Methods with invalid inputs
}
