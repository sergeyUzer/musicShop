namespace Shop.BLL.Services
{
    using System.Linq;

    using Common.Models;
    using Common.ViewModels;

    using DAL.Infrastruture;

    using Infrastructure;

    /// <summary>
    /// </summary>
    public class SettingService : BaseService, ISettingService
    {
        /// <summary>
        /// The ICurrencyService
        /// </summary>
        ICurrencyService _currencyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="currencyService">
        /// The currencyService.
        /// </param>
        public SettingService(IRepositoryFactory factory, CurrencyService currencyService) : base(factory)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public SettingViewModel GetSettingViewModel()
        {
            var settingViewModel = new SettingViewModel()
            {
                // fill drop down lists
                DefaultCurrencyViewModelList = _currencyService.GetCurrencies()
            };

            // if setting exists in db
            Setting setting;
            using (var repository = Factory.GetSettingRepository())
            {
                setting = repository.GetAll().FirstOrDefault();
            }

            if (setting != null)
            {
                // set selected value 
                settingViewModel.DefaultCurrencyId = setting.DefaultCurrencyId;
            }

            return settingViewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="defaultCurrencyId"></param>
        public void SaveSettingViewModel(int defaultCurrencyId)
        {
            var setting = new Setting
            {
                DefaultCurrencyId = defaultCurrencyId
            };

            using (var repository = Factory.GetSettingRepository())
            {
                var oldSetting = repository.GetAll().FirstOrDefault();
                if (oldSetting != null)
                {
                    setting.Id = oldSetting.Id;   // replace old value by new one
                }

                repository.AddOrUpdate(setting);
                repository.SaveChanges();
            }
        }
    }
}
