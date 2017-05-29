namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The genre repository.
    /// </summary>
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public GenreRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Returns the default genre.
        /// </summary>
        /// <returns>
        /// The default genre.
        /// </returns>
        public Genre GetDefaultGenre()
        {
            return CurrentDbSet.FirstOrDefault();
        }

        /// <summary>
        /// Deletes an genre with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The genre id.</param>
        public override void Delete(int id)
        {
            MarkAsDeleted(id);
        }

        /// <summary>
        /// Deletes the <paramref name="genre"/> from the repository.
        /// </summary>
        /// <param name="genre">
        /// The genre to remove.
        /// </param>
        public override void Delete(Genre genre)
        {
            MarkAsDeleted(genre);
        }
    }
}