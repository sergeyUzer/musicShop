namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRelationshipsBtwTrackAlbumsAndUserData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderAlbums", "CartId", "dbo.Carts");
            DropForeignKey("dbo.OrderTracks", "CartId", "dbo.Carts");
            DropIndex("dbo.OrderTracks", new[] { "CartId" });
            DropIndex("dbo.OrderAlbums", new[] { "CartId" });
            DropColumn("dbo.OrderTracks", "CartId");
            DropColumn("dbo.OrderAlbums", "CartId");
            AddColumn("dbo.OrderTracks", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderAlbums", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderAlbums", "UserId");
            CreateIndex("dbo.OrderTracks", "UserId");
            AddForeignKey("dbo.OrderAlbums", "UserId", "dbo.UsersData", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderTracks", "UserId", "dbo.UsersData", "Id", cascadeDelete: true);
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderAlbums", "CartId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderTracks", "CartId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderTracks", "UserId", "dbo.UsersData");
            DropForeignKey("dbo.OrderAlbums", "UserId", "dbo.UsersData");
            DropIndex("dbo.OrderTracks", new[] { "UserId" });
            DropIndex("dbo.OrderAlbums", new[] { "UserId" });
            DropColumn("dbo.OrderAlbums", "UserId");
            DropColumn("dbo.OrderTracks", "UserId");
            CreateIndex("dbo.OrderAlbums", "CartId");
            CreateIndex("dbo.OrderTracks", "CartId");
            AddForeignKey("dbo.OrderTracks", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderAlbums", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
