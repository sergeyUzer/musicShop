namespace PVT.Q1._2017.Shop.App_Start
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using global::Shop.Common.Models;
    using global::Shop.Infrastructure.Enums;
    using global::Shop.DAL.Infrastruture;

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ShopAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        private UserRoles[] _userRoles;

        /// <summary>
        ///
        /// </summary>
        /// <param name="UserRoles"> Array UserRoles enum </param>
        public ShopAuthorizeAttribute(params UserRoles[] userRoles)
        {
            _userRoles = userRoles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentException("httpContext");
            }
            
            var user = httpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            string userName = user.Identity.Name;

            // TODO: Get user from Repository by Name
            User userDB;
            using (var repository = DependencyResolver.Current.GetService<IRepositoryFactory>().GetUserRepository())
            {
                userDB = userName.Contains("@")
                                 ? repository.FirstOrDefault(u => u.Login.Equals(userName, StringComparison.OrdinalIgnoreCase))
                                 : repository.FirstOrDefault(u => u.Login.Equals(userName, StringComparison.OrdinalIgnoreCase));
            }


            if (user != null && _userRoles.Length > 0)
            {
                if (!_userRoles.ToList().Contains(userDB.UserRole))
                {
                    return false;
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}