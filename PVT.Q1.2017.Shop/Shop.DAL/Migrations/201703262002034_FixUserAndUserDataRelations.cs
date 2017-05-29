namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserAndUserDataRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersData", "Id", "dbo.Users");
            DropIndex("dbo.UsersData", new[] { "Id" });
            CreateIndex("dbo.UsersData", "UserId");
            AddForeignKey("dbo.UsersData", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersData", "UserId", "dbo.Users");
            DropIndex("dbo.UsersData", new[] { "UserId" });
            CreateIndex("dbo.UsersData", "Id");
            AddForeignKey("dbo.UsersData", "Id", "dbo.Users", "Id");
        }
    }
}
