namespace PVT.Q1._2017.Shop.Areas.User.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using App_Start;
    using Helpers;
    using NLog;
    using global::Shop.BLL.Exceptions;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.BLL.Utils;
    using global::Shop.BLL.Utils.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;
    using Shop.Controllers;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    [ShopAuthorize]
    public class ManageController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        private IAuthModule _authModule;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositoryFactory"></param>
        /// <param name="serviceFactory"></param>
        /// <param name="authModule"></param>
        public ManageController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory, IAuthModule authModule)
            : base(repositoryFactory, serviceFactory)
        {
            _authModule = authModule;
        }

        /// <summary>
        /// GET: User/Manage/Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Message = "Редактировать аккаунт";
            return View();
        }

        /// <summary>
        /// GET: User/Manage/UpdatePersonal 
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdatePersonal()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Ваш логин: " + User.Identity.Name;
            }
            else
            {
                ViewBag.Message = "Вы не авторизованы";
                return View();
            }

            using (var countries = RepositoryFactory.GetCountryRepository())
            {
                ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name");
            }

            int id = CurrentUser.Id;
            User userDB = null;
            using (var userRepository = RepositoryFactory.GetUserRepository())
            {
                userDB = userRepository.GetById(id);
            }

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<User, UserPersonalViewModel>());
            var user = AutoMapper.Mapper.Map<UserPersonalViewModel>(userDB);
            return View(user);
        }

        /// <summary>
        /// POST: User/Manage/UpdatePersonal 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePersonal([Bind(Include = @"FirstName, LastName, Sex, BirthDate, CountryId, PhoneNumber")] UserPersonalViewModel user)
        {
            bool result = false;
            if (ModelState.IsValid)
            {

                AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<UserPersonalViewModel, User>());
                var userDB = AutoMapper.Mapper.Map<User>(user);
                var userService = ServiceFactory.GetUserService();
                result = userService.UpdatePersonal(userDB, CurrentUser.Id);

                TempData["userMsg"] = "ok";
            }

            using (var countries = RepositoryFactory.GetCountryRepository())
            {
                ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name");
            }
          
            return View(user);
        }

        /// <summary>
        /// GET: User/Manage/ChangePassword 
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// POST: User/Manage/ChangePassword 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = @"OldPassword, Password, ConfirmPassword")] ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userService = ServiceFactory.GetUserService();
                    if (userService.UpdatePassword(CurrentUser.Id, model.Password, model.OldPassword))
                    {
                        TempData["message"] = "Пароль успешно изменён";
                        return RedirectToAction("ChangeAccepted");
                    }
                }
                catch (UserValidationException ex)
                {
                    ModelState.AddModelError(ex.UserProperty, ex.Message);
                    return View();
                }
            }

            return View();
        }

        /// <summary>
        /// GET: User/Manage/ChangeLogin  
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeLogin()
        {
            return View();
        }

        /// <summary>
        /// POST: User/Manage/ChangeLogin  
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeLogin([Bind(Include = @"Login")] ChangeLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userService = ServiceFactory.GetUserService();
                if (userService.UpdateLogin(User.Identity.Name, user.Login))
                {
                    string subject = "Ваш Логин был изменен";
                    string body = "Новый логин: " + user.Login;
                    string usetEmail = userService.GetEmailByUserIdentity(user.Login);
                    if (!MailDispatch.SendingMail(usetEmail, subject, body))
                    {
                        ModelState.AddModelError(string.Empty, "Ошибка отправки");
                        return View();
                    }

                    HttpContext.Session.Abandon();
                    _authModule.LogOut();
                    return RedirectToAction("Login", "Account", new { area = "User" });
                }
            }

            return View();
        }

        /// <summary>
        /// <summary>
        /// GET: User/Manage/Delete 
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCurrentUserMessage()
        {
            return View();
        }

        /// <summary>
        /// POST: User/Manage/Delete 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCurrentUser()
        {
            try
            {
                var userService = ServiceFactory.GetUserService();
                userService.SoftDelete(CurrentUser.Id);
                HttpContext.Session.Abandon();
                _authModule.LogOut();
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка удаления пользователя\r\n{ex}");
            }

            return RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        /// <summary>
        /// Unified action, displays messages about account changes
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeAccepted()
        {
            ViewBag.Message = TempData["message"];

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ShopAuthorize(UserRoles.Admin)]
        public ActionResult UsersEdit(int id = 1)
        {
            int countPerPage = 10;
            Session["CurrentPage"] = id;

            var userService = ServiceFactory.GetUserService();
            var list = userService.GetDataPerPage(id, countPerPage);
            return View(UserMapper.GetUsersToEdit(list));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(NoStore = false, Duration = 0, Location = System.Web.UI.OutputCacheLocation.None, VaryByParam = "*")]
        public ActionResult GetLastNameMatchingData(string term)
        {
            var userService = ServiceFactory.GetUserService();
            var list = userService.GetLastNameMatchingData(term);
            return Json(list?.Select(u => new {Id = u.Id, FirstName = u.FirstName, LastName = u.LastName}), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Edit user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ShopAuthorize(UserRoles.Admin)]
        public ActionResult Edit(int id)
        {
            User user;
            using (var repository = RepositoryFactory.GetUserRepository())
            {
                user = repository.GetById(id, u => u.Country);
            }

            if (user != null)
            {
                using (var countries = RepositoryFactory.GetCountryRepository())
                {
                    ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name", user.CountryId);
                }

                var editUser = UserMapper.GetUserEditView(user);
                return View(editUser);
            }

            return HttpNotFound();
        }

        /// <summary>
        /// Edit user in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserEditView model)
        {
            if (!ModelState.IsValid)
            {
                using (var countries = RepositoryFactory.GetCountryRepository())
                {
                    ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name", model.CountryId);
                }
                return View("Edit",model);
            }
            if (model != null)
            {
                var userDB = UserMapper.GetUserByUserEditView(model);

                if (userDB != null)
                {
                    using (var repository = RepositoryFactory.GetUserRepository())
                    {
                        try
                        {
                            var user = repository.GetById(userDB.Id);
                            userDB.Password = user.Password;
                            userDB.Login = user.Login;
                            userDB.Email = user.Email;
                            repository.AddOrUpdate(userDB);
                            repository.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            _logger.Error($"Ошибка редактированиия пользователя\r\n{ex}");
                        }
                    }
                }
            }

            return RedirectToAction("UsersEdit", new { controller = "Manage", area = "User", id = Session["CurrentPage"] });
        }

        [HttpGet]
        [ShopAuthorize(UserRoles.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    var userService = ServiceFactory.GetUserService();
                    userService.SoftDelete(id.Value);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Ошибка удаления пользователя\r\n{ex}");
                }
            }

            return RedirectToAction("UsersEdit", new { controller = "Manage", area = "User", id = Session["CurrentPage"] });
        }
    }
}