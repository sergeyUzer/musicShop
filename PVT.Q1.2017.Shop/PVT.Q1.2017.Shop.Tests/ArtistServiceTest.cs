namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using global::Moq;

    [TestClass]
    public class ArtistServiceTest
    {
        private readonly IArtistService _artistService;
        private readonly IRepositoryFactory _factory;

        public ArtistServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _artistService = new ArtistService(_factory);
        }

        [TestMethod]
        public void AddArtistTest()
        {
            using (var repository = _factory.GetArtistRepository())
            {
                repository.AddOrUpdate(new Artist { Name = "Some artist" });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetArtistDetailsTest()
        {
            AddArtistTest();
            Assert.IsNotNull(_artistService.GetArtistDetails(1));

            Mock.Get(_factory.GetArtistRepository())
                .Verify(m => m.GetById(It.IsAny<int>()), Times.Once);

            Mock.Get(_factory.GetTrackRepository())
                .Verify(m => m.Count(It.IsAny<Expression<Func<Track, bool>>>()), Times.Once);

            Mock.Get(_factory.GetAlbumRepository())
                .Verify(m => m.Count(It.IsAny<Expression<Func<Album, bool>>>()), Times.Once);
        }

        [TestMethod]
        public void GetTracksListTest()
        {
            AddArtistTest();

            using (var repository = _factory.GetTrackRepository())
            {
                repository.AddOrUpdate(new Track { Name = "Some track" });
                repository.SaveChanges();
            }

            Assert.IsNotNull(_artistService.GetTracks(1));

            Mock.Get(_factory.GetArtistRepository())
                .Verify(m => m.GetById(It.IsAny<int>()), Times.Once);

            Mock.Get(_factory.GetTrackRepository())
                .Verify(m => m.GetAll(It.IsAny<Expression<Func<Track, bool>>>(),
                                      It.IsAny<Expression<Func<Track, BaseEntity>>[]>()), Times.Once);
        }

        [TestMethod]
        public void GetAlbumsListTest()
        {
            AddArtistTest();

            using (var repository = _factory.GetAlbumRepository())
            {
                repository.AddOrUpdate(new Album { Name = "Some album" });
                repository.SaveChanges();
            }

            Assert.IsNotNull(_artistService.GetAlbums(1));

            Mock.Get(_factory.GetArtistRepository())
                .Verify(m => m.GetById(It.IsAny<int>()), Times.Once);

            Mock.Get(_factory.GetAlbumRepository())
                .Verify(m => m.GetAll(It.IsAny<Expression<Func<Album, bool>>>(),
                                      It.IsAny<Expression<Func<Album, BaseEntity>>[]>()), Times.Once);
        }

        [TestMethod]
        public void GetArtistsListTest()
        {
            using (var repository = _factory.GetArtistRepository())
            {
                repository.AddOrUpdate(new Artist { Name = "Some artist" });
                repository.SaveChanges();
            }

            Assert.IsTrue(_artistService.GetArtists().Any());

            Mock.Get(_factory.GetArtistRepository())
                .Verify(m => m.GetAll(), Times.Once);

            Mock.Get(_factory.GetTrackRepository())
                .Verify(m => m.Count(It.IsAny<Expression<Func<Track, bool>>>()), Times.Once);

            Mock.Get(_factory.GetAlbumRepository())
                .Verify(m => m.Count(It.IsAny<Expression<Func<Album, bool>>>()), Times.Once);
        }
    }
}