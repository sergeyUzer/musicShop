namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The artist repsitory.
    /// </summary>
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public ArtistRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Deletes an artist with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The artist id.</param>
        public override void Delete(int id)
        {
            MarkAsDeleted(id);
        }

        /// <summary>
        /// Deletes the <paramref name="artist"/> from the repository.
        /// </summary>
        /// <param name="artist">
        /// The artsit to remove.
        /// </param>
        public override void Delete(Artist artist)
        {
            MarkAsDeleted(artist);
        }
    }
}