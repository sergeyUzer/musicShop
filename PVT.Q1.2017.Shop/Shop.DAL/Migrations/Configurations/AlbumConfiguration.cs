namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Album"/> configuration.
    /// </summary>
    public class AlbumConfiguration : EntityTypeConfiguration<Album>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumConfiguration"/> class.
        /// </summary>
        public AlbumConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).IsRequired().HasMaxLength(150).IsUnicode().IsVariableLength();
            Property(a => a.ReleaseDate).IsOptional();

            HasOptional(a => a.Artist).WithMany(a => a.Albums).HasForeignKey(a => a.ArtistId).WillCascadeOnDelete(false);
            HasOptional(a => a.Owner).WithMany().HasForeignKey(a => a.OwnerId).WillCascadeOnDelete(false);

            ToTable("Albums");
        }
    }
}