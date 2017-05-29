namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="TrackPrice"/> configuration.
    /// </summary>
    public class TrackPriceConfiguration : EntityTypeConfiguration<TrackPrice>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackConfiguration"/> class.
        /// </summary>
        public TrackPriceConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.IsDeleted);
            HasRequired(t => t.PriceLevel).WithMany(t => t.TrackPriceLevels).HasForeignKey(t => t.PriceLevelId).WillCascadeOnDelete(false);
            HasRequired(t => t.Track).WithMany(t => t.TrackPrices).HasForeignKey(t => t.TrackId).WillCascadeOnDelete(false);
            HasRequired(t => t.Currency).WithMany(t => t.TrackPrices).HasForeignKey(t => t.CurrencyId).WillCascadeOnDelete(false);
            ToTable("TrackPrices");
        }
    }
}