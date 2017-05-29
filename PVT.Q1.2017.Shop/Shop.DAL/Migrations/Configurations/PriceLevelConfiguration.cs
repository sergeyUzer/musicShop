namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="PriceLevel"/> configuration.
    /// </summary>
    public class PriceLevelConfiguration : EntityTypeConfiguration<PriceLevel>    
    {
        /// <summary>
        /// C'tor
        /// </summary>
        public PriceLevelConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(150).IsUnicode().IsVariableLength();
         
            ToTable("PriceLevels");
        }
    }
}