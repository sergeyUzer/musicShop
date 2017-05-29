namespace Shop.BLL.Services.Infrastructure
{
    /// <summary>
    /// The service factory.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Returns the artist service.
        /// </summary>
        /// <returns>
        /// The artist service.
        /// </returns>
        IArtistService GetArtistService();

        /// <summary>
        /// Returns the track service.
        /// </summary>
        /// <returns>
        /// The track service.
        /// </returns>
        ITrackService GetTrackService();

        /// <summary>
        /// Returns the album service.
        /// </summary>
        /// <returns>
        /// The album service.
        /// </returns>
        IAlbumService GetAlbumService();

        /// <summary>
        /// Returns the genre service.
        /// </summary>
        /// <returns>
        /// The genre service.
        /// </returns>
        IGenreService GetGenreService();

        /// <summary>
        /// Returns the feedback service.
        /// </summary>
        /// <returns>
        /// The feedback service.
        /// </returns>
        IFeedbackService GetFeedbackService();

        /// <summary>
        /// Returns the track price service.
        /// </summary>
        /// <returns>
        /// The track price service.
        /// </returns>
        ITrackPriceService GetTrackPriceService();

        /// <summary>
        /// Returns the album price service.
        /// </summary>
        /// <returns>
        /// The album price service.
        /// </returns>
        IAlbumPriceService GetAlbumPriceService();

        /// <summary>
        /// Returns the user payment method service.
        /// </summary>
        /// <returns>
        /// The user payment method service.
        /// </returns>
        IUserPaymentMethodService GetUserPaymentMethodService();

        /// <summary>
        /// Returns the payment service.
        /// </summary>
        /// <returns>
        /// The payment service.
        /// </returns>
        IPaymentService GetPaymentService();

        /// <summary>
        /// Returns the currency service.
        /// </summary>
        /// <returns>
        /// The currency service.
        /// </returns>
        ICurrencyService GetCurrencyService();

        /// <summary>
        /// Returns the currency rate service.
        /// </summary>
        /// <returns>
        /// The currency rate service.
        /// </returns>
        ICurrencyRateService GetCurrencyRateService();

        /// <summary>
        /// Returns the cart service.
        /// </summary>
        /// <returns>
        /// The cart service.
        /// </returns>
        ICartService GetCartService();

        /// <summary>
        /// Returns the user service.
        /// </summary>
        /// <returns>
        /// The user service.
        /// </returns>
        IUserService GetUserService();

        /// <summary>
        /// Returns the settings service.
        /// </summary>
        /// <returns>
        /// The settings service.
        /// </returns>
        ISettingService GetSettingService();

        /// <summary>
        /// Returns the country service.
        /// </summary>
        /// <returns></returns>
        ICountryService GetCountryService();
    }
}