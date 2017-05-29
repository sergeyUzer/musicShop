namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The genre repository.
    /// </summary>
    public interface IGenreRepository : IRepository<Genre>
    {
        /// <summary>
        /// Returns the default genre.
        /// </summary>
        /// <returns>
        /// The default genre.
        /// </returns>
        Genre GetDefaultGenre();
    }
}