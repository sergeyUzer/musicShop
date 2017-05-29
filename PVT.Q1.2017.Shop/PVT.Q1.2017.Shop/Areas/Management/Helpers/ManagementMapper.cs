namespace PVT.Q1._2017.Shop.Areas.Management.Helpers
{
    using System.Collections.Generic;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.Cryptography;

    using AutoMapper;

    using global::Shop.Common.Models;
    using global::Shop.Common.ViewModels;

    using PVT.Q1._2017.Shop.Areas.Management.Extensions;
    using PVT.Q1._2017.Shop.Areas.Management.ViewModels;

    /// <summary>
    ///     The management mapper
    /// </summary>
    internal static class ManagementMapper
    {
        /// <summary>
        ///     The mapper for models with detailed information.
        /// </summary>
        private static readonly IMapper _managementModelsMapper;

        /// <summary>
        ///     Initializes static members of the <see cref="ManagementMapper" /> class.
        /// </summary>
        static ManagementMapper()
        {
            _managementModelsMapper = CreateManagementMapper();
        }

        /// <summary>
        ///     Executes a mapping from the <see cref="AlbumDetailsViewModel" /> model to a new
        ///     <see cref="AlbumManagementViewModel" /> model.
        /// </summary>
        /// <param name="album">
        ///     The album domain model.
        /// </param>
        /// <returns>
        ///     A new <see cref="AlbumManagementViewModel" /> model.
        /// </returns>
        public static AlbumManagementViewModel GetAlbumManagementViewModel(AlbumDetailsViewModel album)
        {
            return _managementModelsMapper.Map<AlbumManagementViewModel>(album);
        }

        /// <summary>
        ///     Executes a mapping from the <see cref="AlbumManagementViewModel" /> model to a new <see cref="Album" /> model.
        /// </summary>
        /// <param name="album">
        ///     The album management view model.
        /// </param>
        /// <returns>
        ///     A new <see cref="Album" /> DTO model.
        /// </returns>
        public static Album GetAlbumModel(AlbumManagementViewModel album)
        {
            return _managementModelsMapper.Map<Album>(album);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        public static object GetArtistManagementViewModel(ArtistDetailsViewModel viewModel)
        {
            return _managementModelsMapper.Map<ArtistManagementViewModel>(viewModel);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        public static Artist GetArtistModel(ArtistManagementViewModel viewModel)
        {
            return _managementModelsMapper.Map<Artist>(viewModel);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        public static GenreManagementViewModel GetGenreManagementViewModel(GenreDetailsViewModel viewModel)
        {
            return _managementModelsMapper.Map<GenreManagementViewModel>(viewModel);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel">
        ///     The view model.
        /// </param>
        /// <returns>
        /// </returns>
        public static Genre GetGenreModel(GenreManagementViewModel viewModel)
        {
            return _managementModelsMapper.Map<Genre>(viewModel);
        }

        /// <summary>
        ///     Executes a mapping from the <see cref="TrackDetailsViewModel" /> model to a new
        ///     <see cref="TrackManagementViewModel" /> model.
        /// </summary>
        /// <param name="track">
        ///     The track domain model.
        /// </param>
        /// <returns>
        ///     A new <see cref="TrackManagementViewModel" /> model.
        /// </returns>
        public static TrackManagementViewModel GetTrackManagementViewModel(Track track)
        {
            return _managementModelsMapper.Map<TrackManagementViewModel>(track);
        }

        /// <summary>
        /// </summary>
        /// <param name="trackDetailsViewModel">
        /// The track details view model.
        /// </param>
        /// <returns>
        /// </returns>
        public static TrackManagementViewModel GetTrackManagementViewModel(TrackDetailsViewModel trackDetailsViewModel)
        {
            return _managementModelsMapper.Map<TrackManagementViewModel>(trackDetailsViewModel);
        }

        /// <summary>
        ///     Executes a mapping from the <see cref="TrackManagementViewModel" /> model to a new <see cref="Track" /> model.
        /// </summary>
        /// <param name="track">
        ///     The track management view model.
        /// </param>
        /// <returns>
        ///     A new <see cref="Track" /> DTO model.
        /// </returns>
        public static Track GetTrackModel(TrackManagementViewModel track)
        {
            return _managementModelsMapper.Map<Track>(track);
        }

        /// <summary>
        /// </summary>
        /// <param name="album">
        ///     The album.
        /// </param>
        /// <returns>
        /// </returns>
        internal static AlbumManagementViewModel GetAlbumManagementViewModel(Album album)
        {
            return _managementModelsMapper.Map<AlbumManagementViewModel>(album);
        }

        /// <summary>
        ///     Configures and returns a new instance of the mapper for models which have a list of other models.
        /// </summary>
        /// <returns>
        ///     A new instance of the mapper for models which have a list of other models.
        /// </returns>
        private static IMapper CreateManagementMapper()
        {
            var managementConfiguration = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<ArtistViewModel, Artist>();

                        cfg.CreateMap<ArtistManagementViewModel, Artist>()
                            .ForMember(
                                dest => dest.Photo,
                                opt =>
                                    opt.MapFrom(src => src.PostedPhoto != null ? src.PostedPhoto.ToBytes() : src.Photo));

                        cfg.CreateMap<GenreViewModel, Genre>();
                        cfg.CreateMap<GenreManagementViewModel, Genre>();
                        cfg.CreateMap<GenreDetailsViewModel, GenreManagementViewModel>();

                        cfg.CreateMap<Track, TrackManagementViewModel>()
                            .ForMember(dest => dest.ArtistName, opt => opt.ResolveUsing(src => src.Artist.Name));

                        cfg.CreateMap<TrackDetailsViewModel, TrackManagementViewModel>()
                           .ForMember(dest => dest.ArtistId, opt => opt.ResolveUsing(src => src.Artist.Id))
                           .ForMember(dest => dest.ArtistName, opt => opt.ResolveUsing(src => src.Artist.Name))
                           .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price?.Amount ?? 0m));

                        cfg.CreateMap<TrackManagementViewModel, Track>()
                            .ForMember(
                                dest => dest.TrackFile,
                                opt =>
                                    opt.MapFrom(
                                        src =>
                                            src.PostedTrackFile != null ? src.PostedTrackFile.ToBytes() : src.TrackFile))
                            .ForMember(
                                dest => dest.Image,
                                opt =>
                                    opt.MapFrom(src => src.PostedImage != null ? src.PostedImage.ToBytes() : src.Image));

                        cfg.CreateMap<ArtistDetailsViewModel, ArtistManagementViewModel>();

                        cfg.CreateMap<Album, AlbumManagementViewModel>();

                        cfg.CreateMap<AlbumDetailsViewModel, AlbumManagementViewModel>()
                           .ForMember(dest => dest.ArtistId, opt => opt.ResolveUsing(src => src.Artist?.Id))
                           .ForMember(dest => dest.ArtistName, opt => opt.ResolveUsing(src => src.Artist?.Name))
                           .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price?.Amount ?? 0m));

                        cfg.CreateMap<AlbumManagementViewModel, Album>()
                            .ForMember(dest => dest.Artist, opt => opt.Ignore())
                            .ForMember(
                                dest => dest.Cover,
                                opt =>
                                    opt.MapFrom(src => src.PostedCover == null ? src.Cover : src.PostedCover.ToBytes()));
                    });

            return managementConfiguration.CreateMapper();
        }
    }
}