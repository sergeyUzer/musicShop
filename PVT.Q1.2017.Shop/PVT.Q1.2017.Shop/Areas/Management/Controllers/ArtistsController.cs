namespace PVT.Q1._2017.Shop.Areas.Management.Controllers
{
    using System.Web.Mvc;

    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;

    using PVT.Q1._2017.Shop.App_Start;
    using PVT.Q1._2017.Shop.Areas.Management.Helpers;
    using PVT.Q1._2017.Shop.Areas.Management.ViewModels;
    using Shop.Controllers;

    /// <summary>
    ///     The artist controller.
    /// </summary>
    [ShopAuthorize(UserRoles.Admin, UserRoles.Seller)]
    public class ArtistsController : BaseController
    {
        public ArtistsController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Deletes the artist with the specified <paramref name="id"/> from the system.
        /// </summary>
        /// <param name="id">
        /// The artist id.
        /// </param>
        /// <returns>
        /// The view which generates page for deleting artists in case if <paramref name="id"/> was specified;
        /// otherwise redirects to the list of artists.
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return RedirectToAction("List", "Artists", new { area = "Content" });
            }

            var artistService = ServiceFactory.GetArtistService();
            var artist = ManagementMapper.GetArtistManagementViewModel(artistService.GetArtistDetails(id.Value));
            if (artist == null)
            {
                return HttpNotFound($"Исполнитель с id = {id} не найден");
            }

            return View(artist);
        }

        /// <summary>
        /// Deletes the specified artist from the system.
        /// </summary>
        /// <param name="artist">
        /// The artist to delete.
        /// </param>
        /// <returns>
        /// Redirects to the view which generates page with artists list.
        /// </returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Name")] ArtistManagementViewModel artist)
        {
            if (artist != null)
            {
                using (var repository = RepositoryFactory.GetArtistRepository())
                {
                    repository.Delete(ManagementMapper.GetArtistModel(artist));
                    repository.SaveChanges();
                }
            }

            return RedirectToAction("List", "Artists", new { area = "Content" });
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
                return RedirectToAction("List", "Artists", new { area = "Content" });
            }

            var artistService = ServiceFactory.GetArtistService();
            var artist = ManagementMapper.GetArtistManagementViewModel(artistService.GetArtistDetails(id));
            if (artist == null)
            {
                return HttpNotFound($"Исполнитель с id = {id} не найден");
            }

            return View(artist);
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
            [Bind(Include = "Id, Name, Birthday, Biography, Photo, PostedPhoto")]
            ArtistManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Artist currentArtist;
                using (var repo = this.RepositoryFactory.GetArtistRepository())
                {
                    currentArtist = repo.GetById(viewModel.Id);
                }

                if (currentArtist == null)
                {
                    return this.HttpNotFound($"Исполнитель с id = {viewModel.Id} не найден");
                }

                using (var repository = RepositoryFactory.GetArtistRepository())
                {
                    var artist = ManagementMapper.GetArtistModel(viewModel);
                    repository.AddOrUpdate(artist);
                    repository.SaveChanges();
                    return RedirectToAction("Details", "Artists", new { id = viewModel.Id, area = "Content" });
                }
            }

            return View(viewModel);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(
            [Bind(Include = "Name, Birthday, Biography, Photo, PostedPhoto")]
            ArtistManagementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var artist = ManagementMapper.GetArtistModel(viewModel);
                using (var repository = RepositoryFactory.GetArtistRepository())
                {
                    repository.AddOrUpdate(artist);
                    repository.SaveChanges();
                    return RedirectToAction("Details", "Artists", new { area = "Content", id = artist.Id });
                }
            }

            return View(viewModel);
        }
    }
}