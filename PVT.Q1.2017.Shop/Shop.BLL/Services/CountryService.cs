namespace Shop.BLL.Services
{
    using System;
    using Common.Models;
    using Infrastructure;
    using NLog;
    using Shop.DAL.Infrastruture;

    /// <summary>
    /// Service for country management 
    /// </summary>
    public class CountryService : BaseService, ICountryService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public CountryService(IRepositoryFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public bool AddCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("country");
            }

            using (var countries = Factory.GetCountryRepository())
            {
                try
                {
                    countries.AddOrUpdate(country);
                    countries.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Произошла ошибка при добавлении страны:\r\n{ex}");
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCountry(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id <= 0");
            }

            bool isDeleted = false;

            using (var countryRepository = Factory.GetCountryRepository())
            {
                try
                {
                    countryRepository.MarkAsDeleted(id);
                    countryRepository.SaveChanges();
                    isDeleted = true;
                }
                catch (Exception ex)
                {
                    _logger.Error($"Произошла ошибка при удалении страны:\r\n{ex}");
                }
            }

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditCountry(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id <= 0");
            }

            Country country = null;

            if (this.IsCountryExist(id, out country))
            {
                using (var countries = Factory.GetCountryRepository())
                {
                    country.Name = name;

                    try
                    {
                        countries.AddOrUpdate(country);
                        countries.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Произошла ошибка при редактировании страны:\r\n{ex}");
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        private bool IsCountryExist(int id, out Country country)
        {
            country = null;

            if (id <= 0)
            {
                throw new ArgumentException("id <= 0");
            }

            using (var countries = Factory.GetCountryRepository())
            {
                country = countries.GetById(id);
            }

            return country == null ? false : true;
        }
    }
}
