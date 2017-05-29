namespace Shop.Common.ViewModels
{
    /// <summary>
    /// The price view model.
    /// </summary>
    public class PriceViewModel
    {
        /// <summary>
        /// Price amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Price currency.
        /// </summary>
        public CurrencyViewModel Currency { get; set; }
    }
}