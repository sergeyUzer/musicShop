namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Moq;

    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Summary description for TrackServiceTest
    /// </summary>
    [TestClass]
    public class TrackServiceTest
    {
        private readonly ITrackService _trackService;
        private readonly IRepositoryFactory _factory;

        public TrackServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _trackService = new TrackService(_factory);

            using (var repository = _factory.GetCurrencyRepository())
            {
                repository.AddOrUpdate(new Currency { Id = 1, ShortName = "USD", Code = 840 });
                repository.SaveChanges();
            }

            using (var repository = _factory.GetPriceLevelRepository())
            {
                repository.AddOrUpdate(new PriceLevel { Id = 1, Name = "Default Price Level" });
                repository.SaveChanges();
            }
        }

        [TestMethod]
        public void AddTrackTest()
        {
            using (var repository = _factory.GetTrackRepository())
            {
                repository.AddOrUpdate(new Track { Name = "Some track" });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetTracksListTest()
        {
            AddTrackTest();
            var result = _trackService.GetTracks(1, 10);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
        }

        [TestMethod]
        public void GetTrackDetailsTest()
        {
            AddTrackTest();
            Assert.IsNotNull(_trackService.GetTrackDetails(1));
        }

        [TestMethod]
        public void GetAlbumsListTest()
        {
            AddTrackTest();

            var track = _trackService.GetTracks(1, 10).Items.FirstOrDefault();
            Assert.IsNotNull(track);

            using (var repository = _factory.GetAlbumRepository())
            {
                repository.AddOrUpdate(new Album
                {
                    ArtistId = 1,
                    Name = "Some album"
                });
                repository.SaveChanges();
            }

            using (var repository = _factory.GetAlbumTrackRelationRepository())
            {
                repository.AddOrUpdate(new AlbumTrackRelation
                {
                    TrackId = 1,
                    AlbumId = 2
                });
            }

            Assert.IsTrue(_trackService.GetAlbums(track.Id, 840, 1).Albums.Any());

            Mock.Get(_factory.GetAlbumRepository())
                .Verify(m => m.GetAll(It.IsAny<Expression<Func<Album, bool>>>(),
                                      It.IsAny<Expression<Func<Album, BaseEntity>>[]>()), Times.Once);
        }
    }
}
