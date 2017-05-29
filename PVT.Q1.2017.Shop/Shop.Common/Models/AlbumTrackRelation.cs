namespace Shop.Common.Models
{
    using Infrastructure.Models;

    /// <summary>
    /// The albums and tracks relations
    /// </summary>
    public class AlbumTrackRelation : BaseEntity
    {
        /// <summary>
        /// Album id.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Track id.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// Album.
        /// </summary>
        public virtual Album Album { get; set; }

        /// <summary>
        /// Track.
        /// </summary>
        public virtual Track Track { get; set; }
    }
}