namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="AlbumPrice"/> configuration.
    /// </summary>
    public class AlbumPriceConfiguration : EntityTypeConfiguration<AlbumPrice>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumConfiguration"/> class.
        /// </summary>
        public AlbumPriceConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.IsDeleted);
            HasRequired(a => a.PriceLevel).WithMany(a => a.AlbumPriceLevels).HasForeignKey(p => p.PriceLevelId);
            HasRequired(a => a.Currency).WithMany(a => a.AlbumPrices).HasForeignKey(a => a.CurrencyId);
            HasRequired(a => a.Album).WithMany(a => a.AlbumPrices).HasForeignKey(a => a.AlbumId);
            ToTable("AlbumPrices");
        }
    }
}