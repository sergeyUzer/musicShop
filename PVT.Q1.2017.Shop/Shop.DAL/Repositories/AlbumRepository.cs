namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The album repository
    /// </summary>
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public AlbumRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Deletes an album with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The album id.</param>
        public override void Delete(int id)
        {
            MarkAsDeleted(id);
        }

        /// <summary>
        /// Deletes the <paramref name="album"/> from the repository.
        /// </summary>
        /// <param name="album">
        /// The album to remove.
        /// </param>
        public override void Delete(Album album)
        {
            MarkAsDeleted(album);
        }

        /// <summary>
        /// Adds the specified <paramref name="album"/> into Db.
        /// </summary>
        /// <param name="album">
        /// The album to add.
        /// </param>
        protected override void Add(Album album)
        {
            EntityState artistEntryState;
            EntityState ownerEntryState;

            if (album.ArtistId == null && album.Artist != null)
            {
                album.ArtistId = album.Artist.Id;
            }

            if (album.OwnerId == null && album.Owner != null)
            {
                album.OwnerId = album.Owner.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The AlbumBaseRepository should be SOLID, should only add information about album! Not about artist!
            DetachNavigationProperty(album.Artist, out artistEntryState);
            DetachNavigationProperty(album.Owner, out ownerEntryState);

            album.Artist = null;
            album.Owner = null;

            // adding the album into Db.
            base.Add(album);
        }
    }
}