namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// The <see cref="Album"/> configuration.
    /// </summary>
    public class UserDataConfiguration : EntityTypeConfiguration<UserData>    
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumConfiguration"/> class.
        /// </summary>
        public UserDataConfiguration()
        {
            HasKey(u => u.Id);
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Discount).IsOptional();
            HasRequired(u => u.UserCurrency).WithMany(c => c.Users).HasForeignKey(u => u.CurrencyId).WillCascadeOnDelete(false);

            HasRequired(ud => ud.User).WithMany().HasForeignKey(ud => ud.UserId);

            ToTable("UsersData");
        }
    }
}