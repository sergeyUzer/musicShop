namespace PVT.Q1._2017.Shop.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using App_Start;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using Shop.Controllers;
    using global::Shop.Infrastructure.Enums;

    /// <summary>
    /// Country management
    /// </summary>
    [ShopAuthorize(UserRoles.Admin)]
    public class CountryController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositoryFactory"></param>
        /// <param name="serviceFactory"></param>
        public CountryController(global::Shop.DAL.Infrastruture.IRepositoryFactory repositoryFactory, global::Shop.BLL.Services.Infrastructure.IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<CountryViewModel> countries = null;

            using (var countrieRepository = RepositoryFactory.GetCountryRepository())
            {
                countries = countrieRepository.GetAll()
                                .Select(c => new CountryViewModel { Id = c.Id, Name = c.Name });   
            }    
              
            return this.View(countries);
        }

        /// <summary>
        /// Creating new Country
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Creating new Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CountryViewModel country)
        {
            var countryService = ServiceFactory.GetCountryService();
            if (countryService.AddCountry(new Country { Name = country.Name }))
            {
                return this.RedirectToAction("Index", new { controller = "Country", area = "Admin" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Произошла ошибка при сохранении");
            }

            return this.View(country);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            CountryViewModel country = null;

            using (var countryRepository = RepositoryFactory.GetCountryRepository())
            {
                var countryDB = countryRepository.GetById(id);

                if (countryDB != null)
                {
                    country = new CountryViewModel { Id = countryDB.Id, Name = countryDB.Name };
                }
            }

            return this.View(country);            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(CountryViewModel country)
        {
            if (country != null)
            {
                var countryService = ServiceFactory.GetCountryService();
                countryService.EditCountry(country.Id, country.Name);
            }

            return this.RedirectToAction("Index", new { controller = "Country", area = "Admin" });
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var countryService = ServiceFactory.GetCountryService();
                countryService.DeleteCountry(id);
            }

            return this.RedirectToAction("Index", new { controller = "Country", area = "Admin" });
        }
    }
}