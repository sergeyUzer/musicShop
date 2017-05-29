namespace Shop.Common.Models
{
    using Infrastructure.Models;

    /// <summary>
    /// Tracks and Carts relation
    /// </summary>
    public class OrderTrack : BaseEntity
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Track ID
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// UserData
        /// </summary>
        public virtual UserData User { get; set; }

        /// <summary>
        /// Track
        /// </summary>
        public virtual Track Track { get; set; }
    }
}
