namespace Shop.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The currency view model.
    /// </summary>
    public class CurrencyViewModel
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Soft deleted flag
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the shortname
        /// </summary>
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Поле ShortName должно состоять из 3 прописных символов")]
        [Display(Name = "Буквенное обозначение")]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the fullname
        /// </summary>
        [Display(Name = "Имя")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the code
        /// </summary>
        [Required]
        [Range(0,999)]
        [Display(Name = "Код")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the graphic currency symbol.
        /// </summary>
        [Display(Name = "Символ")]
        public string Symbol { get; set; }
    }
}
