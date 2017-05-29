namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasedAlbums", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchasedAlbums", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PurchasedTracks", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchasedTracks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PaymentTransactions", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.PurchasedAlbums", "CurrencyId");
            CreateIndex("dbo.PurchasedTracks", "CurrencyId");
            AddForeignKey("dbo.PurchasedAlbums", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchasedTracks", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedTracks", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.PurchasedAlbums", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.PurchasedTracks", new[] { "CurrencyId" });
            DropIndex("dbo.PurchasedAlbums", new[] { "CurrencyId" });
            DropColumn("dbo.PaymentTransactions", "Date");
            DropColumn("dbo.PurchasedTracks", "Price");
            DropColumn("dbo.PurchasedTracks", "CurrencyId");
            DropColumn("dbo.PurchasedAlbums", "Price");
            DropColumn("dbo.PurchasedAlbums", "CurrencyId");
        }
    }
}
