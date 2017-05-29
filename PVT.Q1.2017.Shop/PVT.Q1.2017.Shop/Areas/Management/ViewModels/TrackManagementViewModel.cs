namespace PVT.Q1._2017.Shop.Areas.Management.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using global::Shop.Common.Models;
    using Validators;

    /// <summary>
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(TrackManagementValidator))]
    public class TrackManagementViewModel
    {
        /// <summary>
        ///     Gets or sets the artist.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// The artist name.
        /// </summary>
        [DisplayName("Исполнитель")]
        public string ArtistName { get; set; }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        [DisplayName("Продолжительность")]
        [DataType(DataType.Time)]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets the genre id.
        /// </summary>
        [DisplayName("Жанр")]
        public int GenreId { get; set; }

        /// <summary>
        ///     Gets or sets the genres.
        /// </summary>
        public ICollection<Genre> Genres { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the posted image.
        /// </summary>
        public HttpPostedFileBase PostedImage { get; set; }

        /// <summary>
        ///     Gets or sets the posted track file.
        /// </summary>
        [DisplayName("Файл")]
        public HttpPostedFileBase PostedTrackFile { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        [DisplayName("Стоимость")]
        public decimal? Price { get; set; }

        /// <summary>
        ///     Gets or sets the release date.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата выхода")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the track file.
        /// </summary>
        public byte[] TrackFile { get; set; }
    }
}