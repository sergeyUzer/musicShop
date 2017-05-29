namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Feedback"/> configuration.
    /// </summary>
    public class FeedbackConfiguration : EntityTypeConfiguration<Feedback>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackConfiguration"/> class.
        /// </summary>
        public FeedbackConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Comments).IsRequired().IsUnicode().IsVariableLength();
            HasRequired(f => f.Track).WithMany(t => t.Feedbacks).WillCascadeOnDelete(true);
            HasRequired(f => f.User).WithMany(t => t.Feedbacks).WillCascadeOnDelete(true);

            ToTable("Feedbacks");
        }
    }
}