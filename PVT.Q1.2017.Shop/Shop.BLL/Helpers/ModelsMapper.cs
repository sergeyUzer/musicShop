namespace Shop.BLL.Helpers
{
    using AutoMapper;
    using Common.Models;
    using Common.ViewModels;

    /// <summary>
    /// Default models mapper.
    /// </summary>
    public static class ModelsMapper
    {
        /// <summary>
        /// The mapper for models with detailed information.
        /// </summary>
        private static readonly IMapper _modelDetailsMapper;

        /// <summary>
        /// The common mapper.
        /// </summary>
        private static readonly IMapper _commonMapper;

        /// <summary>
        /// The mapper for models which have a list of other models.
        /// </summary>
        private static readonly IMapper _specialListMapper;

        /// <summary>
        /// Initializes static members of the <see cref="ModelsMapper"/> class.
        /// </summary>
        static ModelsMapper()
        {
            _modelDetailsMapper = CreateModelsDetailsMapper();
            _commonMapper = CreateCommonMapper();
            _specialListMapper = CreateSpecialListMapper();
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Album"/> model to a new <see cref="AlbumDetailsViewModel"/> model.
        /// </summary>
        /// <param name="album">
        /// The album DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="AlbumDetailsViewModel"/> model.
        /// </returns>
        public static AlbumDetailsViewModel GetAlbumDetailsViewModel(Album album)
        {
            return _modelDetailsMapper.Map<AlbumDetailsViewModel>(album);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Album"/> model to a new <see cref="AlbumViewModel"/> model.
        /// </summary>
        /// <param name="album">
        /// The album DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="AlbumViewModel"/> model.
        /// </returns>
        public static AlbumViewModel GetAlbumViewModel(Album album)
        {
            return _commonMapper.Map<AlbumViewModel>(album);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Artist"/> model to a new <see cref="ArtistDetailsViewModel"/> model.
        /// </summary>
        /// <param name="artist">
        /// The artist DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="ArtistDetailsViewModel"/> model.
        /// </returns>
        public static ArtistDetailsViewModel GetArtistDetailsViewModel(Artist artist)
        {
            return _modelDetailsMapper.Map<ArtistDetailsViewModel>(artist);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Artist"/> model to a new <see cref="ArtistViewModel"/> model.
        /// </summary>
        /// <param name="artist">
        /// The artist DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="ArtistViewModel"/> model.
        /// </returns>
        public static ArtistViewModel GetArtistViewModel(Artist artist)
        {
            return _commonMapper.Map<ArtistViewModel>(artist);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Track"/> model to a new <see cref="TrackDetailsViewModel"/> model.
        /// </summary>
        /// <param name="track">
        /// The track DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="TrackDetailsViewModel"/> model.
        /// </returns>
        public static TrackDetailsViewModel GetTrackDetailsViewModel(Track track)
        {
            return _modelDetailsMapper.Map<TrackDetailsViewModel>(track);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Track"/> model to a new <see cref="TrackViewModel"/> model.
        /// </summary>
        /// <param name="track">
        /// The track DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="TrackViewModel"/> model.
        /// </returns>
        public static TrackViewModel GetTrackViewModel(Track track)
        {
            return _commonMapper.Map<TrackViewModel>(track);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Currency"/> model to a new <see cref="CurrencyViewModel"/> model.
        /// </summary>
        /// <param name="currency">
        /// The currency DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="CurrencyViewModel"/> model.
        /// </returns>
        public static CurrencyViewModel GetCurrencyViewModel(Currency currency)
        {
            return _commonMapper.Map<CurrencyViewModel>(currency);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Genre"/> model to a new <see cref="GenreViewModel"/> model.
        /// </summary>
        /// <param name="genre">
        /// The genre DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="GenreViewModel"/> model.
        /// </returns>
        public static GenreViewModel GetGenreViewModel(Genre genre)
        {
            return _commonMapper.Map<GenreViewModel>(genre);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Genre"/> model to a new <see cref="GenreDetailsViewModel"/> model.
        /// </summary>
        /// <param name="genre">
        /// The genre DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="GenreDetailsViewModel"/> model.
        /// </returns>
        public static GenreDetailsViewModel GetGenreDetailsViewModel(Genre genre)
        {
            return _modelDetailsMapper.Map<GenreDetailsViewModel>(genre);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="TrackPrice"/> model to a new <see cref="PriceViewModel"/> model.
        /// </summary>
        /// <param name="trackPrice">
        /// The track price DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="PriceViewModel"/> model.
        /// </returns>
        public static PriceViewModel GetPriceViewModel(TrackPrice trackPrice)
        {
            return _commonMapper.Map<PriceViewModel>(trackPrice);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="AlbumPrice"/> model to a new <see cref="PriceViewModel"/> model.
        /// </summary>
        /// <param name="albumPrice">
        /// The album price DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="PriceViewModel"/> model.
        /// </returns>
        public static PriceViewModel GetPriceViewModel(AlbumPrice albumPrice)
        {
            return _commonMapper.Map<PriceViewModel>(albumPrice);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Track"/> model to a new <see cref="TrackAlbumsListViewModel"/> model.
        /// </summary>
        /// <param name="track">
        /// The track DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="TrackAlbumsListViewModel"/> model.
        /// </returns>
        public static TrackAlbumsListViewModel GetTrackAlbumsListViewModel(Track track)
        {
            return _specialListMapper.Map<TrackAlbumsListViewModel>(track);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Album"/> model to a new <see cref="AlbumTracksListViewModel"/> model.
        /// </summary>
        /// <param name="album">
        /// The album DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="AlbumTracksListViewModel"/> model.
        /// </returns>
        public static AlbumTracksListViewModel GetAlbumTracksListViewModel(Album album)
        {
            return _specialListMapper.Map<AlbumTracksListViewModel>(album);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Feedback"/> model to a new <see cref="FeedbackViewModel"/> model.
        /// </summary>
        /// <param name="feedback">
        /// The feedback DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="FeedbackViewModel"/> model.
        /// </returns>
        public static FeedbackViewModel GetFeedbackViewModel(Feedback feedback)
        {
            return _commonMapper.Map<FeedbackViewModel>(feedback);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="FeedbackViewModel"/> model to a new <see cref="Feedback"/> model.
        /// </summary>
        /// <param name="feedbackViewModel">
        /// The feedback view model.
        /// </param>
        /// <returns>
        /// A new <see cref="Feedback"/> DTO model.
        /// </returns>
        public static Feedback GetFeedback(FeedbackViewModel feedbackViewModel)
        {
            return _commonMapper.Map<Feedback>(feedbackViewModel);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="FeedbackViewModel"/> model to a new <see cref="Vote"/> model.
        /// </summary>
        /// <param name="feedbackViewModel">
        /// The vote view model.
        /// </param>
        /// <returns>
        /// A new <see cref="Vote"/> DTO model.
        /// </returns>
        public static Vote GetVote(FeedbackViewModel feedbackViewModel)
        {
            return _commonMapper.Map<Vote>(feedbackViewModel);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Artist"/> model to a new <see cref="ArtistTracksListViewModel"/> model.
        /// </summary>
        /// <param name="artist">
        /// The artist DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="ArtistTracksListViewModel"/> model.
        /// </returns>
        public static ArtistTracksListViewModel GetArtistTracksListViewModel(Artist artist)
        {
            return _specialListMapper.Map<ArtistTracksListViewModel>(artist);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Artist"/> model to a new <see cref="ArtistAlbumsListViewModel"/> model.
        /// </summary>
        /// <param name="artist">
        /// The artist DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="ArtistAlbumsListViewModel"/> model.
        /// </returns>
        public static ArtistAlbumsListViewModel GetArtistAlbumsListViewModel(Artist artist)
        {
            return _specialListMapper.Map<ArtistAlbumsListViewModel>(artist);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Setting"/> model to a new <see cref="SettingViewModel"/> model.
        /// </summary>
        /// <param name="setting">
        /// The setting DTO model
        /// </param>
        /// <returns>
        /// A new <see cref="SettingViewModel"/> model
        /// </returns>
        public static SettingViewModel GetSettingViewModel(Setting setting)
        {
            return _specialListMapper.Map<SettingViewModel>(setting);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Track"/> model to a new <see cref="PurchasedTrackViewModel"/> model.
        /// </summary>
        /// <param name="track">
        /// The track DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="PurchasedTrackViewModel"/> model.
        /// </returns>
        public static PurchasedTrackViewModel GetPurchasedTrackViewModel(Track track)
        {
            return _modelDetailsMapper.Map<PurchasedTrackViewModel>(track);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Album"/> model to a new <see cref="PurchasedAlbumViewModel"/> model.
        /// </summary>
        /// <param name="album">
        /// The album DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="PurchasedAlbumViewModel"/> model.
        /// </returns>
        public static PurchasedAlbumViewModel GetPurchasedAlbumViewModel(Album album)
        {
            return _modelDetailsMapper.Map<PurchasedAlbumViewModel>(album);
        }

        /// <summary>
        /// Executes a mapping from the <see cref="Track"/> model to a new <see cref="TrackFeedbacksListViewModel"/> model.
        /// </summary>
        /// <param name="track">
        /// The track DTO model.
        /// </param>
        /// <returns>
        /// A new <see cref="TrackFeedbacksListViewModel"/> model.
        /// </returns>
        public static TrackFeedbacksListViewModel GetTrackFeedbacksListViewModel(Track track)
        {
            return _specialListMapper.Map<TrackFeedbacksListViewModel>(track);
        }

        /// <summary>
        /// Configures and returns a new instance of the common mapper.
        /// </summary>
        /// <returns>
        /// A new instance of the common mapper.
        /// </returns>
        private static IMapper CreateCommonMapper()
        {
            MapperConfiguration commonMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistViewModel>()
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Genre, GenreViewModel>();

                cfg.CreateMap<Currency, CurrencyViewModel>();

                cfg.CreateMap<Album, AlbumViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(a => a.Artist))
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0));

                cfg.CreateMap<Track, TrackViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(t => t.Artist))
                   .ForMember(dest => dest.AlbumId, opt => opt.Ignore())
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<TrackPrice, PriceViewModel>()
                   .ForMember(dest => dest.Amount, opt => opt.ResolveUsing(p => p.Price))
                   .ForMember(dest => dest.Currency, opt => opt.MapFrom(p => p.Currency));

                cfg.CreateMap<AlbumPrice, PriceViewModel>()
                   .ForMember(dest => dest.Amount, opt => opt.ResolveUsing(p => p.Price))
                   .ForMember(dest => dest.Currency, opt => opt.MapFrom(p => p.Currency));

                cfg.CreateMap<Feedback, FeedbackViewModel>()
                   .ForMember(dest => dest.UserDataId, opt => opt.ResolveUsing(f => f.UserId))
                   .ForMember(dest => dest.UserName, opt => opt.ResolveUsing(f => f.User != null && f.User.User != null ? f.User.User.Login : string.Empty));

                cfg.CreateMap<FeedbackViewModel, Feedback>()
                   .ForMember(dest => dest.UserId, opt => opt.ResolveUsing(f => f.UserDataId));

                cfg.CreateMap<FeedbackViewModel, Vote>()
                   .ForMember(dest => dest.UserId, opt => opt.ResolveUsing(f => f.UserDataId));

                cfg.CreateMap<Setting, SettingViewModel>();
            });

            return commonMapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Configures and returns a new instance of the mapper for models which have a list of other models.
        /// </summary>
        /// <returns>
        /// A new instance of the mapper for models which have a list of other models.
        /// </returns>
        private static IMapper CreateSpecialListMapper()
        {
            MapperConfiguration specialListMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistViewModel>()
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Genre, GenreViewModel>();

                cfg.CreateMap<Artist, ArtistDetailsViewModel>()
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Track, TrackDetailsViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(t => t.Artist))
                   .ForMember(dest => dest.Genre, opt => opt.MapFrom(t => t.Genre))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Track, TrackAlbumsListViewModel>()
                   .ForMember(dest => dest.TrackDetails, opt => opt.MapFrom(t => t))
                   .ForMember(dest => dest.Albums, opt => opt.Ignore());

                cfg.CreateMap<Album, AlbumDetailsViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(a => a.Artist))
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0));

                cfg.CreateMap<Album, AlbumTracksListViewModel>()
                   .ForMember(dest => dest.AlbumDetails, opt => opt.MapFrom(a => a))
                   .ForMember(dest => dest.Tracks, opt => opt.Ignore());

                cfg.CreateMap<Artist, ArtistTracksListViewModel>()
                   .ForMember(dest => dest.ArtistDetails, opt => opt.MapFrom(a => a))
                   .ForMember(dest => dest.Tracks, opt => opt.Ignore());

                cfg.CreateMap<Artist, ArtistAlbumsListViewModel>()
                   .ForMember(dest => dest.ArtistDetails, opt => opt.MapFrom(a => a))
                   .ForMember(dest => dest.Albums, opt => opt.Ignore());

                cfg.CreateMap<Track, TrackFeedbacksListViewModel>()
                   .ForMember(dest => dest.TrackDetails, opt => opt.MapFrom(t => t))
                   .ForMember(dest => dest.Feedbacks, opt => opt.Ignore());
            });

            return specialListMapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Configures and returns a new instance of the mapper for models with detailed information.
        /// </summary>
        /// <returns>
        /// A new instance of the mapper for models with detailed information.
        /// </returns>
        private static IMapper CreateModelsDetailsMapper()
        {
            MapperConfiguration detailsMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreViewModel>();

                cfg.CreateMap<Genre, GenreDetailsViewModel>();

                cfg.CreateMap<Artist, ArtistViewModel>()
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Artist, ArtistDetailsViewModel>()
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Album, AlbumDetailsViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(a => a.Artist))
                   .ForMember(dest => dest.TracksCount, opt => opt.UseValue(0));

                cfg.CreateMap<Track, TrackDetailsViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(t => t.Artist))
                   .ForMember(dest => dest.Genre, opt => opt.MapFrom(t => t.Genre))
                   .ForMember(dest => dest.AlbumsCount, opt => opt.UseValue(0));

                cfg.CreateMap<Track, PurchasedTrackViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(t => t.Artist))
                   .ForMember(dest => dest.Genre, opt => opt.MapFrom(t => t.Genre));

                cfg.CreateMap<Album, PurchasedAlbumViewModel>()
                   .ForMember(dest => dest.Artist, opt => opt.MapFrom(t => t.Artist))
                   .ForMember(dest => dest.Tracks, opt => opt.Ignore());
            });

            return detailsMapperConfiguration.CreateMapper();
        }
    }
}