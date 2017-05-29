namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipsBtwPurchasedItemsAndUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.UsersData", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.PurchasedTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.UsersData", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedTracks", "UserId", "dbo.UsersData");
            DropForeignKey("dbo.PurchasedTracks", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.PurchasedAlbums", "UserId", "dbo.UsersData");
            DropForeignKey("dbo.PurchasedAlbums", "AlbumId", "dbo.Albums");
            DropIndex("dbo.PurchasedTracks", new[] { "TrackId" });
            DropIndex("dbo.PurchasedTracks", new[] { "UserId" });
            DropIndex("dbo.PurchasedAlbums", new[] { "AlbumId" });
            DropIndex("dbo.PurchasedAlbums", new[] { "UserId" });
            DropTable("dbo.PurchasedTracks");
            DropTable("dbo.PurchasedAlbums");
        }
    }
}
