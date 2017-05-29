namespace Shop.BLL
{
    using Common.Validators.Infrastructure;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    using Shop.BLL.Services;
    using Shop.BLL.Services.Infrastructure;
    using Shop.BLL.Utils;
    using Shop.BLL.Utils.Infrastructure;
    using Shop.DAL;

    /// <summary>
    /// Default cofiguration module.
    /// </summary>
    public class DefaultServicesNinjectModule : NinjectModule
    {
        /// <summary>
        /// Loads configuration settings.
        /// </summary>
        public override void Load()
        {
            if (Kernel != null)
            {
                Kernel.Load(new DefaultRepositoriesNinjectModule());
            }

            Bind<IAuthModule>().To<AuthModule>();
            Bind<IUserValidator>().To<UserService>();
            ConfigureServiceFactory();
        }

        /// <summary>
        /// Binds services.
        /// </summary>
        protected virtual void ConfigureServiceFactory()
        {
            Bind<IArtistService>().To<ArtistService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetArtistService());
            Bind<ITrackService>().To<TrackService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetTrackService());
            Bind<IAlbumService>().To<AlbumService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetAlbumService());
            Bind<IGenreService>().To<GenreService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetGenreService());
            Bind<IFeedbackService>().To<FeedbackService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetFeedbackService());
            Bind<ITrackPriceService>().To<TrackPriceService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetTrackPriceService());
            Bind<IAlbumPriceService>().To<AlbumPriceService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetAlbumPriceService());
            Bind<IUserPaymentMethodService>().To<UserPaymentMethodService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetUserPaymentMethodService());
            Bind<IPaymentService>().To<PaymentService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetPaymentService());
            Bind<ICurrencyService>().To<CurrencyService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetCurrencyService());
            Bind<ICurrencyRateService>().To<CurrencyRateService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetCurrencyRateService());
            Bind<ICartService>().To<CartService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetCartService());
            Bind<IUserService>().To<UserService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetUserService());
            Bind<ISettingService>().To<SettingService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetSettingService());
            Bind<ICountryService>().To<CountryService>().NamedLikeFactoryMethod((IServiceFactory f) => f.GetCountryService());
            Bind<IServiceFactory>().ToFactory();
        }
    }
}