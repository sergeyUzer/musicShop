namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The user repository (have to be extended)
    /// </summary>
    public class UserDataRepository : BaseRepository<UserData>, IUserDataRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public UserDataRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Adds the specified <paramref name="userData"/> into Db.
        /// </summary>
        /// <param name="userData">
        /// The user to add.
        /// </param>
        protected override void Add(UserData userData)
        {
            EntityState priveLevelEntryState;
            EntityState currencyEntryState;
            EntityState userEntryState;

            if (userData.PriceLevelId == 0 && userData.PriceLevel != null)
            {
                userData.PriceLevelId = userData.PriceLevel.Id;
            }

            if (userData.CurrencyId == 0 && userData.UserCurrency != null)
            {
                userData.CurrencyId = userData.UserCurrency.Id;
            }

            if (userData.UserId == 0 && userData.User != null)
            {
                userData.UserId = userData.User.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The UserBaseRepository should be SOLID, should only add information about user! Not about price level or user currency!
            DetachNavigationProperty(userData.PriceLevel, out priveLevelEntryState);
            DetachNavigationProperty(userData.UserCurrency, out currencyEntryState);
            DetachNavigationProperty(userData.User, out userEntryState);

            userData.PriceLevel = null;
            userData.UserCurrency = null;
            userData.User = null;

            // detach more navigation properties here...

            // adding the user into Db
            base.Add(userData);
        }
    }
}