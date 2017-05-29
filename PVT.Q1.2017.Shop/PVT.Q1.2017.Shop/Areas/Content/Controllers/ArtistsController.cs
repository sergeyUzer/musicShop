namespace PVT.Q1._2017.Shop.Areas.Content.Controllers
{
    using System.Web.Mvc;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using Shop.Controllers;

    /// <summary>
    ///     The artist controller.
    /// </summary>
    public class ArtistsController : BaseController
    {
        public ArtistsController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult List(int page = 1, int pageSize = 10)
        {
            var artistsService = ServiceFactory.GetArtistService();
            return this.View(artistsService.GetDetailedArtistsList(page, pageSize));
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The artist id.
        /// </param>
        /// <returns>
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "Artists", new { area = "Content" });
            }

            var artistService = ServiceFactory.GetArtistService();
            ArtistContentViewModel artistViewModel;
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                artistViewModel = artistService.GetContent(id.Value, CurrentUserCurrency.Code, CurrentUser.PriceLevelId, CurrentUser.UserProfileId);
            }
            else
            {
                artistViewModel = artistService.GetContent(id.Value);
            }

            if (artistViewModel == null)
            {
                return HttpNotFound($"Исполнитель с id = { id.Value } не найден");
            }

            return View(artistViewModel);
        }
    }
}