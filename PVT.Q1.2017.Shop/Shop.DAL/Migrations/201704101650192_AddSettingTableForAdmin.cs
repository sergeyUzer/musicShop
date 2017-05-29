namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettingTableForAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DefaultCurrencyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.DefaultCurrencyId)
                .Index(t => t.DefaultCurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "DefaultCurrencyId", "dbo.Currencies");
            DropIndex("dbo.Settings", new[] { "DefaultCurrencyId" });
            DropTable("dbo.Settings");
        }
    }
}
