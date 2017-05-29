using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// </summary>
    public class SettingViewModel
    {
        /// <summary>
        /// Gets or sets the default currency id.
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        /// For drop down list
        /// </summary>
        [Display(Name = "Валюта по умолчанию")]
        public ICollection<CurrencyViewModel> DefaultCurrencyViewModelList { get; set; }
    }
}
