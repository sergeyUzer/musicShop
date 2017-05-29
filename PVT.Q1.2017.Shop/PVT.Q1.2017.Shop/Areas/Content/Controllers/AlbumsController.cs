namespace PVT.Q1._2017.Shop.Areas.Content.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using App_Start;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;
    using PVT.Q1._2017.Shop.Controllers;

    /// <summary>
    ///     The album controller.
    /// </summary>
    public class AlbumsController : BaseController
    {
        public AlbumsController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "Albums", new { area = "Content" });
            }

            AlbumTracksListViewModel albumTracksViewModel = null;
            var albumService = ServiceFactory.GetAlbumService();
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                albumTracksViewModel = albumService.GetTracks(id.Value, CurrentUserCurrency.Code, CurrentUser.PriceLevelId, CurrentUser.UserProfileId);
            }
            else
            {
                albumTracksViewModel = albumService.GetTracks(id.Value);
            }

            if (albumTracksViewModel == null)
            {
                return HttpNotFound($"Альбом с id = {id.Value} не найден");
            }

            return View(albumTracksViewModel);
        }

        /// <summary>
        ///     Shows all albums.
        /// </summary>
        /// <returns>
        ///     All albums view.
        /// </returns>
        public ActionResult List(int page = 1, int pageSize = 10)
        {
            var albumService = ServiceFactory.GetAlbumService();
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                return this.View(albumService.GetAlbums(page, pageSize, CurrentUserCurrency.Code, CurrentUser.PriceLevelId, CurrentUser.UserProfileId));
            }

            return this.View(albumService.GetAlbums(page, pageSize));
        }

        [ShopAuthorize(UserRoles.Buyer, UserRoles.Customer)]
        public async Task<ActionResult> PurchasedList()
        {
            var albumService = ServiceFactory.GetAlbumService();
            var purchasedAlbums = await albumService.GetPurchasedAlbumsAsync(this.CurrentUser.Id).ConfigureAwait(false);

            if (purchasedAlbums == null)
            {
                return this.HttpNotFound("У вас нет приобретенных товаров");
            }

            return this.View(purchasedAlbums);
        }
    }
}