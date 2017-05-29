namespace PVT.Q1._2017.Shop.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using App_Start;
    using Areas.Management.Helpers;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.DAL.Infrastruture;

    [ShopAuthorize]
    public class CurrencyController : BaseController
    {
        public CurrencyController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        [ChildActionOnly]
        public ActionResult UserCurrency()
        {
            if (CurrentUserCurrency != null)
            {
                ViewBag.SelectedCurrency = CurrentUserCurrency.Code;
                var currencies = CacheHelper.GetCachedCurrencies();
                if (currencies == null)
                {
                    var currencyService = ServiceFactory.GetCurrencyService();
                    currencies = currencyService.GetCurrencies();
                    CacheHelper.CacheCurrencies(currencies);
                }

                return PartialView("_UserCurrency", currencies);
            }

            return PartialView("_UserCurrency");
        }

        [HttpPost]
        public ActionResult UpdateUserCurrency(int? currencyCode)
        {
            if (CurrentUser != null)
            {
                var currencyService = ServiceFactory.GetCurrencyService();
                var currency = currencyService.GetCurrencyByCode(currencyCode.Value);

                if (currency == null)
                {
                    return HttpNotFound("Валюта с указанным кодом не найдена");
                }

                CurrentUserCurrency = currency;

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }
    }
}