namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Shop.Common.Models;

    /// <summary>
    ///  <see cref="Setting"/>  Configuration
    /// </summary>
    public class SettingConfiguration : EntityTypeConfiguration<Setting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingConfiguration"/> class.
        /// </summary>
        public SettingConfiguration()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.DefaultCurrency).WithMany().HasForeignKey(x => x.DefaultCurrencyId).WillCascadeOnDelete(false);

            ToTable("Settings");
        }
    }
}
