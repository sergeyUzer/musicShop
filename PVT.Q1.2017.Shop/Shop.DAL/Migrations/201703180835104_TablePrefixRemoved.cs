namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablePrefixRemoved : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbAlbumPrices", newName: "AlbumPrices");
            RenameTable(name: "dbo.tbAlbums", newName: "Albums");
            RenameTable(name: "dbo.tbArtists", newName: "Artists");
            RenameTable(name: "dbo.tbTracks", newName: "Tracks");
            RenameTable(name: "dbo.tbAlbumTrackRelations", newName: "AlbumTrackRelations");
            RenameTable(name: "dbo.tbFeedbacks", newName: "Feedbacks");
            RenameTable(name: "dbo.tbUsersData", newName: "UsersData");
            RenameTable(name: "dbo.tbPriceLevels", newName: "PriceLevels");
            RenameTable(name: "dbo.tbTrackPrices", newName: "TrackPrices");
            RenameTable(name: "dbo.tbCurrencies", newName: "Currencies");
            RenameTable(name: "dbo.tbCurrencyRates", newName: "CurrencyRates");
            RenameTable(name: "dbo.tbVotes", newName: "Votes");
            RenameTable(name: "dbo.tbGenres", newName: "Genres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Genres", newName: "tbGenres");
            RenameTable(name: "dbo.Votes", newName: "tbVotes");
            RenameTable(name: "dbo.CurrencyRates", newName: "tbCurrencyRates");
            RenameTable(name: "dbo.Currencies", newName: "tbCurrencies");
            RenameTable(name: "dbo.TrackPrices", newName: "tbTrackPrices");
            RenameTable(name: "dbo.PriceLevels", newName: "tbPriceLevels");
            RenameTable(name: "dbo.UsersData", newName: "tbUsersData");
            RenameTable(name: "dbo.Feedbacks", newName: "tbFeedbacks");
            RenameTable(name: "dbo.AlbumTrackRelations", newName: "tbAlbumTrackRelations");
            RenameTable(name: "dbo.Tracks", newName: "tbTracks");
            RenameTable(name: "dbo.Artists", newName: "tbArtists");
            RenameTable(name: "dbo.Albums", newName: "tbAlbums");
            RenameTable(name: "dbo.AlbumPrices", newName: "tbAlbumPrices");
        }
    }
}
