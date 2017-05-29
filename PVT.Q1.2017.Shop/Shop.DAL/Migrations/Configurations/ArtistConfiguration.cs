namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Artist"/> configuration.
    /// </summary>
    public class ArtistConfiguration : EntityTypeConfiguration<Artist>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistConfiguration"/> class.
        /// </summary>
        public ArtistConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(150).IsUnicode().IsVariableLength();
            Property(a => a.Biography).IsMaxLength();
            Property(a => a.Birthday).IsOptional();
            ToTable("Artists");
        }
    }
}