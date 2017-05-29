namespace Shop.BLL.Services
{
    using DAL.Infrastruture;

    /// <summary>
    /// The common service.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The repository factory to access the repositories.
        /// </summary>
        protected readonly IRepositoryFactory Factory; // <-- StyleCop generates SA1304 error when the name starts with '_' and lower case latter.

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="factory">
        /// The repository factory to access to the repositories.
        /// </param>
        protected BaseService(IRepositoryFactory factory)
        {
            Factory = factory;
        }
    }
}