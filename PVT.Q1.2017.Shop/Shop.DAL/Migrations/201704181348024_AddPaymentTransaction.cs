namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.UsersData", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CurrencyId);
            
            AddColumn("dbo.PurchasedAlbums", "PaymentTransaction_Id", c => c.Int());
            AddColumn("dbo.PurchasedTracks", "PaymentTransaction_Id", c => c.Int());
            CreateIndex("dbo.PurchasedAlbums", "PaymentTransaction_Id");
            CreateIndex("dbo.PurchasedTracks", "PaymentTransaction_Id");
            AddForeignKey("dbo.PurchasedAlbums", "PaymentTransaction_Id", "dbo.PaymentTransactions", "Id");
            AddForeignKey("dbo.PurchasedTracks", "PaymentTransaction_Id", "dbo.PaymentTransactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentTransactions", "UserId", "dbo.UsersData");
            DropForeignKey("dbo.PurchasedTracks", "PaymentTransaction_Id", "dbo.PaymentTransactions");
            DropForeignKey("dbo.PurchasedAlbums", "PaymentTransaction_Id", "dbo.PaymentTransactions");
            DropForeignKey("dbo.PaymentTransactions", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.PaymentTransactions", new[] { "CurrencyId" });
            DropIndex("dbo.PaymentTransactions", new[] { "UserId" });
            DropIndex("dbo.PurchasedTracks", new[] { "PaymentTransaction_Id" });
            DropIndex("dbo.PurchasedAlbums", new[] { "PaymentTransaction_Id" });
            DropColumn("dbo.PurchasedTracks", "PaymentTransaction_Id");
            DropColumn("dbo.PurchasedAlbums", "PaymentTransaction_Id");
            DropTable("dbo.PaymentTransactions");
        }
    }
}
