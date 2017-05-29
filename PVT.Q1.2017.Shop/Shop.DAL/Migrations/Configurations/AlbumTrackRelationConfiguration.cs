namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="AlbumTrackRelation"/> configuration.
    /// </summary>
    public class AlbumTrackRelationConfiguration : EntityTypeConfiguration<AlbumTrackRelation>
    {
        public AlbumTrackRelationConfiguration()
        {
            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.AlbumId)
                .HasColumnAnnotation(
                                     "Index",
                                     new IndexAnnotation(new[]
                                     {
                                         new IndexAttribute("UniqueRelation_Index") { IsUnique = true, Order = 0 }
                                     }));
            Property(r => r.TrackId)
                .HasColumnAnnotation(
                                     "Index",
                                     new IndexAnnotation(new[]
                                     {
                                         new IndexAttribute("UniqueRelation_Index") { IsUnique = true, Order = 1 }
                                     }));

            HasRequired(r => r.Track).WithMany(t => t.Albums).HasForeignKey(r => r.TrackId).WillCascadeOnDelete(true);
            HasRequired(r => r.Album).WithMany(a => a.Tracks).HasForeignKey(r => r.AlbumId).WillCascadeOnDelete(true);
            
            ToTable("AlbumTrackRelations");
        } 
    }
}