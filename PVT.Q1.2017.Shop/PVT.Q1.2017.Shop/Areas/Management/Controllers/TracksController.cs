namespace PVT.Q1._2017.Shop.Areas.Management.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;
    using PVT.Q1._2017.Shop.App_Start;
    using PVT.Q1._2017.Shop.Areas.Management.Helpers;
    using PVT.Q1._2017.Shop.Areas.Management.ViewModels;
    using PVT.Q1._2017.Shop.Controllers;

    /// <summary>
    ///     The track controller
    /// </summary>
    [ShopAuthorize(UserRoles.Admin, UserRoles.Seller)]
    public class TracksController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TracksController"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="serviceFactory">
        /// The service factory.
        /// </param>
        public TracksController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory)
            : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Deletes the track with the specified <paramref name="id"/> from the system.
        /// </summary>
        /// <param name="id">
        /// The track id.
        /// </param>
        /// <returns>
        /// The view which generates page for deleting tracks in case if <paramref name="id"/> was specified;
        /// otherwise redirects to the list of tracks.
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return RedirectToAction("List", "Tracks", new { area = "Content" });
            }

            var trackService = ServiceFactory.GetTrackService();
            var track = ManagementMapper.GetTrackManagementViewModel(trackService.GetTrackDetails(id.Value, CurrentUserCurrency.Code, CurrentUser.PriceLevelId));
            if (track == null)
            {
                return HttpNotFound($"Трек с id = {id} не найден");
            }

            return View(track);
        }

        /// <summary>
        /// Deletes the specified track from the system.
        /// </summary>
        /// <param name="track">
        /// The track to delete.
        /// </param>
        /// <returns>
        /// Redirects to the view which generates page with tracks list.
        /// </returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Name")] TrackManagementViewModel track)
        {
            if (track != null)
            {
                using (var repository = RepositoryFactory.GetTrackRepository())
                {
                    repository.Delete(ManagementMapper.GetTrackModel(track));
                    repository.SaveChanges();
                }
            }

            return RedirectToAction("List", "Tracks", new { area = "Content" });
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("List", "Tracks", new { area = "Content" });
            }

            var trackService = ServiceFactory.GetTrackService();
            var trackManagementViewModel = ManagementMapper.GetTrackManagementViewModel(trackService.GetTrackDetails(id, CurrentUserCurrency.Code, CurrentUser.PriceLevelId));
            if (trackManagementViewModel == null)
            {
                return HttpNotFound($"Трек с id = {id} не найден");
            }

            trackManagementViewModel.Genres = GetGenres();

            return this.View(trackManagementViewModel);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(
            [Bind(Include = "Id,PostedTrackFile,PostedImage,PostedTrackSample,ArtistId,ArtistName,Duration,Genres,GenreId,Name,ReleaseDate,FileName,Price,Image,TrackFile,TrackSample")]
            TrackManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Track currentTrack;
                using (var repo = this.RepositoryFactory.GetTrackRepository())
                {
                    currentTrack = repo.GetById(viewModel.Id);
                }

                if (currentTrack == null)
                {
                    return this.HttpNotFound($"Трек с id = {viewModel.Id} не найден");
                }

                if (viewModel.PostedTrackFile == null)
                {
                    viewModel.TrackFile = currentTrack.TrackFile;
                }

                if (viewModel.PostedImage == null)
                {
                    viewModel.Image = currentTrack.Image;
                }

                var track = ManagementMapper.GetTrackModel(viewModel);
                track.OwnerId = currentTrack.OwnerId;
                using (var repository = this.RepositoryFactory.GetTrackRepository())
                {
                    repository.AddOrUpdate(track);
                    repository.SaveChanges();
                }

                if (viewModel.Price != null)
                {
                    using (var priceRepository = RepositoryFactory.GetTrackPriceRepository())
                    {
                        var trackPrice = priceRepository.FirstOrDefault(p => p.TrackId == track.Id &&
                                                                             p.CurrencyId == CurrentUserCurrency.Id &&
                                                                             p.PriceLevelId == CurrentUser.PriceLevelId);
                        if (trackPrice == null)
                        {
                            trackPrice = new TrackPrice
                            {
                                TrackId = track.Id,
                                CurrencyId = CurrentUserCurrency.Id,
                                PriceLevelId = CurrentUser.PriceLevelId
                            };
                        }

                        trackPrice.Price = viewModel.Price.Value;
                        priceRepository.AddOrUpdate(trackPrice);
                        priceRepository.SaveChanges();
                    }
                }

                return this.RedirectToAction("Details", "Tracks", new { id = track.Id, area = "Content" });
            }

            if (viewModel.Genres == null)
            {
                viewModel.Genres = GetGenres();
            }

            return View(viewModel);
        }

        /// <summary>
        /// </summary>
        /// <param name="artistId">
        ///     The id.
        /// </param>
        /// <returns>
        /// </returns>
        public virtual ActionResult New(int artistId = 0)
        {
            if (artistId <= 0)
            {
                return RedirectToAction("List", "Tracks", new { area = "Content" });
            }

            Artist artist;
            using (var repository = this.RepositoryFactory.GetArtistRepository())
            {
                artist = repository.GetById(artistId);
            }

            if (artist == null)
            {
                return HttpNotFound($"Артист с id = {artistId} не найден");
            }

            ICollection<Genre> genres = GetGenres();
            return this.View(new TrackManagementViewModel { ArtistId = artist.Id, ArtistName = artist.Name, Genres = genres });
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult New(
            [Bind(Include = "PostedTrackFile,PostedImage,PostedTrackSample,ArtistId,ArtistName,Duration,Genres,GenreId,Name,ReleaseDate,FileName,Price")]
            TrackManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var track = ManagementMapper.GetTrackModel(viewModel);

                if (this.CurrentUser != null && this.CurrentUser.IsInRole(UserRoles.Seller))
                {
                    track.OwnerId = this.CurrentUser.UserProfileId;
                }

                using (var repository = this.RepositoryFactory.GetTrackRepository())
                {
                    repository.AddOrUpdate(track);
                    repository.SaveChanges();
                }

                if (viewModel.Price != null && CurrentUser != null)
                {
                    using (var priceRepository = RepositoryFactory.GetTrackPriceRepository())
                    {
                        priceRepository.AddOrUpdate(new TrackPrice
                        {
                            TrackId = track.Id,
                            CurrencyId = CurrentUserCurrency.Id,
                            PriceLevelId = CurrentUser.PriceLevelId,
                            Price = viewModel.Price.Value
                        });
                        priceRepository.SaveChanges();
                    }
                }

                return this.RedirectToAction("Details", "Tracks", new { id = track.Id, area = "Content" });
            }

            return View(viewModel);
        }

        private ICollection<Genre> GetGenres()
        {
            ICollection<Genre> genres = CacheHelper.GetCachedGenres();
            if (genres == null)
            {
                using (var repo = this.RepositoryFactory.GetGenreRepository())
                {
                    genres = repo.GetAll();
                    CacheHelper.CacheGenres(genres);
                }
            }

            return genres;
        }
    }
}