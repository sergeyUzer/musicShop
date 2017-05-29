namespace Shop.Common.Validators.Infrastructure
{
    /// <summary>
    /// Interface for server validation
    /// </summary>
    public interface IUserValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIdentity">User login or password</param>
        /// <returns></returns>
        bool IsUserExist(string userIdentity);
    }
}
