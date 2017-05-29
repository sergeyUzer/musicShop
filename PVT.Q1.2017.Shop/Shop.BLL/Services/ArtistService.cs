namespace Shop.BLL.Services
{
    using System.Collections.Generic;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;
    using Helpers;
    using Infrastructure;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The artist service.
    /// </summary>
    public class ArtistService : BaseService, IArtistService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        public ArtistService(IRepositoryFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Returns the artist details.
        /// </summary>
        /// <param name="id">The artist id.</param>
        /// <returns>
        /// The information about artist with the specified <paramref name="id"/> or <b>null</b> if artist doesn't exist.
        /// </returns>
        public ArtistDetailsViewModel GetArtistDetails(int id)
        {
            Artist artist;
            using (var repository = Factory.GetArtistRepository())
            {
                artist = repository.GetById(id);
            }

            var artistDetails = ModelsMapper.GetArtistDetailsViewModel(artist);

            using (var repository = Factory.GetTrackRepository())
            {
                artistDetails.TracksCount = repository.Count(t => t.ArtistId == artist.Id);
            }

            using (var repository = Factory.GetAlbumRepository())
            {
                artistDetails.AlbumsCount = repository.Count(a => a.ArtistId != null && a.ArtistId == artist.Id);
            }

            return artistDetails;
        }

        /// <summary>
        /// Returns all registered tracks for the specified artist using the specified currency and price level for track price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks with price for the specified artist.
        /// </returns>
        public ArtistTracksListViewModel GetTracks(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null)
        {
            ArtistTracksListViewModel artistTracksListViewModel = CreateArtistTracksListViewModel(artistId);

            if (artistTracksListViewModel.ArtistDetails.TracksCount > 0)
            {
                artistTracksListViewModel.Tracks = GetArtistTracks(artistId, currencyCode, priceLevel, userId);
            }

            return artistTracksListViewModel;
        }

        /// <summary>
        /// Returns all registered albums for the specified artist using the specified currency and price level for album price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered albums with price for the specified artist.
        /// </returns>
        public ArtistAlbumsListViewModel GetAlbums(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null)
        {
            ArtistAlbumsListViewModel artistAlbumsListViewModel = CreateArtistAlbumsListViewModel(artistId);

            if (artistAlbumsListViewModel.ArtistDetails.AlbumsCount > 0)
            {
                artistAlbumsListViewModel.Albums = GetArtistAlbums(artistId, currencyCode, priceLevel, userId);
            }

            return artistAlbumsListViewModel;
        }

        /// <summary>
        /// Returns all registered tracks and albums for the specified artist using the specified currency and price level for the price.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks and albums with price for the specified artist.
        /// </returns>
        public ArtistContentViewModel GetContent(int artistId, int? currencyCode = null, int? priceLevel = null, int? userId = null)
        {
            ArtistContentViewModel artistContentViewModel = new ArtistContentViewModel
            {
                ArtistDetails = GetArtistDetails(artistId)
            };

            if (artistContentViewModel.ArtistDetails.AlbumsCount > 0)
            {
                artistContentViewModel.Albums = GetArtistAlbums(artistId, currencyCode, priceLevel, userId);
            }

            if (artistContentViewModel.ArtistDetails.TracksCount > 0)
            {
                artistContentViewModel.Tracks = GetArtistTracks(artistId, currencyCode, priceLevel, userId);
            }

            return artistContentViewModel;
        }

        /// <summary>
        /// Returns all registered artists.
        /// </summary>
        /// <returns>
        /// All registered artists.
        /// </returns>
        public ICollection<ArtistViewModel> GetArtists()
        {
            ICollection<Artist> artists;
            using (var repository = Factory.GetArtistRepository())
            {
                artists = repository.GetAll();
            }

            return CreateArtistViewModelsList(artists);
        }

        /// <summary>
        /// Returns all registered artists with detailed information.
        /// </summary>
        /// <returns>
        /// All registered artists with detailed information.
        /// </returns>
        public ICollection<ArtistDetailsViewModel> GetDetailedArtistsList()
        {
            ICollection<Artist> artists;
            using (var repository = Factory.GetArtistRepository())
            {
                artists = repository.GetAll();
            }

            List<ArtistDetailsViewModel> detailedList = new List<ArtistDetailsViewModel>();
            foreach (var artist in artists)
            {
                detailedList.Add(GetArtistDetails(artist.Id));
            }

            return detailedList;
        }

        /// <summary>
        /// Returns all registered artists.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <returns>
        /// All registered artists.
        /// </returns>
        public PagedResult<ArtistViewModel> GetArtists(int page, int pageSize)
        {
            PagedResult<Artist> artists;
            using (var repository = Factory.GetArtistRepository())
            {
                artists = repository.GetAll(page, pageSize);
            }

            var artistViewModels = CreateArtistViewModelsList(artists.Items);
            return new PagedResult<ArtistViewModel>(artistViewModels, pageSize, page, artists.TotalItemsCount);
        }

        /// <summary>
        /// Returns all registered artists with detailed information.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <returns>
        /// All registered artists with detailed information.
        /// </returns>
        public PagedResult<ArtistDetailsViewModel> GetDetailedArtistsList(int page, int pageSize)
        {
            PagedResult<Artist> artists;
            using (var repository = Factory.GetArtistRepository())
            {
                artists = repository.GetAll(page, pageSize);
            }

            List<ArtistDetailsViewModel> detailedList = new List<ArtistDetailsViewModel>();
            foreach (var artist in artists.Items)
            {
                detailedList.Add(GetArtistDetails(artist.Id));
            }

            return new PagedResult<ArtistDetailsViewModel>(detailedList, pageSize, page, artists.TotalItemsCount);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ArtistTracksListViewModel"/> type.
        /// </summary>
        /// <param name="artistId">
        /// The artist id.
        /// </param>
        /// <returns>
        /// A new instance of the <see cref="ArtistTracksListViewModel"/> type.
        /// </returns>
        private ArtistTracksListViewModel CreateArtistTracksListViewModel(int artistId)
        {
            return new ArtistTracksListViewModel
            {
                ArtistDetails = GetArtistDetails(artistId)
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ArtistAlbumsListViewModel"/> type.
        /// </summary>
        /// <param name="artistId">
        /// The artist id.
        /// </param>
        /// <returns>
        /// A new instance of the <see cref="ArtistAlbumsListViewModel"/> type.
        /// </returns>
        private ArtistAlbumsListViewModel CreateArtistAlbumsListViewModel(int artistId)
        {
            return new ArtistAlbumsListViewModel
            {
                ArtistDetails = GetArtistDetails(artistId)
            };
        }

        private ICollection<AlbumViewModel> GetArtistAlbums(int artistId, int? currencyCode, int? priceLevel, int? userId)
        {
            ICollection<Album> albums;
            using (var repository = Factory.GetAlbumRepository())
            {
                albums = repository.GetAll(a => a.ArtistId != null && a.ArtistId.Value == artistId, a => a.Artist);
            }

            return ServiceHelper.ConvertToAlbumViewModels(Factory, albums, currencyCode, priceLevel, userId);
        }

        private ICollection<TrackViewModel> GetArtistTracks(int artistId, int? currencyCode, int? priceLevel, int? userId)
        {
            ICollection<Track> tracks;
            using (var repository = Factory.GetTrackRepository())
            {
                tracks = repository.GetAll(t => t.ArtistId == artistId, t => t.Artist);
            }

            return ServiceHelper.ConvertToTrackViewModels(Factory, tracks, currencyCode, priceLevel, userId);
        }

        private ICollection<ArtistViewModel> CreateArtistViewModelsList(ICollection<Artist> artists)
        {
            List<ArtistViewModel> artistViewModels = new List<ArtistViewModel>();
            using (var repository = Factory.GetTrackRepository())
            {
                foreach (var artist in artists)
                {
                    var artistViewModel = ModelsMapper.GetArtistViewModel(artist);
                    if (artistViewModel != null)
                    {
                        artistViewModel.TracksCount = repository.Count(t => t.ArtistId == artist.Id);
                        artistViewModels.Add(artistViewModel);
                    }
                }
            }

            using (var repository = Factory.GetAlbumRepository())
            {
                foreach (var artistViewModel in artistViewModels)
                {
                    artistViewModel.AlbumsCount = repository.Count(a => a.ArtistId != null && a.ArtistId == artistViewModel.Id);
                }
            }

            return artistViewModels;
        }
    }
}