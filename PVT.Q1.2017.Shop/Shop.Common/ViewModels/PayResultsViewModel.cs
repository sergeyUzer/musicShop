namespace Shop.Common.ViewModels
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public class PayResultsViewModel
    {
        /// <summary>
        /// Pay results collection
        /// </summary>
        public ICollection<PayResultViewModel> Payments { get; set; }

        /// <summary>
        /// Total amount in current currency
        /// </summary>
        [DisplayName("Продажи")]
        public decimal Total { get; set; }

        /// <summary>
        /// Currency royalties result (90%)
        /// </summary>
        [DisplayName("Авт. отчисления")]
        public decimal Royalties { get; set; }
    }
}
