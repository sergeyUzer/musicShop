namespace PVT.Q1._2017.Shop.Areas.Admin.Helpers
{
    using AutoMapper;
    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;

    /// <summary>
    ///     The management mapper
    /// </summary>
    internal static class AdminModelsMapper
    {
        /// <summary>
        ///     The mapper for models with detailed information.
        /// </summary>
        private static readonly IMapper _modelsMapper;

        /// <summary>
        ///     Initializes static members of the <see cref="AdminModelsMapper" /> class.
        /// </summary>
        static AdminModelsMapper()
        {
            _modelsMapper = CreateManagementMapper();
        }

        /// <summary>
        ///     Executes a mapping from the <see cref="CurrencyViewModel" /> model to a new
        ///     <see cref="Currency" /> model.
        /// </summary>
        /// <param name="currency">
        ///     The album domain model.
        /// </param>
        /// <returns>
        ///     A new <see cref="CurrencyViewModel" /> model.
        /// </returns>
        public static Currency GetCurrency(CurrencyViewModel currency)
        {
            return _modelsMapper.Map<Currency>(currency);
        }

        /// <summary>
        ///     Configures and returns a new instance of the mapper for models which have a list of other models.
        /// </summary>
        /// <returns>
        ///     A new instance of the mapper for models which have a list of other models.
        /// </returns>
        private static IMapper CreateManagementMapper()
        {
            var modelsConfiguration = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<CurrencyViewModel, Currency>();
                    });

            return modelsConfiguration.CreateMapper();
        }
    }
}