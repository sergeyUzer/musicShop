namespace Shop.BLL.Services.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Common.Models;

    /// <summary>
    /// Currency service interface
    /// </summary>
    public interface ICurrencyRateService
    {
        /// <summary>
        /// Get rate of currency by date
        /// </summary>
        /// <param name="from">Currency</param>
        /// <param name="to">Target currency</param>
        /// <param name="date">Date</param>
        /// <returns></returns>
        decimal GetRateByDate(int from, int to, DateTime date);

        /// <summary>
        /// Get rates by date
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns><see cref="IEnumerable{CurrencyRate}"/></returns>
        IEnumerable<CurrencyRate> GetActualRates(DateTime? date = null);
    }
}
