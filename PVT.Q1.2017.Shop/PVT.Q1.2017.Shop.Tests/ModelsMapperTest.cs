namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using System.Collections.Generic;
    using global::Shop.BLL;
    using global::Shop.BLL.Helpers;
    using global::Shop.Common.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ModelsMapperTest
    {
        [TestMethod]
        public void GetPriceViewModelForTrackPriceTest()
        {
            var currencyDto = CreateCurrency();
            var priceLevelDto = CreatePriceLevel();

            var trackDto = new Track
            {
                Id = 1,
                Name = "Some track"
            };

            var trackPriceDto = new TrackPrice
            {
                Id = 1,
                TrackId = trackDto.Id,
                Track = trackDto,
                CurrencyId = currencyDto.Id,
                Currency = currencyDto,
                Price = 4.99m,
                PriceLevelId = priceLevelDto.Id,
                PriceLevel = priceLevelDto
            };

            var priceViewModel = ModelsMapper.GetPriceViewModel(trackPriceDto);

            Assert.IsNotNull(priceViewModel);

            Assert.IsTrue(priceViewModel.Amount == trackPriceDto.Price);

            Assert.IsNotNull(priceViewModel.Currency);
            Assert.IsTrue(priceViewModel.Currency.Code == trackPriceDto.Currency.Code);
            Assert.IsTrue(priceViewModel.Currency.ShortName.Equals(trackPriceDto.Currency.ShortName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(priceViewModel.Currency.FullName.Equals(trackPriceDto.Currency.FullName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(priceViewModel.Currency.Symbol.Equals(trackPriceDto.Currency.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetPriceViewModelForAlbumPriceTest()
        {
            var currencyDto = CreateCurrency();
            var priceLevelDto = CreatePriceLevel();

            var albumDto = new Album
            {
                Id = 1,
                Name = "Some album"
            };

            var albumPriceDto = new AlbumPrice
            {
                Id = 1,
                AlbumId = albumDto.Id,
                Album = albumDto,
                CurrencyId = currencyDto.Id,
                Currency = currencyDto,
                Price = 4.99m,
                PriceLevelId = priceLevelDto.Id,
                PriceLevel = priceLevelDto
            };

            var priceViewModel = ModelsMapper.GetPriceViewModel(albumPriceDto);

            Assert.IsNotNull(priceViewModel);

            Assert.IsTrue(priceViewModel.Amount == albumPriceDto.Price);

            Assert.IsNotNull(priceViewModel.Currency);
            Assert.IsTrue(priceViewModel.Currency.Code == albumPriceDto.Currency.Code);
            Assert.IsTrue(priceViewModel.Currency.ShortName.Equals(albumPriceDto.Currency.ShortName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(priceViewModel.Currency.FullName.Equals(albumPriceDto.Currency.FullName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(priceViewModel.Currency.Symbol.Equals(albumPriceDto.Currency.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetArtistViewModelTest()
        {
            var artistDto = CreateArtist();
            var artistViewModel = ModelsMapper.GetArtistViewModel(artistDto);

            Assert.IsNotNull(artistViewModel);

            Assert.IsTrue(artistViewModel.Id == artistDto.Id);
            Assert.IsTrue(artistViewModel.Name.Equals(artistDto.Name, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetArtistDetailsViewModelTest()
        {
            var artistDto = CreateArtist();
            var artistViewModel = ModelsMapper.GetArtistDetailsViewModel(artistDto);

            Assert.IsNotNull(artistViewModel);

            Assert.IsTrue(artistViewModel.Id == artistDto.Id);
            Assert.IsTrue(artistViewModel.Name.Equals(artistDto.Name, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(artistViewModel.Biography.Equals(artistDto.Biography, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(artistViewModel.Birthday == artistDto.Birthday);
        }

        [TestMethod]
        public void GetArtistTracksListViewModelTest()
        {
            var artistDto = CreateArtist();
            var artistViewModel = ModelsMapper.GetArtistTracksListViewModel(artistDto);

            Assert.IsNotNull(artistViewModel);

            Assert.IsNotNull(artistViewModel.ArtistDetails);
            Assert.IsTrue(artistViewModel.ArtistDetails.Id == artistDto.Id);
            Assert.IsTrue(artistViewModel.ArtistDetails.Name.Equals(artistDto.Name, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetArtistAlbumsListViewModelTest()
        {
            var artistDto = CreateArtist();
            var artistViewModel = ModelsMapper.GetArtistAlbumsListViewModel(artistDto);

            Assert.IsNotNull(artistViewModel);

            Assert.IsNotNull(artistViewModel.ArtistDetails);
            Assert.IsTrue(artistViewModel.ArtistDetails.Id == artistDto.Id);
            Assert.IsTrue(artistViewModel.ArtistDetails.Name.Equals(artistDto.Name, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetCurrencyViewModelTest()
        {
            var currencyDto = CreateCurrency();
            var currency = ModelsMapper.GetCurrencyViewModel(currencyDto);

            Assert.IsNotNull(currency);
            Assert.IsTrue(currency.Code == currencyDto.Code);
            Assert.IsTrue(currency.ShortName.Equals(currencyDto.ShortName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(currency.FullName.Equals(currencyDto.FullName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(currency.Symbol.Equals(currencyDto.Symbol, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetGenreViewModelTest()
        {
            var genreDto = CreateGenre();
            var genre = ModelsMapper.GetGenreViewModel(genreDto);

            Assert.IsNotNull(genre);
            Assert.IsTrue(genre.Id == genreDto.Id);
            Assert.IsTrue(genre.Name.Equals(genreDto.Name, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetAlbumDetailsViewModelTest()
        {
            var artistDto = CreateArtist();

            var albumDto = new Album
            {
                Id = 1,
                Name = "Some album",
                Artist = artistDto,
                ArtistId = artistDto.Id
            };
            var albumViewModel = ModelsMapper.GetAlbumDetailsViewModel(albumDto);

            Assert.IsNotNull(albumViewModel);

            Assert.IsTrue(albumViewModel.Id == albumDto.Id);
            Assert.IsTrue(albumViewModel.Name.Equals(albumDto.Name, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(albumViewModel.Artist);
            Assert.IsTrue(albumViewModel.Artist.Id == albumDto.ArtistId);
        }

        [TestMethod]
        public void GetAlbumViewModelTest()
        {
            var artistDto = CreateArtist();

            var albumDto = new Album
            {
                Id = 1,
                Name = "Some album",
                Artist = artistDto,
                ArtistId = artistDto.Id
            };
            var albumViewModel = ModelsMapper.GetAlbumViewModel(albumDto);

            Assert.IsNotNull(albumViewModel);

            Assert.IsTrue(albumViewModel.Id == albumDto.Id);
            Assert.IsTrue(albumViewModel.Name.Equals(albumDto.Name, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(albumViewModel.Artist);
            Assert.IsTrue(albumViewModel.Artist.Id == albumDto.ArtistId);
        }

        [TestMethod]
        public void GetTrackDetailsViewModel()
        {
            var artistDto = CreateArtist();
            var genreDto = CreateGenre();
            var trackDto = CreateTrack(artistDto, genreDto);

            var track = ModelsMapper.GetTrackDetailsViewModel(trackDto);

            Assert.IsNotNull(track);

            Assert.IsTrue(track.Id == trackDto.Id);
            Assert.IsTrue(track.Name.Equals(trackDto.Name, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(track.Duration == trackDto.Duration);
            Assert.IsTrue(track.ReleaseDate == trackDto.ReleaseDate);

            Assert.IsNotNull(track.Artist);
            Assert.IsTrue(track.Artist.Id == trackDto.ArtistId);

            Assert.IsNotNull(track.Genre);
            Assert.IsTrue(track.Genre.Id == trackDto.GenreId);
        }

        [TestMethod]
        public void GetTrackViewModelTest()
        {
            var artistDto = CreateArtist();
            var genreDto = CreateGenre();
            var trackDto = CreateTrack(artistDto, genreDto);

            var track = ModelsMapper.GetTrackViewModel(trackDto);

            Assert.IsNotNull(track);

            Assert.IsTrue(track.Id == trackDto.Id);
            Assert.IsTrue(track.Name.Equals(trackDto.Name, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(track.Artist);
            Assert.IsTrue(track.Artist.Id == trackDto.ArtistId);
        }

        [TestMethod]
        public void GetTrackAlbumsListViewModelTest()
        {
            var artistDto = CreateArtist();
            var genreDto = CreateGenre();
            var trackDto = CreateTrack(artistDto, genreDto);

            var track = ModelsMapper.GetTrackAlbumsListViewModel(trackDto);

            Assert.IsNotNull(track);

            Assert.IsNotNull(track.TrackDetails);
            Assert.IsTrue(track.TrackDetails.Id == trackDto.Id);
            Assert.IsTrue(track.TrackDetails.Name.Equals(trackDto.Name, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(track.TrackDetails.Artist);
            Assert.IsTrue(track.TrackDetails.Artist.Id == trackDto.ArtistId);
        }

        [TestMethod]
        public void GetAlbumTracksListViewModellTest()
        {
            var artistDto = CreateArtist();

            var albumDto = new Album
            {
                Id = 1,
                Name = "Some album",
                Artist = artistDto,
                ArtistId = artistDto.Id
            };
            var albumViewModel = ModelsMapper.GetAlbumTracksListViewModel(albumDto);

            Assert.IsNotNull(albumViewModel);

            Assert.IsTrue(albumViewModel.AlbumDetails.Id == albumDto.Id);
            Assert.IsTrue(albumViewModel.AlbumDetails.Name.Equals(albumDto.Name, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(albumViewModel.AlbumDetails.Artist);
            Assert.IsTrue(albumViewModel.AlbumDetails.Artist.Id == albumDto.ArtistId);
        }

        [TestMethod]
        public void GetFeedbackViewModelTest()
        {
            var artistDto = CreateArtist();
            var genreDto = CreateGenre();
            var trackDto = CreateTrack(artistDto, genreDto);

            var userData = new UserData
            {
                Id = 1
            };

            var feedbackDto = new Feedback
            {
                Id = 1,
                Comments = "Some comments",
                Track = trackDto,
                TrackId = trackDto.Id,
                User = userData,
                UserId = userData.Id
            };
            var feedback = ModelsMapper.GetFeedbackViewModel(feedbackDto);

            Assert.IsNotNull(feedback);
            Assert.IsTrue(feedback.UserDataId == userData.Id);
            Assert.IsTrue(feedback.Comments.Equals(feedbackDto.Comments, StringComparison.OrdinalIgnoreCase));
        }

        /*
          public static FeedbackViewModel GetFeedbackViewModel(Feedback feedback)
    */


        private Artist CreateArtist()
        {
            return new Artist
            {
                Id = 1,
                Name = "Some artist",
                Biography = "Biography of the artist",
                Birthday = new DateTime(1978, 4, 7)
            };
        }

        private Track CreateTrack(Artist artist, Genre genre)
        {
            return new Track
            {
                Id = 1,
                Name = "Some track",
                Artist = artist,
                ArtistId = artist.Id,
                Genre = genre,
                GenreId = genre.Id,
                Duration = new TimeSpan(0, 3, 57),
                ReleaseDate = new DateTime(2014, 9, 5)
            };
        }

        private Currency CreateCurrency()
        {
            return new Currency
            {
                Id = 1,
                Code = 840,
                ShortName = "USD",
                FullName = "US dollar",
                Symbol = "$"
            };
        }

        private PriceLevel CreatePriceLevel()
        {
            return new PriceLevel
            {
                Id = 1,
                Name = "Some price level"
            };
        }

        private Genre CreateGenre()
        {
            return new Genre
            {
                Id = 1,
                Name = "Some genre"
            };
        }
    }
}