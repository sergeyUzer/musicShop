namespace PVT.Q1._2017.Shop
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Script.Serialization;
    using System.Web.Security;
    using FluentValidation.Mvc;
    using global::Shop.BLL.Utils;
    using global::Shop.Common.Models;
    using NLog;

    /// <summary>
    ///     Base class in an ASP.NET application
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Start application
        /// </summary>
        protected void Application_Start()
        {
            _logger.Info("Music Shop start...");

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
#if DEBUG
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
#endif
        }

        /// <summary>
        /// Occurs when a security module has established the identity of the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                UserPrincipalSerializeModel serializeUser = serializer.Deserialize<UserPrincipalSerializeModel>(authTicket.UserData);
                _logger.Debug($"authTicket: { authTicket.UserData }");

                if (serializeUser != null)
                {
                    User user = new User
                    {
                        Id = serializeUser.Id,
                        Login = serializeUser.Login,
                        Email = serializeUser.Email,
                        UserRole = serializeUser.UserRole
                    };

                    _logger.Debug($"User: id = { user.Id }, login = { user.Login }, e-mail = { user.Email }, role = { user.UserRole }");
                    
                    CurrentUser newUser = new CurrentUser(user, serializeUser.UserProfileId, serializeUser.PriceLevelId);

                    _logger.Debug($"User Data: ProfileId = { serializeUser.UserProfileId }, price level = { serializeUser.PriceLevelId }");

                    HttpContext.Current.User = newUser;
                }
            }
        }
    }
}