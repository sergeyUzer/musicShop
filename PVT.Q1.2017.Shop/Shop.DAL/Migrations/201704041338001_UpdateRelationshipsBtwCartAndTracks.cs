namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationshipsBtwCartAndTracks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Tracks", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Albums", new[] { "Cart_Id" });
            DropIndex("dbo.Tracks", new[] { "Cart_Id" });

            CreateTable(
                "dbo.OrderTracks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CartId = c.Int(nullable: false),
                    TrackId = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.TrackId);

            CreateTable(
                "dbo.OrderAlbums",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CartId = c.Int(nullable: false),
                    AlbumId = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.AlbumId);

            DropColumn("dbo.Albums", "Cart_Id");
            DropColumn("dbo.Tracks", "Cart_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Tracks", "Cart_Id", c => c.Int());
            AddColumn("dbo.Albums", "Cart_Id", c => c.Int());
            DropForeignKey("dbo.OrderTracks", "CartId", "dbo.Carts");
            DropForeignKey("dbo.OrderAlbums", "CartId", "dbo.Carts");
            DropForeignKey("dbo.OrderTracks", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.OrderAlbums", "AlbumId", "dbo.Albums");
            DropIndex("dbo.OrderAlbums", new[] { "AlbumId" });
            DropIndex("dbo.OrderAlbums", new[] { "CartId" });
            DropIndex("dbo.OrderTracks", new[] { "TrackId" });
            DropIndex("dbo.OrderTracks", new[] { "CartId" });
            DropTable("dbo.OrderAlbums");
            DropTable("dbo.OrderTracks");
            RenameColumn(table: "dbo.OrderTracks", name: "CartId", newName: "Cart_Id");
            RenameColumn(table: "dbo.OrderAlbums", name: "CartId", newName: "Cart_Id");
            CreateIndex("dbo.Tracks", "Cart_Id");
            CreateIndex("dbo.Albums", "Cart_Id");
            AddForeignKey("dbo.Tracks", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Albums", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
