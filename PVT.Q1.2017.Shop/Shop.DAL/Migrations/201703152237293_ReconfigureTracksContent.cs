namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReconfigureTracksContent : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbUsers", newName: "tbUsersData");
            DropForeignKey("dbo.tbTracks", "ArtistId", "dbo.tbArtists");
            DropForeignKey("dbo.tbTracks", "GenreId", "dbo.tbGenres");
            DropIndex("dbo.tbAlbums", new[] { "ArtistId" });
            DropIndex("dbo.tbTracks", new[] { "ArtistId" });
            DropIndex("dbo.tbTracks", new[] { "GenreId" });
            AlterColumn("dbo.tbAlbums", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbTracks", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbTracks", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.tbCurrencyRates", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.tbAlbums", "ArtistId");
            CreateIndex("dbo.tbTracks", "ArtistId");
            CreateIndex("dbo.tbTracks", "GenreId");
            AddForeignKey("dbo.tbTracks", "ArtistId", "dbo.tbArtists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tbTracks", "GenreId", "dbo.tbGenres", "Id", cascadeDelete: true);
            DropColumn("dbo.tbUsersData", "IdentityKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbUsersData", "IdentityKey", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.tbTracks", "GenreId", "dbo.tbGenres");
            DropForeignKey("dbo.tbTracks", "ArtistId", "dbo.tbArtists");
            DropIndex("dbo.tbTracks", new[] { "GenreId" });
            DropIndex("dbo.tbTracks", new[] { "ArtistId" });
            DropIndex("dbo.tbAlbums", new[] { "ArtistId" });
            AlterColumn("dbo.tbCurrencyRates", "Date", c => c.DateTime());
            AlterColumn("dbo.tbTracks", "GenreId", c => c.Int());
            AlterColumn("dbo.tbTracks", "ArtistId", c => c.Int());
            AlterColumn("dbo.tbAlbums", "ArtistId", c => c.Int());
            CreateIndex("dbo.tbTracks", "GenreId");
            CreateIndex("dbo.tbTracks", "ArtistId");
            CreateIndex("dbo.tbAlbums", "ArtistId");
            AddForeignKey("dbo.tbTracks", "GenreId", "dbo.tbGenres", "Id");
            AddForeignKey("dbo.tbTracks", "ArtistId", "dbo.tbArtists", "Id");
            RenameTable(name: "dbo.tbUsersData", newName: "tbUsers");
        }
    }
}
