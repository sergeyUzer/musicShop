using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BLL.Services;
using Shop.Common.Models;
using System.Collections.Generic;

namespace PVT.Q1._2017.Shop.Tests
{
    using global::Shop.Common.ViewModels;

    [TestClass]
    public class CartViewModelServiceTests
    {
        [TestMethod]
        public void SetTotalPrice_noTracksInCart_0()
        {
            //// Set Currency
            var userCurrency = new CurrencyViewModel();
            userCurrency.Code = 840;
            userCurrency.ShortName = "USD";
            //// Create and set CartView model
            var myCartView = new CartViewModel() { Tracks = new List<TrackDetailsViewModel>() };
            CartViewModelService.SetTotalPrice(myCartView, userCurrency);
            Assert.IsTrue(myCartView.TotalPrice == 0);
        }

        [TestMethod]
        public void SetTotalPrice_120and120_240()
        {
            //// Set Currency
            var userCurrency = new CurrencyViewModel();
            userCurrency.Code = 840;
            userCurrency.ShortName = "USD";
            //// Set TrackPrices
            var priceTrack = new PriceViewModel();
            priceTrack.Currency = userCurrency;
            priceTrack.Amount = 120;
            //// Create two tracks
            var track1 = new TrackDetailsViewModel()
            {
                Name = "SuperTrack",
                Price = priceTrack
            };
            var track2 = new TrackDetailsViewModel()
            {
                Name = "SuperTrack",
                Price = priceTrack
            };
            //// Create and set CartView model
            var myCartView = new CartViewModel() { Tracks = new List<TrackDetailsViewModel>() };
            myCartView.Tracks.Add(track1);
            myCartView.Tracks.Add(track2);
            CartViewModelService.SetTotalPrice(myCartView, userCurrency);
            Assert.IsTrue(myCartView.TotalPrice == 240);
        }

        [TestMethod]
        public void SetTotalPriceWithAlbum_emptyAlbum_120()
        {
            //// Set Currency
            var userCurrency = new CurrencyViewModel();
            userCurrency.Code = 840;
            userCurrency.ShortName = "USD";
            //// Set TrackPrices
            var priceTrack = new PriceViewModel();
            priceTrack.Currency = userCurrency;
            priceTrack.Amount = 120;
            //// Create track with price = 120
            var track1 = new TrackDetailsViewModel()
            {
                Name = "SuperTrack",
                Price = priceTrack
            };
            //// Create empty album
            var album1 = new AlbumDetailsViewModel();
            //// Create and set CartView model
            var myCartView = new CartViewModel() { Tracks = new List<TrackDetailsViewModel>(),
                Albums = new List<AlbumDetailsViewModel>() };
            myCartView.Tracks.Add(track1);
            myCartView.Albums.Add(album1);
            CartViewModelService.SetTotalPrice(myCartView, userCurrency);
            Assert.IsTrue(myCartView.TotalPrice == 120);
        }

        [TestMethod]
        public void SetTotalPriceWithAlbum_150and240_390()
        {
            //// Set Currency
            var userCurrency = new CurrencyViewModel();
            userCurrency.Code = 840;
            userCurrency.ShortName = "USD";
            //// Set TrackPrices
            var priceTrack = new PriceViewModel();
            priceTrack.Currency = userCurrency;
            priceTrack.Amount = 120;
            //// Create two tracks with total price = 240
            var track1 = new TrackDetailsViewModel()
            {
                Name = "SuperTrack1",
                Price = priceTrack
            };
            var track2 = new TrackDetailsViewModel()
            {
                Name = "SuperTrack2",
                Price = priceTrack
            };
            //// Set TrackPrices
            var priceAlbum = new PriceViewModel();
            priceAlbum.Currency = userCurrency;
            priceAlbum.Amount = 150;
            //// Create album with price = 150
            var album1 = new AlbumDetailsViewModel()
            {
                Name = "MyAlbum",
                Price = priceAlbum
            };
            //// Create and set CartView model
            var myCartView = new CartViewModel() { Tracks = new List<TrackDetailsViewModel>(),
                Albums = new List<AlbumDetailsViewModel>() };
            myCartView.Tracks.Add(track1);
            myCartView.Tracks.Add(track2);
            myCartView.Albums.Add(album1);
            CartViewModelService.SetTotalPrice(myCartView, userCurrency);
            Assert.IsTrue(myCartView.TotalPrice == 390);
        }
    }
}
