namespace PVT.Q1._2017.Shop.Areas.Management.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using FluentValidation.Attributes;
    using Validators;

    /// <summary>
    /// </summary>
    [Validator(typeof(ArtistManagementValidator))]
    public class ArtistManagementViewModel
    {
        /// <summary>
        ///     Gets or sets the biography.
        /// </summary>
        [DisplayName("Биография")]
        public string Biography { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("День рождения (основания группы)")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [DisplayName("Исполнитель")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        ///     Gets or sets the photo.
        /// </summary>
        public HttpPostedFileBase PostedPhoto { get; set; }
    }
}