namespace PVT.Q1._2017.Shop.Areas.Management.Controllers
{
    using System.Web.Mvc;

    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;

    using PVT.Q1._2017.Shop.App_Start;
    using PVT.Q1._2017.Shop.Areas.Management.Helpers;
    using PVT.Q1._2017.Shop.Areas.Management.ViewModels;
    using PVT.Q1._2017.Shop.Controllers;

    /// <summary>
    /// </summary>
    [ShopAuthorize(UserRoles.Admin, UserRoles.Seller)]
    public class GenresController : BaseController
    {
        public GenresController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id)
        {
            using (var repository = RepositoryFactory.GetGenreRepository())
            {
                repository.Delete(id);
                repository.SaveChanges();
            }

            CacheHelper.ClearCachedGenres();
            return RedirectToAction("List", "Genres", new { Area = "Content" });
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// </returns>
        public ActionResult Edit(int id)
        {
            var genreService = ServiceFactory.GetGenreService();
            var genreManagementViewModel =
                ManagementMapper.GetGenreManagementViewModel(genreService.GetGenreDetailsViewModel(id));
            return View(genreManagementViewModel);
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
        public ActionResult Edit(GenreManagementViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List", "Genres", new { Area = "Content" });
            }

            var genreModel = ManagementMapper.GetGenreModel(viewModel);
            using (var repo = RepositoryFactory.GetGenreRepository())
            {
                repo.AddOrUpdate(genreModel);
                repo.SaveChanges();
            }

            CacheHelper.ClearCachedGenres();
            return RedirectToAction("Details", "Genres", new { Area = "Content", id = viewModel.Id });
        }

        /// <summary>
        /// </summary>
        /// <param name="model">
        ///     The model.
        /// </param>
        /// <returns>
        /// </returns>
        public virtual ActionResult New()
        {
            return View("New");
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
        public virtual ActionResult New(GenreManagementViewModel viewModel)
        {
            var genre = ManagementMapper.GetGenreModel(viewModel);
            using (var repository = RepositoryFactory.GetGenreRepository())
            {
                repository.AddOrUpdate(genre);
                repository.SaveChanges();
            }

            CacheHelper.ClearCachedGenres();
            return RedirectToAction("Details", "Genres", new { area = "Content", id = genre.Id });
        }
    }
}