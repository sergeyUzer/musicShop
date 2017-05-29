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
    ///     The track controller
    /// </summary>
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
        ///     Shows track info.
        /// </summary>
        /// <param name="id">The track id.</param>
        /// <returns>
        ///     Track info view.
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.RedirectToAction("List", "Tracks", new { area = "Content" });
            }

            TrackAlbumsListViewModel trackViewModel;
            var trackService = ServiceFactory.GetTrackService();
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                trackViewModel = trackService.GetAlbums(
                    id.Value,
                    CurrentUserCurrency.Code,
                    CurrentUser.PriceLevelId,
                    CurrentUser.UserProfileId);
            }
            else
            {
                trackViewModel = trackService.GetAlbums(id.Value);
            }

            if (trackViewModel == null)
            {
                return this.HttpNotFound($"Трек с id = {id.Value} не найден");
            }

            return this.View(trackViewModel);
        }

        /// <summary>
        ///     Shows all tracks.
        /// </summary>
        /// <returns>
        ///     All tracks view.
        /// </returns>
        public ActionResult List(int page = 1, int pageSize = 10)
        {
            var trackService = ServiceFactory.GetTrackService();
            if (CurrentUser != null && CurrentUserCurrency != null)
            {
                return
                    this.View(
                        trackService.GetTracks(
                            page,
                            pageSize,
                            CurrentUserCurrency.Code,
                            CurrentUser.PriceLevelId,
                            CurrentUser.UserProfileId));
            }

            return this.View(trackService.GetTracks(page, pageSize));
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [ShopAuthorize(UserRoles.Buyer, UserRoles.Customer)]
        public async Task<ActionResult> PurchasedList()
        {
            var trackService = ServiceFactory.GetTrackService();
            var purchasedTracks = await trackService.GetPurchasedTracksAsync(this.CurrentUser.Id).ConfigureAwait(false);

            if (purchasedTracks == null)
            {
                return this.HttpNotFound("У вас нет приобретенных товаров");
            }

            return this.View(purchasedTracks);
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        [ShopAuthorize, OutputCache(NoStore = true, Duration = 0)]
        public FileStreamResult GetTrackAsStream(int id = 0)
        {
            if (id <= 0)
            {
                return null;
            }

            var trackService = ServiceFactory.GetTrackService();
            var trackAudio = trackService.GetTrackAudio(id, this.CurrentUser.UserRole, this.CurrentUser.UserProfileId);

            if (trackAudio?.AudioStream == null || trackAudio.FileName == null)
            {
                return null;
            }

            return new FileStreamResult(trackAudio.AudioStream, this.Response.ContentType)
            {
                FileDownloadName = trackAudio.FileName
            };
        }
    }
}