namespace PVT.Q1._2017.Shop.Areas.Payment.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using App_Start;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using Shop.Controllers;
    using global::Shop.BLL.Exceptions;
    using global::Shop.Infrastructure.Enums;
    using NLog;

    /// <summary>
    /// Контоллер для корзины покупателя
    /// </summary>
    [ShopAuthorize(UserRoles.Buyer, UserRoles.Customer)]
    public class CartController : BaseController
    {
        /// <summary>
        /// ViewModel для отображения корзины 
        /// </summary>
        private CartViewModel _viewModel;

        /// <summary>
        /// Logger for logging
        /// </summary>
        private Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="serviceFactory">
        /// The service factory.
        /// </param>
        public CartController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
            _viewModel = new CartViewModel();
        }

        /// <summary>
        /// Действие для отображения корзины
        /// </summary>
        [HttpGet]
        public ViewResult Index()
        {
            var cartService = ServiceFactory.GetCartService();
            _viewModel.Tracks = cartService.GetOrderTracks(CurrentUser.Id, CurrentUserCurrency?.Code);
            _viewModel.Albums = cartService.GetOrderAlbums(CurrentUser.Id, CurrentUserCurrency?.Code);
            _viewModel.CurrentUserId = CurrentUser.Id;
            // Установка текущей валюты пользователя и пересчёт суммы к оплате
            if (CurrentUser.Id > 0)
            {
                _viewModel.CurrencyShortName = CurrentUserCurrency.ShortName;
                CartViewModelService.SetTotalPrice(_viewModel, CurrentUserCurrency);
                TempData["cart"] = _viewModel;
            }

            return View(_viewModel);
        }

        /// <summary>
        /// Добавление альбома в корзину и перенаправление на действие отображения корзины
        /// </summary>
        /// <param name="albumId">
        /// Id добавляемого альбома
        /// </param>
        [HttpPost]
        public ActionResult AddAlbum(int albumId = 0)
        {
            try
            {
                var cartService = ServiceFactory.GetCartService();
                cartService.AddAlbum(CurrentUser.Id, albumId);
                Session["IsModifiedOrdersCount"] = true;
            }
            catch (CartServiceException ex)
            {
                _logger.Error("Error : " + ex.Message);
                return HttpNotFound($"Извините, при выборе альбома произошла ошибка! Попробуйте позже!");
            }

            if (Request != null && Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Удаление альбома из корзины и перенаправление на действие отображения корзины
        /// </summary>
        /// <param name="albumId">
        /// Id удаляемого альбома
        /// </param>
        [HttpPost]
        public ActionResult DeleteAlbum(int albumId = 0)
        {
            try
            {
                var cartService = ServiceFactory.GetCartService();
                cartService.RemoveAlbum(CurrentUser.Id, albumId);
                Session["IsModifiedOrdersCount"] = true;
            }
            catch (CartServiceException ex)
            {
                _logger.Error("Error : " + ex.Message);
                return HttpNotFound($"Извините, при удалении альбома произошла ошибка! Попробуйте позже!");
            }

            if (Request != null && Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Добавление трэка в корзину и перенаправление на действие отображения корзины
        /// </summary>
        /// <param name="trackId">
        /// Id добавляемого трэка
        /// </param>
        [HttpPost]
        public ActionResult AddTrack(int trackId = 0)
        {
            try
            {
                var cartService = ServiceFactory.GetCartService();
                cartService.AddTrack(CurrentUser.Id, trackId);
                Session["IsModifiedOrdersCount"] = true;
            }
            catch (CartServiceException ex)
            {
                _logger.Error("Error : " + ex.Message);
                return HttpNotFound($"Извините, при выборе трэка произошла ошибка! Попробуйте позже!");
            }

            if (Request != null && Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Удаление трэка из корзины и перенаправление на действие отображения корзины
        /// </summary>
        /// <param name="trackId">
        /// Id удаляемого трэка
        /// </param>
        [HttpPost]
        public ActionResult DeleteTrack(int trackId = 0)
        {
            try
            {
                var cartService = ServiceFactory.GetCartService();
                cartService.RemoveTrack(CurrentUser.Id, trackId);
                Session["IsModifiedOrdersCount"] = true;
            }
            catch (CartServiceException ex)
            {
                _logger.Error("Error : " + ex.Message);
                return HttpNotFound($"Извините, при удалении трэка произошла ошибка! Попробуйте позже!");
            }

            if (Request != null && Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Очищает всю корзину текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ClearCart()
        {
            var cartService = ServiceFactory.GetCartService();
            cartService.RemoveAll(CurrentUser.Id);
            Session["IsModifiedOrdersCount"] = true;
            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Перемещает товары пользователя в купленные при успешной оплате
        /// </summary>
        /// <param name="isAccepted"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AcceptPayment()
        {
            var isAccepted = false;
            if (Session["IsAccepted"] != null)
            {
                isAccepted = (bool)Session["IsAccepted"];
                Session.Remove("IsAccepted");
            }

            if (isAccepted)
            {
                var cartService = ServiceFactory.GetCartService();
                cartService.AcceptPayment(CurrentUser.Id);
                Session["IsModifiedOrdersCount"] = true;
                return RedirectToAction("Index", "Home", new { Area = string.Empty });
            }

            return RedirectToAction("Index", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Возвращает количество заказов покупателя в корзине
        /// </summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetOrdersCount()
        {
            if (Session["IsModifiedOrdersCount"] == null)
            {
                Session["IsModifiedOrdersCount"] = true;
            }

            int count = 0;
            if (!(bool)Session["IsModifiedOrdersCount"])
            {
                count = (int)Session["OrdersCount"];
                return Json(new { Count = count }, JsonRequestBehavior.AllowGet);
            }

            using (var userDataRepository = RepositoryFactory.GetUserDataRepository())
            {
                var user = userDataRepository.GetById(CurrentUser.Id);
                if (user != null)
                {
                    count += user.OrderTracks.Count;
                    count += user.OrderAlbums.Count;
                    if (Session != null)
                    {
                        Session["OrdersCount"] = count;
                        Session["IsModifiedOrdersCount"] = false;
                    }
                }
            }

            return Json(new { Count = count }, JsonRequestBehavior.AllowGet);
        }
    }
}