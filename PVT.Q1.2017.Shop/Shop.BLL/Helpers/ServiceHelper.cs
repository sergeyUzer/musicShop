namespace Shop.BLL.Helpers
{
    using System.Collections.Generic;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;

    /// <summary>
    /// The service helper
    /// </summary>
    internal static class ServiceHelper
    {
        /// <summary>
        /// Returns the default currency.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <returns>
        /// The default currency.
        /// </returns>
        internal static CurrencyViewModel GetDefaultCurrency(IRepositoryFactory repositoryFactory)
        {
            Currency currencyDto;
            using (var repository = repositoryFactory.GetSettingRepository())
            {
                currencyDto = repository.FirstOrDefault(s => !s.IsDeleted)?.DefaultCurrency;
            }

            return ModelsMapper.GetCurrencyViewModel(currencyDto);
        }

        /// <summary>
        /// Returns the default price level.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <returns>
        /// The default price level.
        /// </returns>
        internal static int GetDefaultPriceLevel(IRepositoryFactory repositoryFactory)
        {
            PriceLevel priceLevelDto;
            using (var repository = repositoryFactory.GetPriceLevelRepository())
            {
                priceLevelDto = repository.GetDefaultPriceLevel();
            }

            return priceLevelDto.Id;
        }

        /// <summary>
        /// Converts each album to <see cref="AlbumViewModel"/>.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="albums">
        /// The albums.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevel">
        /// The price level.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// A new collection with <see cref="AlbumViewModel"/> items.
        /// </returns>
        internal static ICollection<AlbumViewModel> ConvertToAlbumViewModels(
            IRepositoryFactory factory,
            ICollection<Album> albums,
            int? currencyCode,
            int? priceLevel,
            int? userId)
        {
            if (currencyCode == null)
            {
                currencyCode = GetDefaultCurrency(factory).Code;
            }

            if (priceLevel == null)
            {
                priceLevel = GetDefaultPriceLevel(factory);
            }

            List<AlbumViewModel> albumViewModels = new List<AlbumViewModel>();
            using (var repository = factory.GetAlbumTrackRelationRepository())
            {
                using (var albumPriceRepository = factory.GetAlbumPriceRepository())
                {
                    using (var currencyRatesrepository = factory.GetCurrencyRateRepository())
                    {
                        foreach (var album in albums)
                        {
                            var albumViewModel = ModelsMapper.GetAlbumViewModel(album);
                            if (albumViewModel != null)
                            {
                                albumViewModel.TracksCount = repository.Count(r => r.AlbumId == albumViewModel.Id);
                                if (albumViewModel.TracksCount > 0)
                                {
                                    albumViewModel.Price =
                                        PriceHelper.GetAlbumPrice(albumPriceRepository, currencyRatesrepository, albumViewModel.Id, currencyCode.Value, priceLevel.Value);
                                }

                                albumViewModels.Add(albumViewModel);
                            }
                        }
                    }
                }
            }

            if (userId != null)
            {
                using (var repository = factory.GetOrderAlbumRepository())
                {
                    foreach (var albumViewModel in albumViewModels)
                    {
                        albumViewModel.IsOrdered =
                            repository.Exist(o => o.UserId == userId && o.AlbumId == albumViewModel.Id);
                    }
                }

                using (var repository = factory.GetPurchasedAlbumRepository())
                {
                    foreach (var albumViewModel in albumViewModels)
                    {
                        albumViewModel.IsPurchased =
                            repository.Exist(p => p.UserId == userId && p.AlbumId == albumViewModel.Id);
                    }
                }
            }

            return albumViewModels;
        }

        /// <summary>
        /// Converts each track to <see cref="TrackViewModel"/>.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="tracks">
        /// The tracks.
        /// </param>
        /// <param name="currencyCode">
        /// The currency code.
        /// </param>
        /// <param name="priceLevel">
        /// The price level.
        /// </param>
        /// <param name="userId">
        /// The current user id.
        /// </param>
        /// <returns>
        /// A new collection with <see cref="TrackViewModel"/> items.
        /// </returns>
        internal static ICollection<TrackViewModel> ConvertToTrackViewModels(
            IRepositoryFactory factory,
            ICollection<Track> tracks,
            int? currencyCode,
            int? priceLevel,
            int? userId)
        {
            if (currencyCode == null)
            {
                currencyCode = GetDefaultCurrency(factory).Code;
            }

            if (priceLevel == null)
            {
                priceLevel = GetDefaultPriceLevel(factory);
            }

            List<TrackViewModel> trackViewModels = new List<TrackViewModel>();

            using (var repository = factory.GetTrackPriceRepository())
            {
                using (var currencyRatesrepository = factory.GetCurrencyRateRepository())
                {
                    foreach (var track in tracks)
                    {
                        var trackViewModel = ModelsMapper.GetTrackViewModel(track);
                        if (trackViewModel != null)
                        {
                            trackViewModel.Price =
                                PriceHelper.GetTrackPrice(
                                    repository, currencyRatesrepository, trackViewModel.Id, currencyCode.Value, priceLevel.Value);
                            trackViewModels.Add(trackViewModel);
                        }
                    }
                }
            }

            using (var repository = factory.GetAlbumTrackRelationRepository())
            {
                trackViewModels.ForEach(t => t.AlbumsCount = repository.Count(r => r.TrackId == t.Id));
            }

            using (var repository = factory.GetVoteRepository())
            {
                trackViewModels.ForEach(t => t.Rating = repository.GetAverageMark(t.Id));
            }

            if (userId != null)
            {
                using (var repository = factory.GetOrderTrackRepository())
                {
                    foreach (var trackViewModel in trackViewModels)
                    {
                        trackViewModel.IsOrdered =
                            repository.Exist(o => o.UserId == userId && o.TrackId == trackViewModel.Id);
                    }
                }

                using (var repository = factory.GetPurchasedTrackRepository())
                {
                    foreach (var trackViewModel in trackViewModels)
                    {
                        trackViewModel.IsPurchased =
                            repository.Exist(p => p.UserId == userId && p.TrackId == trackViewModel.Id);
                    }
                }
            }

            return trackViewModels;
        }

        /// <summary>
        /// Calculates the rating for the specified track.
        /// </summary>
        /// <param name="factory">
        /// The repository factory.
        /// </param>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// The rating for the specified track.
        /// </returns>
        internal static RatingViewModel CalculateTrackRating(IRepositoryFactory factory, int trackId)
        {
            int votesCount;
            int commentsCount;
            double rating;
            using (var repository = factory.GetVoteRepository())
            {
                votesCount = repository.GetVotesCount(trackId);
                rating = repository.GetAverageMark(trackId);
            }

            using (var repository = factory.GetFeedbackRepository())
            {
                commentsCount = repository.GetFeedbacksCount(trackId);
            }

            return new RatingViewModel
            {
                VotesCount = votesCount,
                CommentsCount = commentsCount,
                Rating = rating
            };
        }
    }
}