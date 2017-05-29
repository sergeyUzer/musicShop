namespace Shop.Common.ViewModels
{
    using System;
    using Models;
    using System.ComponentModel;

    /// <summary>
    /// Pay result for certain currency
    /// </summary>
    public class PayResultViewModel
    {
        /// <summary>
        /// Currency id
        /// </summary>
        public int CurrencyID { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [DisplayName("Валюта продажи")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Cross course to current currency
        /// </summary>
        [DisplayName("Курс пересчета")]
        public decimal CrossCourse { get; set; }

        /// <summary>
        /// Currency totals result
        /// </summary>
        [DisplayName("Продажи")]
        public decimal Totals { get; set; }

        /// <summary>
        /// Currency royalties result (90%)
        /// </summary>
        [DisplayName("Отчисления")]
        public decimal Royalties { get; set; }

        
    }
}
