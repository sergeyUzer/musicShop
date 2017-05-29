namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountriesUpdateUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "CountryId", c => c.Int());
            CreateIndex("dbo.Users", "CountryId");
            AddForeignKey("dbo.Users", "CountryId", "dbo.Countries", "Id");
            DropColumn("dbo.Users", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 15));
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropColumn("dbo.Users", "CountryId");
            DropTable("dbo.Countries");
        }
    }
}
