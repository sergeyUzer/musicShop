namespace PVT.Q1._2017.Shop.Controllers
{
    using System;
    using System.Web.Mvc;
    using global::Shop.BLL.Helpers;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.BLL.Utils;
    using NLog;

    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        private const string CURRENT_USER_CURRENCY_KEY = "UserCurrency";

        private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        protected readonly IRepositoryFactory RepositoryFactory;
        protected readonly IServiceFactory ServiceFactory;

        public BaseController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory)
        {
            RepositoryFactory = repositoryFactory;
            ServiceFactory = serviceFactory;
        }

        public CurrentUser CurrentUser
        {
            get { return this.HttpContext.User as CurrentUser; }
        }

        protected CurrencyViewModel CurrentUserCurrency
        {
            get
            {
                if (CurrentUser == null)
                {
                    return null;
                }

                if (Session[CURRENT_USER_CURRENCY_KEY] != null)
                {
                    return (CurrencyViewModel)Session[CURRENT_USER_CURRENCY_KEY];
                }

                var userCurrency = GetUserCurrencyFromDb();
                Session[CURRENT_USER_CURRENCY_KEY] = userCurrency;
                return userCurrency;
            }
            set
            {
                if (CurrentUser == null)
                {
                    return;
                }

                SaveUserCurrencyToDb(value);
                Session[CURRENT_USER_CURRENCY_KEY] = value;
            }
        }

        private CurrencyViewModel GetUserCurrencyFromDb()
        {
            Currency currency = null;
            using (var repository = RepositoryFactory.GetUserDataRepository())
            {
                var userData = repository.FirstOrDefault(u => u.UserId == CurrentUser.Id, u => u.UserCurrency);
                if (userData != null)
                {
                    currency = userData.UserCurrency;
                }
            }

            return ModelsMapper.GetCurrencyViewModel(currency);
        }

        private void SaveUserCurrencyToDb(CurrencyViewModel currency)
        {
            if (currency == null)
            {
                throw new ArgumentOutOfRangeException(nameof(currency));
            }

            using (var repository = RepositoryFactory.GetUserDataRepository())
            {
                var userData = repository.FirstOrDefault(u => u.UserId == CurrentUser.Id);

                userData.CurrencyId = currency.Id;
                repository.AddOrUpdate(userData);
                repository.SaveChanges();
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception);
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = this.RedirectToAction("Index", "Error", new { area = string.Empty });
                filterContext.ExceptionHandled = true;

                filterContext.HttpContext.Response.Clear();
            }

            base.OnException(filterContext);
        }
    }
}