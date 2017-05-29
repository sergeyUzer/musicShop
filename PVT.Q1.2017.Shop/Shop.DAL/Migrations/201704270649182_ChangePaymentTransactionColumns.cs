namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePaymentTransactionColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentTransactions", "Totals", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.PaymentTransactions", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentTransactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.PaymentTransactions", "Totals");
        }
    }
}
