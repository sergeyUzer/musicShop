namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Genre"/> configuration.
    /// </summary>
    public class GenreConfiguration : EntityTypeConfiguration<Genre>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreConfiguration"/> class.
        /// </summary>
        public GenreConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(150).IsVariableLength().IsUnicode();
            ToTable("Genres");
        }
    }
}