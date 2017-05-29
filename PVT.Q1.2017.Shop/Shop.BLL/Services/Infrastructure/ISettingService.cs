namespace Shop.BLL.Services.Infrastructure
{
    using Shop.Common.ViewModels;

    /// <summary>
    /// The setting service
    /// </summary>
    public interface ISettingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SettingViewModel GetSettingViewModel();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultCurrencyId"></param>
        void SaveSettingViewModel(int defaultCurrencyId);
    }
}