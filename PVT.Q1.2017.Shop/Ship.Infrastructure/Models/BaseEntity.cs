namespace Shop.Infrastructure.Models
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Soft deleted flag
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
