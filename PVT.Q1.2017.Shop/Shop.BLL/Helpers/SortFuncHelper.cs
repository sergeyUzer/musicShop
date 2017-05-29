namespace Shop.BLL.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Shop.Common.Models;

    /// <summary>
    /// 
    /// </summary>
    public static class SortFuncHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Expression<Func<User, dynamic>>> GetUserSortFuncDictionary()
        {
            var result = new Dictionary<string, Expression<Func<User, dynamic>>>();

            result["LastName"] = u => u.LastName;
            result["FirstName"] = u => u.FirstName;
            result["Login"] = u => u.Login;
            result["Email"] = u => u.Email;

            return result;
        }
    }
}
