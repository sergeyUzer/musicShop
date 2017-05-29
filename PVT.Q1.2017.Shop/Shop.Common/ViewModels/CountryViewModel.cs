namespace Shop.Common.ViewModels
{
    using System.ComponentModel;

    public class CountryViewModel
    {
        /// <summary>
        /// Country Id in DataBase
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country Name
        /// </summary>
        [DisplayName("Страна")]
        public string Name { get; set; }
    }
}
