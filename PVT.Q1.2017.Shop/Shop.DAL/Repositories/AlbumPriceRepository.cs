namespace Shop.DAL.Repositories
{
    using System.Data.Entity;
    using Common.Models;
    using Infrastruture;

    /// <summary>
    /// The album price repository
    /// </summary>
    public class AlbumPriceRepository : BaseRepository<AlbumPrice>, IAlbumPriceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumPriceRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public AlbumPriceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Adds the specified <paramref name="albumPrice"/> into Db.
        /// </summary>
        /// <param name="albumPrice">
        /// The album price to add.
        /// </param>
        protected override void Add(AlbumPrice albumPrice)
        {
            EntityState albumEntryState;
            EntityState currencyEntryState;
            EntityState priceLevelEntryState;

            if (albumPrice.AlbumId == 0 && albumPrice.Album != null)
            {
                albumPrice.AlbumId = albumPrice.Album.Id;
            }

            if (albumPrice.CurrencyId == 0 && albumPrice.Currency != null)
            {
                albumPrice.CurrencyId = albumPrice.Currency.Id;
            }

            if (albumPrice.PriceLevelId == 0 && albumPrice.PriceLevel != null)
            {
                albumPrice.PriceLevelId = albumPrice.PriceLevel.Id;
            }

            // Detaching the navigation properties in case if they are attached to prevent unexpected behaviour of the DbContext.
            // The AlbumPriceBaseRepository should be SOLID, should only add information about album price! Not about album, currency or price level!
            DetachNavigationProperty(albumPrice.Album, out albumEntryState);
            DetachNavigationProperty(albumPrice.Currency, out currencyEntryState);
            DetachNavigationProperty(albumPrice.PriceLevel, out priceLevelEntryState);

            albumPrice.Album = null;
            albumPrice.Currency = null;
            albumPrice.PriceLevel = null;

            // adding the album price into Db
            base.Add(albumPrice);
        }
    }
}