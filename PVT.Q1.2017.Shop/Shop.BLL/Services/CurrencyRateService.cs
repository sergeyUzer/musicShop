namespace Shop.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using DAL.Infrastruture;
    using Infrastructure;

    /// <summary>
    /// Currency service
    /// </summary>
    public class CurrencyRateService : ICurrencyRateService
    {
        /// <summary>
        /// Factory field
        /// </summary>
        private readonly IRepositoryFactory _factory;
        
        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="factory"></param>
        public CurrencyRateService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Get rates by date
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns><see cref="IEnumerable{CurrencyRate}"/></returns>
        public IEnumerable<CurrencyRate> GetActualRates(DateTime? date = null)
        {
            var dateValue = date ?? DateTime.Now;
            using (var repository = _factory.GetCurrencyRateRepository())
            {
                var rates = repository.GetAll(rate => rate.Currency, rate => rate.TargetCurrency);
                return rates.Where(c => c.Date <= dateValue)
                    .GroupBy(rate => new { rate.CurrencyId, rate.TargetCurrencyId })
                        .Select(grouping => grouping.OrderByDescending(rate => rate.Date).FirstOrDefault());
            }
        }

        /// <summary>
        /// Get rate of currency by date
        /// </summary>
        /// <param name="from">Currency</param>
        /// <param name="to">Target currency</param>
        /// <param name="date">Date</param>
        /// <returns></returns>
        public decimal GetRateByDate(int from, int to, DateTime date)
        {
            using (var repository = _factory.GetCurrencyRateRepository())
            {
                if (from == to)
                {
                    return 1;
                }

                var val = repository.GetAll()
                    .Where(c => c.CurrencyId == from && c.TargetCurrencyId == to && c.Date <= date).OrderByDescending(rate => rate.Date).FirstOrDefault();

                return val != null ? val.CrossCourse : 1;
            }
        }
    }
}
