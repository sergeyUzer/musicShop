namespace Shop.BLL.Utils.Infrastructure
{
    using System.Security.Principal;
    using System.Web;

    /// <summary>
    /// Module for authentication
    /// </summary>
    public interface IAuthModule
    {
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="useridentity">User login or email</param>
        /// <param name="password">Password</param>
        /// <param name="redirect"></param>       
        void LogIn(string useridentity, string password, HttpContext context, bool redirect);
        
        /// <summary>
        /// User logout
        /// </summary>
        void LogOut();
    }
}
