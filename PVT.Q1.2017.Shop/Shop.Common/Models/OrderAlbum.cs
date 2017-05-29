namespace Shop.Common.Models
{
    using Infrastructure.Models;

    /// <summary>
    /// Albums and Carts relation
    /// </summary>
    public class OrderAlbum : BaseEntity
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Album ID
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// UserData
        /// </summary>
        public virtual UserData User { get; set; }

        /// <summary>
        /// Album
        /// </summary>
        public virtual Album Album { get; set; }
    }
}
