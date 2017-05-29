namespace Shop.DAL.Infrastruture
{
    using Common.Models;
    using Infrastructure.Repositories;

    /// <summary>
    /// The album and track relations.
    /// </summary>
    public interface IAlbumTrackRelationRepository : IRepository<AlbumTrackRelation>
    {
    }
}