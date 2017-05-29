namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAlbumAndArtistRelations : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int());
            CreateIndex("dbo.Albums", "ArtistId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "ArtistId");
        }
    }
}
