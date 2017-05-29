namespace PVT.Q1._2017.Shop.Areas.Management.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using FluentValidation.Attributes;
    using Validators;


    /// <summary>
    ///     The album view model.
    /// </summary>
    [Validator(typeof(AlbumManagementValidator))]
    public class AlbumManagementViewModel
    {
        /// <summary>
        ///     Gets or sets the artist id.
        /// </summary>
        public int? ArtistId { get; set; }

        /// <summary>
        ///     Gets or sets the artst name.
        /// </summary>
        [DisplayName("Исполнитель")]
        public string ArtistName { get; set; }

        /// <summary>
        ///     Gets or sets the album cover.
        /// </summary>
        public byte[] Cover { get; set; }

        /// <summary>
        ///     Gets or sets the id id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the album name.
        /// </summary>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the posted cover.
        /// </summary>
        public HttpPostedFileBase PostedCover { get; set; }

        /// <summary>
        ///     Gets or sets the album release date.
        /// </summary>
        [DisplayName("Дата релиза")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        [DisplayName("Стоимость")]
        public decimal? Price { get; set; }
    }
}