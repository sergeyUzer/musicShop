namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The track price repository.
    /// </summary>
    public class TrackPriceRepository : BaseRepository<TrackPrice>, ITrackPriceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackPriceRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public TrackPriceRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        /// <summary>
        /// Adds the specified <paramref name="trackPrice"/> into Db.
        /// </summary>
        /// <param name="trackPrice">
        /// The track price to add.
        /// </param>
        protected override void Add(TrackPrice trackPrice)
        {
            EntityState trackEntryState;
            EntityState currencyEntryState;
            EntityState priceLevelEntryState;

            if (trackPrice.TrackId == 0 && trackPrice.Track != null)
            {
                trackPrice.TrackId = trackPrice.Track.Id;
            }

            if (trackPrice.CurrencyId == 0 && trackPrice.Currency != null)
            {
                trackPrice.CurrencyId = trackPrice.Currency.Id;
            }

            if (trackPrice.PriceLevelId == 0 && trackPrice.PriceLevel != null)
            {
                trackPrice.PriceLevelId = trackPrice.PriceLevel.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The TrackPriceBaseRepository should be SOLID, should only add information about track! Not about track, currency or price level!
            DetachNavigationProperty(trackPrice.Track, out trackEntryState);
            DetachNavigationProperty(trackPrice.Currency, out currencyEntryState);
            DetachNavigationProperty(trackPrice.PriceLevel, out priceLevelEntryState);

            trackPrice.Track = null;
            trackPrice.Currency = null;
            trackPrice.PriceLevel = null;

            // adding the track price into Db
            base.Add(trackPrice);
        }
    }
}