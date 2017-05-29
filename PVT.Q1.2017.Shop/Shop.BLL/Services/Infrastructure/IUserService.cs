namespace Shop.BLL.Services.Infrastructure
{
    using Shop.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// The user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        bool RegisterUser(User user);

        /// <summary>
        /// Check if user already exist
        /// </summary>
        /// <param name="userIdentity"> user login or email </param>
        /// <returns></returns>
        bool IsUserExist(string userIdentity);

        /// <summary>
        /// Returns the Id by his login or password
        /// </summary>
        /// <param name="userIdentity">user login or email</param>
        /// <returns></returns>
        int GetIdOflogin(string userIdentity);

        /// <summary>
        /// Updates user model data by Id
        /// </summary>
        /// <param name="user">model user</param>
        /// <returns></returns>
        bool UpdatePersonal(User user, int Id);

        /// <summary>
        /// Returns the email by his login or password
        /// </summary>
        /// <param name="userIdentity">user login or email</param>
        /// <returns></returns>
        string GetEmailByUserIdentity(string userIdentity);

        /// <summary>
        /// Update user password data by Id
        /// </summary>
        /// <param name="id">Id from model user</param>
        /// <param name="newPassword">new password</param>
        /// <returns></returns>
        bool UpdatePassword(int id, string newPassword);

        /// <summary>
        /// Update user password data by Id
        /// </summary>
        /// <param name="id">Id from model user</param>
        /// <param name="newPassword">new password</param>
        /// <param name="oldPassword">old password</param>
        /// <returns></returns>
        bool UpdatePassword(int id, string newPassword, string oldPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <param name="newLogin"></param>
        /// <returns></returns>
        bool UpdateLogin(string userIdentity, string newLogin);

        /// <summary>
        /// Sets the user to the "Confirm Email" field in true
        /// </summary>
        /// <param name="id">Id from model user</param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool UpdateConfirmEmail(string id, string email);

        /// <summary>
        /// Changes the "IsDeleted" to "true"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool SoftDelete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetUsersCount();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        PagedResult<User> GetDataPerPage(int pageNumber, int count);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        ICollection<User> GetLastNameMatchingData(string pattern);
    }
}
