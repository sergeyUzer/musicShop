namespace Shop.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;
    using Common.Models;
    using Migrations;

    /// <summary>
    /// Music shop Db
    /// </summary>
    public class ShopContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class.
        /// </summary>
        public ShopContext() : this("ShopConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopContext"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">
        /// The connection string or Db name.
        /// </param>
        public ShopContext(string connectionStringOrName) : base(connectionStringOrName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }
        
        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        public DbSet<Track> Tracks { get; set; }

        /// <summary>
        /// Gets or sets the artists.
        /// </summary>
        public DbSet<Artist> Artists { get; set; }

        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// Gets or sets the track prices.
        /// </summary>
        public DbSet<TrackPrice> TrackPrices { get; set; }

        /// <summary>
        /// Gets or sets the album prices.
        /// </summary>
        public DbSet<AlbumPrice> AlbumPrices { get; set; }

        /// <summary>
        /// Gets or sets the price levels.
        /// </summary>
        public DbSet<PriceLevel> PriceLevels { get; set; }

        /// <summary>
        /// Gets or sets the currency rates.
        /// </summary>
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the feedbacks.
        /// </summary>
        public DbSet<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        public DbSet<Vote> Votes { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Ordered Tracks
        /// </summary>
        public DbSet<OrderTrack> OrderTracks { get; set; }

        /// <summary>
        /// Ordered Albums
        /// </summary>
        public DbSet<OrderAlbum> OrderAlbums { get; set; }

        /// <summary>
        /// Purchased Tracks
        /// </summary>
        public DbSet<PurchasedTrack> PurchasedTracks { get; set; }

        /// <summary>
        /// Purchased Albums
        /// </summary>
        public DbSet<PurchasedAlbum> PurchasedAlbums { get; set; }
        
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<Setting> Settings { get; set; }

        /// <summary>
        /// Payment Transactions
        /// </summary>
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }


        /// <summary>
        /// The Db configuration.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                          .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                          .Where(type => type.BaseType != null &&
                                                         type.BaseType.IsGenericType &&
                                                         type.BaseType.GetGenericTypeDefinition() ==
                                                         typeof(EntityTypeConfiguration<>));
            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}