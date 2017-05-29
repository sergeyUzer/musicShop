namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Track"/> configuration.
    /// </summary>
    public class TrackConfiguration : EntityTypeConfiguration<Track>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackConfiguration"/> class.
        /// </summary>
        public TrackConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(150).IsUnicode().IsVariableLength();

            // TODO: uncomment this when track management will be ready
            // Property(t => t.TrackFile).IsRequired(); 

            HasRequired(t => t.Artist).WithMany(a => a.Tracks).WillCascadeOnDelete(true);
            HasRequired(t => t.Genre).WithMany(a => a.Tracks).WillCascadeOnDelete(true);

            HasOptional(t => t.Owner).WithMany().HasForeignKey(t => t.OwnerId).WillCascadeOnDelete(false);

            ToTable("Tracks");
        }
    }
}