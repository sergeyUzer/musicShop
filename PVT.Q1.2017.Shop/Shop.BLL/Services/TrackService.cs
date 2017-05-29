namespace Shop.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;
    using Helpers;
    using Infrastructure;
    using Shop.Infrastructure.Enums;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The track service
    /// </summary>
    public class TrackService : BaseService, ITrackService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The  repositories factory.
        /// </param>
        public TrackService(IRepositoryFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Returns the track details using the specified currency and price level for track price.
        /// </summary>
        /// <param name="currencyCode">
        /// The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="id">The track id.</param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// The information about track with the specified <paramref name="id"/> or <b>null</b> if track doesn't exist.
        /// </returns>
        public TrackDetailsViewModel GetTrackDetails(int id, int? currencyCode = null, int? priceLevelId = null, int? userId = null)
        {
            Track track;
            using (var repository = Factory.GetTrackRepository())
            {
                track = repository.GetById(id, t => t.Artist, t => t.Genre);
            }

            if (track == null)
            {
                return null;
            }

            return CreateTrackDetailsViewModel(track, currencyCode, priceLevelId, userId);
        }

        /// <summary>
        /// Returns all registered tracks using the specified currency and price level for track price.
        /// </summary>
        /// <param name="currencyCode">
        ///     The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        ///     The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        ///     The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks.
        /// </returns>
        public async Task<ICollection<TrackViewModel>> GetTracksAsync(int? currencyCode = null, int? priceLevel = null, int? userId = null)
        {
            ICollection<Track> tracks;
            using (var repository = Factory.GetTrackRepository())
            {
                tracks = await repository.GetAllAsync(t => t.Artist, t => t.Genre).ConfigureAwait(false);
            }

            // TODO: implement async version ConvertToTrackViewModelsAsync
            return ServiceHelper.ConvertToTrackViewModels(Factory, tracks, currencyCode, priceLevel, userId);
        }

        /// <summary>
        /// Returns all registered tracks using the specified currency and price level for track price.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <param name="currencyCode">
        ///     The currency code for track price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevel">
        ///     The price level for track price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        ///     The current user id.
        /// </param>
        /// <returns>
        /// All registered tracks.
        /// </returns>
        public PagedResult<TrackViewModel> GetTracks(int page, int pageSize, int? currencyCode = null, int? priceLevel = null, int? userId = null)
        {
            PagedResult<Track> tracks;
            using (var repository = Factory.GetTrackRepository())
            {
                tracks = repository.GetAll(page, pageSize, t => t.Artist, t => t.Genre);
            }

            var trackViewModels = ServiceHelper.ConvertToTrackViewModels(Factory, tracks.Items, currencyCode, priceLevel, userId);
            return new PagedResult<TrackViewModel>(trackViewModels, tracks.PageSize, tracks.CurrentPage, tracks.TotalItemsCount);
        }

        /// <summary>
        /// Returns all albums which contain the specified track using the specified currency and price level.
        /// </summary>
        /// <param name="trackId">The track id.</param>
        /// <param name="currencyCode">
        /// The currency code for album price. If it doesn't specified than default currency is used.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level for album price. If it doesn't specified than default price level is used.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// All albums which contain the specified track.
        /// </returns>
        public TrackAlbumsListViewModel GetAlbums(int trackId, int? currencyCode = null, int? priceLevelId = null, int? userId = null)
        {
            var trackAlbumsListViewModel = CreateTrackAlbumsListViewModel(trackId, currencyCode, priceLevelId, userId);

            if (trackAlbumsListViewModel.TrackDetails.AlbumsCount <= 0)
            {
                return trackAlbumsListViewModel;
            }

            ICollection<Album> albums;
            using (var repository = this.Factory.GetAlbumRepository())
            {
                albums = repository.GetAll(a => a.Tracks.Any(t => t.TrackId == trackId), a => a.Artist);
            }

            trackAlbumsListViewModel.Albums = ServiceHelper.ConvertToAlbumViewModels(this.Factory, albums, currencyCode, priceLevelId, userId);

            return trackAlbumsListViewModel;
        }

        /// <summary>
        /// Return all tracks that the specified user have bought.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// All tracks that the specified user have bought.
        /// </returns>
        public async Task<ICollection<PurchasedTrackViewModel>> GetPurchasedTracksAsync(int userId)
        {
            ICollection<Track> tracks;
            using (var repository = Factory.GetPurchasedTrackRepository())
            {
                var purchasedTracks = await repository.GetAllAsync(
                                                          p => p.UserId == userId,
                                                          p => p.Track,
                                                          p => p.Track.Artist,
                                                          p => p.Track.Genre)
                                                      .ConfigureAwait(false);
                tracks = purchasedTracks.Select(p => p.Track).ToList();
            }

            // TODO: implement CreatePurchasedTracksListAsync method
            var trackViewModels = CreatePurchasedTracksList(tracks);
            return trackViewModels;
        }

        /// <summary>
        /// Return all tracks that the specified user have bought.
        /// </summary>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="pageSize">
        /// The number of the items on the page.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// All tracks that the specified user have bought.
        /// </returns>
        public PagedResult<PurchasedTrackViewModel> GetPurchasedTracks(int page, int pageSize, int userId)
        {
            PagedResult<PurchasedTrack> tracks;
            using (var repository = Factory.GetPurchasedTrackRepository())
            {
                tracks = repository.GetAll(page, pageSize, p => p.UserId == userId, p => p.Track, p => p.Track.Artist, p => p.Track.Genre);
            }

            var trackViewModels = CreatePurchasedTracksList(tracks.Items.Select(t => t.Track).ToList());
            return new PagedResult<PurchasedTrackViewModel>(trackViewModels, pageSize, page, tracks.TotalItemsCount);
        }

        /// <summary>
        /// Return a track with the specified id purchased by the specified user.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// A track with the specified id purchased by the specified user if exists or <b>null</b>.
        /// </returns>
        public PurchasedTrackViewModel GetPurchasedTrack(int trackId, int userId)
        {
            PurchasedTrack track;
            using (var repository = Factory.GetPurchasedTrackRepository())
            {
                track = repository.FirstOrDefault(
                                                  p => p.UserId == userId && p.TrackId == trackId,
                                                  p => p.Track,
                                                  p => p.Track.Artist,
                                                  p => p.Track.Genre);
            }

            if (track == null)
            {
                return null;
            }

            var trackViewModel = ModelsMapper.GetPurchasedTrackViewModel(track.Track);
            using (var repository = Factory.GetVoteRepository())
            {
                trackViewModel.Rating = repository.GetAverageMark(track.Id);
            }

            return trackViewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="userRole">
        /// The user role.
        /// </param>
        /// <param name="userProfileId">
        /// The user profile id.
        /// </param>
        /// <returns>
        /// </returns>
        public TrackAudio GetTrackAudio(int id, UserRoles userRole, int userProfileId)
        {
            if (id <= 0)
            {
                return null;
            }

            TrackAudio trackAudio;
            if (userRole == UserRoles.Admin)
            {
                trackAudio = this.GetTrackAudioForAdmin(id);
            }
            else if (userRole == UserRoles.Seller)
            {
                trackAudio = this.GetTrackAudioForSeller(id, userProfileId);
            }
            else
            {
                trackAudio = this.GetTrackAudioForBuyer(id, userProfileId);
            }

            return trackAudio;
        }

        /// <summary>
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackAudio GetTrackAudioForAdmin(int trackId)
        {
            // мы можем дать скачать и послушать все треки админу
            Track track;
            using (var repository = Factory.GetTrackRepository())
            {
                track = repository.GetById(trackId, t => t.Artist);
            }

            if (track != null)
            {
                return new TrackAudio()
                {
                    AudioStream =
                                   Mp3StreamHelper.GetAudioStream(
                                       track.Name,
                                       track.Artist.Name,
                                       track.TrackFile),
                    FileName = track.FileName
                };
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userProfileId">
        /// The user profile id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackAudio GetTrackAudioForBuyer(int trackId, int userProfileId)
        {
            // мы можем дать скачать и послушать только купленные треки для обычных пользователей
            var purchasedTrack = GetPurchasedTrack(trackId, userProfileId);
            if (purchasedTrack != null && purchasedTrack.TrackFile != null)
            {
                return new TrackAudio()
                {
                    AudioStream =
                                   Mp3StreamHelper.GetAudioStream(
                                       purchasedTrack.Name,
                                       purchasedTrack.Artist.Name,
                                       purchasedTrack.TrackFile),
                    FileName = purchasedTrack.FileName
                };
            }

            return GetTrackSample(trackId);
        }

        /// <summary>
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userProfileId">
        /// The user profile id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackAudio GetTrackAudioForSeller(int trackId, int userProfileId)
        {
            // мы можем дать скачать и послушать свои треки продавцу
            Track track;
            using (var repository = Factory.GetTrackRepository())
            {
                track =
                    repository.FirstOrDefault(
                                              t => t.Id == trackId && (t.OwnerId == userProfileId || t.OwnerId == null),
                                              t => t.Artist);
            }

            if (track != null && track.TrackFile != null)
            {
                return new TrackAudio()
                {
                    AudioStream =
                                   Mp3StreamHelper.GetAudioStream(
                                       track.Name,
                                       track.Artist.Name,
                                       track.TrackFile),
                    FileName = track.FileName
                };
            }

            return GetTrackSample(trackId);
        }

        /// <summary>
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackAudio GetTrackSample(int trackId)
        {
            Track track;
            using (var repository = Factory.GetTrackRepository())
            {
                track = repository.FirstOrDefault(t => t.Id == trackId, t => t.Artist);
            }

            if (track != null && track.TrackFile != null)
            {
                return new TrackAudio()
                {
                    AudioStream = Mp3StreamHelper.GetAudioStream(
                                   track.Name,
                                   track.Artist.Name,
                                   track.TrackFile,
                                   true),
                    FileName = track.FileName
                };
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevel">
        /// The price level.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackAlbumsListViewModel CreateTrackAlbumsListViewModel(int trackId, int? currencyCode, int? priceLevel = null, int? userId = null)
        {
            return new TrackAlbumsListViewModel
            {
                TrackDetails = GetTrackDetails(trackId, currencyCode, priceLevel, userId)
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="tracks">
        /// The tracks.
        /// </param>
        /// <returns>
        /// </returns>
        private ICollection<PurchasedTrackViewModel> CreatePurchasedTracksList(ICollection<Track> tracks)
        {
            var trackViewModels = new List<PurchasedTrackViewModel>();
            using (var repository = Factory.GetVoteRepository())
            {
                foreach (var track in tracks)
                {
                    var trackViewModel = ModelsMapper.GetPurchasedTrackViewModel(track);
                    if (trackViewModel == null)
                    {
                        continue;
                    }

                    trackViewModel.Rating = repository.GetAverageMark(track.Id);
                    trackViewModels.Add(trackViewModel);
                }
            }

            return trackViewModels;
        }

        /// <summary>
        /// </summary>
        /// <param name="track">
        /// The track.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevelId">
        /// The price level id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// </returns>
        private TrackDetailsViewModel CreateTrackDetailsViewModel(Track track, int? currencyCode = null, int? priceLevelId = null, int? userId = null)
        {
            if (track == null)
            {
                return null;
            }

            var trackViewModel = ModelsMapper.GetTrackDetailsViewModel(track);

            if (currencyCode == null)
            {
                currencyCode = ServiceHelper.GetDefaultCurrency(Factory).Code;
            }

            if (priceLevelId == null)
            {
                priceLevelId = ServiceHelper.GetDefaultPriceLevel(Factory);
            }

            using (var repository = Factory.GetTrackPriceRepository())
            {
                using (var currencyRatesrepository = Factory.GetCurrencyRateRepository())
                {
                    trackViewModel.Price =
                            PriceHelper.GetTrackPrice(repository, currencyRatesrepository, track.Id, currencyCode.Value, priceLevelId.Value);
                }
            }

            trackViewModel.Rating = ServiceHelper.CalculateTrackRating(Factory, track.Id);

            using (var repository = Factory.GetAlbumTrackRelationRepository())
            {
                trackViewModel.AlbumsCount = repository.Count(r => r.TrackId == track.Id);
            }

            if (userId != null)
            {
                using (var repository = Factory.GetOrderTrackRepository())
                {
                    trackViewModel.IsOrdered =
                            repository.Exist(o => o.UserId == userId && o.TrackId == trackViewModel.Id);
                }

                using (var repository = Factory.GetPurchasedTrackRepository())
                {
                    trackViewModel.IsPurchased =
                            repository.Exist(p => p.UserId == userId && p.TrackId == trackViewModel.Id);
                }
            }

            return trackViewModel;
        }
    }
}
