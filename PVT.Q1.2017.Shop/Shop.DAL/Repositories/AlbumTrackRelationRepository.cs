namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The albums and tracks relations repository
    /// </summary>
    public class AlbumTrackRelationRepository : BaseRepository<AlbumTrackRelation>, IAlbumTrackRelationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumTrackRelationRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public AlbumTrackRelationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Adds the specified <paramref name="relation"/> into Db.
        /// </summary>
        /// <param name="relation">
        /// The album and track relation to add.
        /// </param>
        protected override void Add(AlbumTrackRelation relation)
        {
            EntityState albumEntryState;
            EntityState trackEntryState;

            if (relation.AlbumId == 0 && relation.Album != null)
            {
                relation.AlbumId = relation.Album.Id;
            }

            if (relation.TrackId == 0 && relation.Track != null)
            {
                relation.TrackId = relation.Track.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The AlbumBaseRepository should be SOLID, should only add information about album! Not about artist!
            DetachNavigationProperty(relation.Album, out albumEntryState);
            DetachNavigationProperty(relation.Track, out trackEntryState);

            relation.Album = null;
            relation.Track = null;

            // adding the relation into Db.
            base.Add(relation);
        }
    }
}