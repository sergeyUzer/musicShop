namespace PVT.Q1._2017.Shop.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using App_Start;
    using global::Shop.BLL.Helpers;
    using global::Shop.Infrastructure.Enums;
    using Helpers;
    using Management.Helpers;
    using Shop.Controllers;
    using ViewModels;

    /// <summary>
    /// The currency controller for admin
    /// </summary>
    [ShopAuthorize(UserRoles.Admin)]
    public class CurrencyController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        /// <param name="serviceFactory">
        /// The service factory.
        /// </param>
        public CurrencyController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Index GetCurrenciesList
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var currencyService = ServiceFactory.GetCurrencyService();
            var currencies = currencyService.GetCurrencies();
            return View(currencies);
        }

        /// <summary>
        /// Edit Currency
        /// </summary>
        /// <param name="id">currency id for edit</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index", "Currency", new { area = "Admin" });
            }

            Currency currency;
            using (var currencyRepository = RepositoryFactory.GetCurrencyRepository())
            {
                currency = currencyRepository.GetById(id);
            }

            if (currency == null)
            {
                return HttpNotFound("Валюты с указанным id не существует");
            }

            CurrencyViewModel model = ModelsMapper.GetCurrencyViewModel(currency);
            return View(model);
        }

        /// <summary>
        /// Edit Currency
        /// </summary>
        /// <param name="model">CurrencyViewModel for edit</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,ShortName,FullName,Symbol")] CurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Currency currency = AdminModelsMapper.GetCurrency(model);
                using (var currencyRepository = RepositoryFactory.GetCurrencyRepository())
                {
                    currencyRepository.AddOrUpdate(currency);
                    currencyRepository.SaveChanges();

                    CacheHelper.ClearCachedCurrencies();
                    return RedirectToAction("Index", "Currency", new { area = "Admin" });
                }
            }

            return View(model);
        }

        /// <summary>
        /// Delete Currency
        /// </summary>
        /// <param name="id">currency id for delete</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index", "Currency", new { area = "Admin" });
            }

            Currency currency;
            using (var currencyRepository = RepositoryFactory.GetCurrencyRepository())
            {
                currency = currencyRepository.GetById(id);
            }

            if (currency == null)
            {
                return HttpNotFound("Валюты с указанным id не существует");
            }

            CurrencyViewModel model = ModelsMapper.GetCurrencyViewModel(currency);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Code,ShortName,FullName,Symbol")] CurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Currency currency = AdminModelsMapper.GetCurrency(model);
                using (var currencyRepository = RepositoryFactory.GetCurrencyRepository())
                {
                    try
                    {
                        currencyRepository.Delete(currency);
                        currencyRepository.SaveChanges();

                        CacheHelper.ClearCachedCurrencies();
                        return RedirectToAction("Index", "Currency", new { area = "Admin" });
                    }
                    catch
                    {
                        ModelState.AddModelError("ShortName", "Невозможно удалить валюту из системы. Возможно, она используется пользователями магазина.");
                    }
                }
            }

            return View(model);
        }

        /// <summary>
        /// Create Currency
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create Currency by CurrencyViewModel
        /// </summary>
        /// <param name="model">CurrencyViewModel for create</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,ShortName,FullName,Symbol")]CurrencyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Currency currency = AdminModelsMapper.GetCurrency(model);
                    using (var currencyRepository = RepositoryFactory.GetCurrencyRepository())
                    {
                        currencyRepository.AddOrUpdate(currency);
                        currencyRepository.SaveChanges();
                    }

                    CacheHelper.ClearCachedCurrencies();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("Name", "Невозможно сохранить изменения.");
            }

            return View(model);
        }

        /// <summary>
        /// Return list or rates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Rates()
        {
            using (var curRepo = RepositoryFactory.GetCurrencyRepository())
                using (var rateRepo = RepositoryFactory.GetCurrencyRateRepository())
                {
                    return View(rateRepo.GetAll().Select(r => new RateViewModel
                    {
                        Id = r.Id,
                        FromId = r.CurrencyId,
                        ToId = r.TargetCurrencyId,
                        Date = r.Date,
                        Value = r.CrossCourse,
                        From = curRepo.GetAll(),
                        To = curRepo.GetAll()
                    }).ToList());
                }
        }

        /// <summary>
        /// Add rate
        /// </summary>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddRate(RateViewModel rate)
        {
            if (ModelState.IsValid)
            {
                using (var repo = RepositoryFactory.GetCurrencyRateRepository())
                {
                    repo.AddOrUpdate(new CurrencyRate
                    {
                        CurrencyId = rate.FromId,
                        TargetCurrencyId = rate.ToId,
                        CrossCourse = rate.Value,
                        Date = rate.Date
                    });
                    repo.SaveChanges();
                    return RedirectToAction("Rates");
                }
            }

            using (var repo = RepositoryFactory.GetCurrencyRepository())
            {
                rate.From = repo.GetAll();
                rate.To = repo.GetAll();
            }

            return View("AddRate", rate);
        }

        /// <summary>
        /// Add new rate
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddRate()
        {
            using (var repo = RepositoryFactory.GetCurrencyRepository())
            {
                return View(new RateViewModel
                {
                    Date = DateTime.Now.Date,
                    From = repo.GetAll(),
                    To = repo.GetAll()
                });
            }
        }
    }
}