namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Vote"/> configuration.
    /// </summary>
    public class VoteConfiguration : EntityTypeConfiguration<Vote>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoteConfiguration"/> class.
        /// </summary>
        public VoteConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Mark).IsRequired();
            HasRequired(v => v.Track).WithMany(t => t.Votes).WillCascadeOnDelete(false);
            HasRequired(v => v.User).WithMany(t => t.Votes).WillCascadeOnDelete(false);

            ToTable("Votes");
        }
    }
}