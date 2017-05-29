namespace PVT.Q1._2017.Shop.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;

    using PVT.Q1._2017.Shop.App_Start;
    using PVT.Q1._2017.Shop.Controllers;

    /// <summary>
    /// 
    /// </summary>
    [ShopAuthorize(UserRoles.Admin)]
    public class SettingController : BaseController
    {
        public SettingController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }
        
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public ActionResult Index()
        {
            var settingService = ServiceFactory.GetSettingService();
            var setting = settingService.GetSettingViewModel();
            return View(setting);
        }

        /// <summary>
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="defaultCurrencyId"></param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public JsonResult Save(int defaultCurrencyId)
        {
            var settingService = ServiceFactory.GetSettingService();
            settingService.SaveSettingViewModel(defaultCurrencyId);
            return Json("Запись успешно произведена", JsonRequestBehavior.AllowGet);
        }
    }
}