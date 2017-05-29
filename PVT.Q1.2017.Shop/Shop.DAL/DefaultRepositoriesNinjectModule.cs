namespace Shop.DAL
{
    using System.Data.Entity;
    using Context;
    using Infrastruture;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;
    using Repositories;

    /// <summary>
    /// The default repositories bindings configuration
    /// </summary>
    public class DefaultRepositoriesNinjectModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<DbContext>().To<ShopContext>();
            ConfigureRepositoryFactory();
        }

        /// <summary>
        /// Configures the repository factory.
        /// </summary>
        protected virtual void ConfigureRepositoryFactory()
        {
            Bind<ITrackRepository>()
                .To<TrackRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetTrackRepository());
            Bind<IArtistRepository>()
                .To<ArtistRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetArtistRepository());
            Bind<IAlbumRepository>()
                .To<AlbumRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetAlbumRepository());
            Bind<IFeedbackRepository>()
                .To<FeedbackRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetFeedbackRepository());
            Bind<IVoteRepository>()
                .To<VoteRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetVoteRepository());
            Bind<IGenreRepository>()
                .To<GenreRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetGenreRepository());
            Bind<ITrackPriceRepository>()
                .To<TrackPriceRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetTrackPriceRepository());
            Bind<IAlbumPriceRepository>()
                .To<AlbumPriceRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetAlbumPriceRepository());
            Bind<ICurrencyRateRepository>()
                .To<CurrencyRateRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetCurrencyRateRepository());
            Bind<ICurrencyRepository>()
                .To<CurrencyRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetCurrencyRepository());
            Bind<IPriceLevelRepository>()
                .To<PriceLevelRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetPriceLevelRepository());
            Bind<IUserDataRepository>()
                .To<UserDataRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetUserDataRepository());
            Bind<IAlbumTrackRelationRepository>()
                .To<AlbumTrackRelationRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetAlbumTrackRelationRepository());
            Bind<IUserPaymentMethodRepository>()
                .To<UserPaymentMethodRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetUserPaymentMethodRepository());
            Bind<IPaymentTransactionRepository>()
                .To<PaymentTransactionRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetPaymentTransactionRepository());

            Bind<IUserRepository>()
                .To<UserRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetUserRepository());
            Bind<ISettingRepository>()
                .To<SettingRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetSettingRepository());
            Bind<IOrderTrackRepository>()
                .To<OrderTrackRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetOrderTrackRepository());
            Bind<IOrderAlbumRepository>()
                .To<OrderAlbumRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetOrderAlbumRepository());
            Bind<IPurchasedTrackRepository>()
                .To<PurchasedTrackRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetPurchasedTrackRepository());
            Bind<IPurchasedAlbumRepository>()
                .To<PurchasedAlbumRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetPurchasedAlbumRepository());

            Bind<ICountryRepository>()
                .To<CountryRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetCountryRepository());

            Bind<IRepositoryFactory>().ToFactory();
        }
    }
}