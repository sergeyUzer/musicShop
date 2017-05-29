namespace PVT.Q1._2017.Shop.Areas.Management.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;

    using PVT.Q1._2017.Shop.App_Start;
    using PVT.Q1._2017.Shop.Areas.Management.Helpers;
    using PVT.Q1._2017.Shop.Areas.Management.ViewModels;
    using PVT.Q1._2017.Shop.Controllers;

    /// <summary>
    /// </summary>
    [ShopAuthorize( UserRoles.Admin, UserRoles.Seller)]
    public class AlbumsController : BaseController
    {
        public AlbumsController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Deletes the album with the specified <paramref name="id"/> from the system.
        /// </summary>
        /// <param name="id">
        /// The album id.
        /// </param>
        /// <returns>
        /// The view which generates page for deleting albums in case if <paramref name="id"/> was specified;
        /// otherwise redirects to the list of albums.
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return RedirectToAction("List", "Albums", new { area = "Content" });
            }

            var albumService = ServiceFactory.GetAlbumService();
            var album = ManagementMapper.GetAlbumManagementViewModel(albumService.GetAlbumDetails(id.Value, CurrentUserCurrency.Code, CurrentUser.PriceLevelId));
            if (album == null)
            {
                return HttpNotFound($"Альбом с id = {id} не найден");
            }

            return View(album);
        }

        /// <summary>
        /// Deletes the specified album from the system.
        /// </summary>
        /// <param name="album">
        /// The album to delete.
        /// </param>
        /// <returns>
        /// Redirects to the view which generates page with albums list.
        /// </returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Name")] AlbumManagementViewModel album)
        {
            if (album != null)
            {
                using (var repository = RepositoryFactory.GetAlbumRepository())
                {
                    repository.Delete(ManagementMapper.GetAlbumModel(album));
                    repository.SaveChanges();
                }
            }

            return RedirectToAction("List", "Albums", new { area = "Content" });
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The artist id.
        /// </param>
        /// <returns>
        /// </returns>
        public virtual ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("List", "Albums", new { area = "Content" });
            }

            var albumService = ServiceFactory.GetAlbumService();
            var viewModel = ManagementMapper.GetAlbumManagementViewModel(albumService.GetAlbumDetails(id, CurrentUserCurrency.Code, CurrentUser.PriceLevelId));
            if (viewModel == null)
            {
                return HttpNotFound($"Альбом с id = {id} не найден");
            }

            using (var realtionsRepo = RepositoryFactory.GetAlbumTrackRelationRepository())
            {
                var tracks = realtionsRepo.GetAll(t => t.AlbumId == id, t => t.Track).Select(t => t.Track).ToList();
                ViewBag.Tracks = tracks;
            }

            return View(viewModel);
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
            [Bind(Include = "Id, ArtistId, ArtistName, Name, ReleaseDate, PostedCover, Price, Cover")]
            AlbumManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album currentAlbum;
                using (var repo = this.RepositoryFactory.GetAlbumRepository())
                {
                    currentAlbum = repo.GetById(viewModel.Id);
                }

                if (currentAlbum == null)
                {
                    return this.HttpNotFound($"Альбом с id = {viewModel.Id} не найден");
                }

                if (viewModel.PostedCover == null)
                {
                    viewModel.Cover = currentAlbum.Cover;
                }

                var album = ManagementMapper.GetAlbumModel(viewModel);
                album.OwnerId = currentAlbum.OwnerId;
                using (var albumRepo = RepositoryFactory.GetAlbumRepository())
                {
                    albumRepo.AddOrUpdate(album);
                    albumRepo.SaveChanges();
                }

                if (viewModel.Price != null)
                {
                    using (var priceRepository = RepositoryFactory.GetAlbumPriceRepository())
                    {
                        var albumPrice = priceRepository.FirstOrDefault(p => p.AlbumId == album.Id &&
                                                                             p.CurrencyId == CurrentUserCurrency.Id &&
                                                                             p.PriceLevelId == CurrentUser.PriceLevelId);
                        if (albumPrice == null)
                        {
                            albumPrice = new AlbumPrice
                            {
                                AlbumId = album.Id,
                                CurrencyId = CurrentUserCurrency.Id,
                                PriceLevelId = CurrentUser.PriceLevelId
                            };
                        }

                        albumPrice.Price = viewModel.Price.Value;
                        priceRepository.AddOrUpdate(albumPrice);
                        priceRepository.SaveChanges();
                    }
                }

                return RedirectToAction("Details", "Albums", new { id = album.Id, area = "Content" });
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
            var viewModel = new AlbumManagementViewModel();
            if (artistId > 0)
            {
                using (var artistRepository = RepositoryFactory.GetArtistRepository())
                {
                    var artist = artistRepository.GetById(artistId);
                    if (artist != null)
                    {
                        viewModel.ArtistId = artistId;
                        viewModel.ArtistName = artist.Name;
                    }
                }
            }

            return View(viewModel);
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
            [Bind(Include = "ArtistId, ArtistName, Name, ReleaseDate, PostedCover, Price")] AlbumManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = ManagementMapper.GetAlbumModel(viewModel);

                if (this.CurrentUser != null && this.CurrentUser.IsInRole(UserRoles.Seller))
                {
                    album.OwnerId = this.CurrentUser.UserProfileId;
                }

                using (var albumRepo = RepositoryFactory.GetAlbumRepository())
                {
                    albumRepo.AddOrUpdate(album);
                    albumRepo.SaveChanges();
                }

                if (viewModel.Price != null && CurrentUser != null)
                {
                    using (var priceRepository = RepositoryFactory.GetAlbumPriceRepository())
                    {
                        priceRepository.AddOrUpdate(new AlbumPrice
                        {
                            AlbumId = album.Id,
                            CurrencyId = CurrentUserCurrency.Id,
                            PriceLevelId = CurrentUser.PriceLevelId,
                            Price = viewModel.Price.Value
                        });
                        priceRepository.SaveChanges();
                    }
                }

                return RedirectToAction("Details", new { area = "Content", Controller = "Albums", id = album.Id });
            }

            return View(viewModel);
        }

        /// <summary>
        /// Renders a page for adding tracks to the album.
        /// </summary>
        /// <param name="id">
        /// The album id.
        /// </param>
        /// <returns>
        /// The view for adding tracks to the album.
        /// </returns>
        public ActionResult AddTracksToAlbum(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "Tracks", new { area = "Content" });
            }

            AlbumTracksListViewModel albumTracksViewModel;

            var albumService = ServiceFactory.GetAlbumService();
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                albumTracksViewModel = albumService.GetTracksToAdd(id.Value, CurrentUserCurrency.Code, CurrentUser.PriceLevelId, CurrentUser.UserProfileId);
            }
            else
            {
                albumTracksViewModel = albumService.GetTracksToAdd(id.Value);
            }

            if (albumTracksViewModel == null)
            {
                return HttpNotFound($"Альбом с id = { id.Value } не найден");
            }

            return View(albumTracksViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddTrackToAlbum(int id, int trackId)
        {
            using (var repository = RepositoryFactory.GetAlbumTrackRelationRepository())
            {
                repository.AddOrUpdate(new AlbumTrackRelation
                {
                    AlbumId = id,
                    TrackId = trackId
                });
                repository.SaveChanges();
            }

            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("AddTracksToAlbum", "Albums", new { id = id, area = "Management" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult RemoveTrack(int id, int trackId)
        {
            using (var repository = RepositoryFactory.GetAlbumTrackRelationRepository())
            {
                var albumTrackRelation = repository.FirstOrDefault(r => r.AlbumId == id && r.TrackId == trackId);
                if (albumTrackRelation != null)
                {
                    repository.Delete(albumTrackRelation);
                    repository.SaveChanges();
                }
            }

            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Details", "Albums", new { id = id, area = "Content" });
        }
    }
}