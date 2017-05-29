
namespace Shop.DAL.Migrations.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    /// <summary>
    /// Currency mapping
    /// </summary>
    public class CurrencyRateConfiguration : EntityTypeConfiguration<CurrencyRate>
    {
        public CurrencyRateConfiguration()
        {
            HasKey(cr => cr.Id);
            Property(cr => cr.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(cr => cr.CrossCourse).IsRequired();
            HasRequired(cr => cr.Currency).WithMany(c => c.CurrencyRates).HasForeignKey(cr => cr.CurrencyId).WillCascadeOnDelete(false);
            HasRequired(cr => cr.TargetCurrency).WithMany(c => c.TargetCurrencyRates).HasForeignKey(cr => cr.TargetCurrencyId).WillCascadeOnDelete(false);

            ToTable("CurrencyRates");
        }
    }
}
