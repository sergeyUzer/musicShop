namespace Shop.BLL.Utils
{
    using System;
    using System.Security.Principal;
    using Common.ViewModels;
    using global::Shop.Common.Models;
    using global::Shop.Infrastructure.Enums;

    /// <summary>
    /// 
    /// </summary>
    public class CurrentUser : IPrincipal
    {
        /// <summary>
        /// 
        /// </summary>
        private IIdentity _userIdentity;

        /// <summary>
        /// 
        /// </summary>
        private User _user;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public CurrentUser(User user, int userProfileId, int priceLevelId)
        {
            UserProfileId = userProfileId;
            PriceLevelId = priceLevelId;
            _user = user;
            _userIdentity = new UserIdentity(_user);
        }

        /// <summary>
        /// 
        /// </summary>
        public IIdentity Identity
        {
            get
            {
                return _userIdentity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return _user.Id;
            }
        }

        public UserRoles UserRole
        {
            get { return _user.UserRole; }
        }

        public int UserProfileId { get; }

        public int PriceLevelId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            if (role == null)
            {
                throw new ArgumentException("role");
            }

            var userIdentity = _userIdentity as UserIdentity;

            if (userIdentity == null)
            {
                return false;
            }

            if (_user.UserRole.ToString().Equals(role, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public bool IsInRole(UserRoles role)
        {
            return _user.UserRole.Equals(role); 
        }
    }
}