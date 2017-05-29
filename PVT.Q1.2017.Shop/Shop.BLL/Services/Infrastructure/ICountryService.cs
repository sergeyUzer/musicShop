using Shop.Common.Models;

namespace Shop.BLL.Services.Infrastructure
{
    /// <summary>
    /// Country management
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Add new Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        bool AddCountry(Country country);

        /// <summary>
        /// Edit new Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        bool EditCountry(int id, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCountry(int id);
    }
}
