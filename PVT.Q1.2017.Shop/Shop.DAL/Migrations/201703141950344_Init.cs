namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAlbumPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumId = c.Int(nullable: false),
                        PriceLevelId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbAlbums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.tbCurrencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.tbPriceLevels", t => t.PriceLevelId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.PriceLevelId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.tbAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Cover = c.Binary(),
                        ReleaseDate = c.DateTime(),
                        ArtistId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbArtists", t => t.ArtistId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.tbArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Biography = c.String(),
                        Birthday = c.DateTime(),
                        Photo = c.Binary(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ReleaseDate = c.DateTime(),
                        Image = c.Binary(),
                        TrackFile = c.Binary(),
                        Duration = c.Time(precision: 7),
                        ArtistId = c.Int(),
                        GenreId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbArtists", t => t.ArtistId)
                .ForeignKey("dbo.tbGenres", t => t.GenreId)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.tbAlbumTrackRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbAlbums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.tbTracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => new { t.AlbumId, t.TrackId }, unique: true, name: "UniqueRelation_Index");
            
            CreateTable(
                "dbo.tbFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(nullable: false),
                        TrackId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbTracks", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.tbUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityKey = c.String(nullable: false, maxLength: 128),
                        Dicount = c.Double(),
                        CurrencyId = c.Int(nullable: false),
                        PriceLevelId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbPriceLevels", t => t.PriceLevelId, cascadeDelete: true)
                .ForeignKey("dbo.tbCurrencies", t => t.CurrencyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.PriceLevelId);
            
            CreateTable(
                "dbo.tbPriceLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbTrackPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrackId = c.Int(nullable: false),
                        PriceLevelId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbCurrencies", t => t.CurrencyId)
                .ForeignKey("dbo.tbPriceLevels", t => t.PriceLevelId)
                .ForeignKey("dbo.tbTracks", t => t.TrackId)
                .Index(t => t.TrackId)
                .Index(t => t.PriceLevelId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.tbCurrencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(nullable: false, maxLength: 3),
                        FullName = c.String(maxLength: 150),
                        Code = c.Int(nullable: false),
                        Symbol = c.String(maxLength: 10),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ShortName, unique: true, name: "UniqueCurrencyName_Index")
                .Index(t => t.Code, unique: true, name: "UniqueCurrencyCode_Index");
            
            CreateTable(
                "dbo.tbCurrencyRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrossCourse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        CurrencyId = c.Int(nullable: false),
                        TargetCurrencyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbCurrencies", t => t.CurrencyId)
                .ForeignKey("dbo.tbCurrencies", t => t.TargetCurrencyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.TargetCurrencyId);
            
            CreateTable(
                "dbo.tbVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbTracks", t => t.TrackId)
                .ForeignKey("dbo.tbUsers", t => t.UserId)
                .Index(t => t.TrackId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAlbumPrices", "PriceLevelId", "dbo.tbPriceLevels");
            DropForeignKey("dbo.tbAlbumPrices", "CurrencyId", "dbo.tbCurrencies");
            DropForeignKey("dbo.tbAlbumPrices", "AlbumId", "dbo.tbAlbums");
            DropForeignKey("dbo.tbAlbums", "ArtistId", "dbo.tbArtists");
            DropForeignKey("dbo.tbTracks", "GenreId", "dbo.tbGenres");
            DropForeignKey("dbo.tbFeedbacks", "UserId", "dbo.tbUsers");
            DropForeignKey("dbo.tbVotes", "UserId", "dbo.tbUsers");
            DropForeignKey("dbo.tbVotes", "TrackId", "dbo.tbTracks");
            DropForeignKey("dbo.tbUsers", "CurrencyId", "dbo.tbCurrencies");
            DropForeignKey("dbo.tbUsers", "PriceLevelId", "dbo.tbPriceLevels");
            DropForeignKey("dbo.tbTrackPrices", "TrackId", "dbo.tbTracks");
            DropForeignKey("dbo.tbTrackPrices", "PriceLevelId", "dbo.tbPriceLevels");
            DropForeignKey("dbo.tbTrackPrices", "CurrencyId", "dbo.tbCurrencies");
            DropForeignKey("dbo.tbCurrencyRates", "TargetCurrencyId", "dbo.tbCurrencies");
            DropForeignKey("dbo.tbCurrencyRates", "CurrencyId", "dbo.tbCurrencies");
            DropForeignKey("dbo.tbFeedbacks", "TrackId", "dbo.tbTracks");
            DropForeignKey("dbo.tbTracks", "ArtistId", "dbo.tbArtists");
            DropForeignKey("dbo.tbAlbumTrackRelations", "TrackId", "dbo.tbTracks");
            DropForeignKey("dbo.tbAlbumTrackRelations", "AlbumId", "dbo.tbAlbums");
            DropIndex("dbo.tbVotes", new[] { "UserId" });
            DropIndex("dbo.tbVotes", new[] { "TrackId" });
            DropIndex("dbo.tbCurrencyRates", new[] { "TargetCurrencyId" });
            DropIndex("dbo.tbCurrencyRates", new[] { "CurrencyId" });
            DropIndex("dbo.tbCurrencies", "UniqueCurrencyCode_Index");
            DropIndex("dbo.tbCurrencies", "UniqueCurrencyName_Index");
            DropIndex("dbo.tbTrackPrices", new[] { "CurrencyId" });
            DropIndex("dbo.tbTrackPrices", new[] { "PriceLevelId" });
            DropIndex("dbo.tbTrackPrices", new[] { "TrackId" });
            DropIndex("dbo.tbUsers", new[] { "PriceLevelId" });
            DropIndex("dbo.tbUsers", new[] { "CurrencyId" });
            DropIndex("dbo.tbFeedbacks", new[] { "UserId" });
            DropIndex("dbo.tbFeedbacks", new[] { "TrackId" });
            DropIndex("dbo.tbAlbumTrackRelations", "UniqueRelation_Index");
            DropIndex("dbo.tbTracks", new[] { "GenreId" });
            DropIndex("dbo.tbTracks", new[] { "ArtistId" });
            DropIndex("dbo.tbAlbums", new[] { "ArtistId" });
            DropIndex("dbo.tbAlbumPrices", new[] { "CurrencyId" });
            DropIndex("dbo.tbAlbumPrices", new[] { "PriceLevelId" });
            DropIndex("dbo.tbAlbumPrices", new[] { "AlbumId" });
            DropTable("dbo.tbGenres");
            DropTable("dbo.tbVotes");
            DropTable("dbo.tbCurrencyRates");
            DropTable("dbo.tbCurrencies");
            DropTable("dbo.tbTrackPrices");
            DropTable("dbo.tbPriceLevels");
            DropTable("dbo.tbUsers");
            DropTable("dbo.tbFeedbacks");
            DropTable("dbo.tbAlbumTrackRelations");
            DropTable("dbo.tbTracks");
            DropTable("dbo.tbArtists");
            DropTable("dbo.tbAlbums");
            DropTable("dbo.tbAlbumPrices");
        }
    }
}
