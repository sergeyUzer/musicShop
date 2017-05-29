namespace PVT.Q1._2017.Shop.Areas.User.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Helpers;
    using global::Shop.BLL.Exceptions;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.BLL.Utils;
    using global::Shop.BLL.Utils.Infrastructure;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using Shop.Controllers;
    using ViewModels;

    /// <summary>
    /// 
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private IAuthModule _authModule;

        public AccountController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory, IAuthModule authModule)
            : base(repositoryFactory, serviceFactory)
        {
            _authModule = authModule;
        }

        /// <summary>
        /// Method for remote validation (login)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [OutputCache(NoStore = false, Duration = 0)]
        public JsonResult IsLoginUnique(string login)
        {
            var userService = ServiceFactory.GetUserService();
            var isUnique = !userService.IsUserExist(login);

            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Method for remote validation (email)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [OutputCache(NoStore = false, Duration = 0)]
        public JsonResult IsEmailUnique(string email)
        {
            var userService = ServiceFactory.GetUserService();
            var isUnique = !userService.IsUserExist(email);

            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Method for remote validation (userIdentity)
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [OutputCache(NoStore = false, Duration = 0)]
        public ActionResult IsUserNotExist(string userIdentity)
        {
            var userService = ServiceFactory.GetUserService();
            var isUnique = userService.IsUserExist(userIdentity);

            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GET: User/Account/Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        /// <summary>
        /// POST: User/Account/Login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserIdentity, Password, RememberMe")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authModule.LogIn(model.UserIdentity, model.Password, System.Web.HttpContext.Current, model.RememberMe);

                    var returnUrl = HttpContext.Request.QueryString["ReturnUrl"];

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                }
                catch (UserValidationException ex)
                {
                    ModelState.AddModelError(ex.UserProperty, ex.Message);
                    return View(model);
                }
            }

            return RedirectToRoute(new { controller = "Home", action = "Index", area = string.Empty });
        }

        /// <summary>
        /// POST: User/Account/LogOut
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            Session.Abandon();
            _authModule.LogOut();

            return RedirectToAction("Login", "Account", new { area = "User" });
        }

        /// <summary>
        /// GET: User/Account/Register
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            using (var countries = RepositoryFactory.GetCountryRepository())
            {
                ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name");
            }

            return View();
        }

        /// <summary>
        /// POST: User/Account/Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = @"Login, Password, ConfirmPassword, 
                                                    Email")] UserViewModel user)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                var userDB = UserMapper.GetUserModel(user);
                var userService = ServiceFactory.GetUserService();
                result = userService.RegisterUser(userDB);
                if (!result)
                {
                    ModelState.AddModelError(string.Empty, "Ошибка регистрации");
                    return View(user);
                }
                string subject = "Подтверждение регистрации";
                string body = string.Format(
                                            "Для завершения регистрации перейдите по ссылке:" +
                                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                    Url.Action("ConfirmEmail", "Account", new { Token = userDB.Id, Email = userDB.Email }, Request.Url.Scheme));
                if (await MailDispatch.SendingMailAsync(userDB.Email, subject, body).ConfigureAwait(false))
                {
                    return RedirectToAction("Confirm", "Account", new { Email = userDB.Email });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ошибка отправки сообщения");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Произошла ошибка при регистрации");
            }
            using (var countries = RepositoryFactory.GetCountryRepository())
            {
                ViewBag.Countries = new SelectList(countries.GetAll(), "Id", "Name");
            }

            return View(user);
        }

        /// <summary>
        /// GET: User/Account/Siterules
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Siterules()
        {
            return View();
        }

        /// <summary>
        /// GET: User/Account/Confirm
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Confirm(string Email)
        {
            if (Email != null)
            {
                ViewBag.Message = "На почтовый адрес " + Email + " Вам высланы дальнейшие " +
                    "инструкции по завершению регистрации";
            }
            return View();
        }

        /// <summary>
        /// GET: User/Account/ConfirmEmail
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string token, string email)
        {
            if (token == null)
            {
                throw new ArgumentException("Token");
            }

            if (token == null)
            {
                throw new ArgumentException("Email");
            }

            var userService = ServiceFactory.GetUserService();
            if (userService.UpdateConfirmEmail(token, email))
            {
                return RedirectToAction("Success", "Account", new { area = "User" });
            }

            return RedirectToAction("Confirm", "Account", new { Email = string.Empty });
        }

        /// <summary>
        /// GET: User/Account/ForgotPassword
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ForgotPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// POST: User/Account/ForgotPassword
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword([Bind(Include = "UserIdentity")] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userService = ServiceFactory.GetUserService();
                    string userEmail = userService.GetEmailByUserIdentity(model.UserIdentity);
                    int id = userService.GetIdOflogin(userEmail);
                    string newPassword = PasswordEncryptor.RendomPassword();
                    if (userService.UpdatePassword(id, newPassword))
                    {
                        string subject = "Ваш пароль был изменен";
                        string body = "Новый пароль: " + newPassword;
                        if (await MailDispatch.SendingMailAsync(userEmail, subject, body).ConfigureAwait(false))
                        {
                            return this.RedirectToAction("ForgotPasswordSuccess");
                        }
                    }
                }
                catch (UserValidationException ex)
                {
                    ModelState.AddModelError(ex.UserProperty, ex.Message);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ошибка восстановления пароля");
                return View();
            }

            return View();
        }

        /// <summary>
        /// GET: User/Account/ForgotPasswordSuccess
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPasswordSuccess()
        {
            return View();
        }

        /// <summary>
        /// GET: User/Account/Success
        /// </summary>
        /// <returns></returns>
        public ActionResult Success()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(NoStore = false, Duration = 0)]
        public JsonResult GetCountries()
        {
            using (var countries = RepositoryFactory.GetCountryRepository())
            {
                return Json(countries.GetAll(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
