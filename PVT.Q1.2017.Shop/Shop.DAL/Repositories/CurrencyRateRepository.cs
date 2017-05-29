namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The currency rate repository.
    /// </summary>
    public class CurrencyRateRepository : BaseRepository<CurrencyRate>, ICurrencyRateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRateRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public CurrencyRateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Adds the specified <paramref name="currencyRate"/> into Db.
        /// </summary>
        /// <param name="currencyRate">
        /// The currency rate to add.
        /// </param>
        protected override void Add(CurrencyRate currencyRate)
        {
            EntityState currencyEntryState;
            EntityState targetCurrencyEntryState;

            if (currencyRate.CurrencyId == 0 && currencyRate.Currency != null)
            {
                currencyRate.CurrencyId = currencyRate.Currency.Id;
            }

            if (currencyRate.TargetCurrencyId == 0 && currencyRate.TargetCurrency != null)
            {
                currencyRate.TargetCurrencyId = currencyRate.TargetCurrency.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The CurrencyRateBaseRepository should be SOLID, should only add information about currency rate! Not about currencies!
            DetachNavigationProperty(currencyRate.Currency, out currencyEntryState);
            DetachNavigationProperty(currencyRate.TargetCurrency, out targetCurrencyEntryState);

            currencyRate.Currency = null;
            currencyRate.TargetCurrency = null;

            // adding the currency rate into Db.
            base.Add(currencyRate);
        }
    }
}