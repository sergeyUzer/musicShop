namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndUserDataRelations : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Albums", "Cart_Id", c => c.Int());
            AddColumn("dbo.Tracks", "Cart_Id", c => c.Int());
            AddColumn("dbo.UsersData", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "Cart_Id");
            CreateIndex("dbo.Tracks", "Cart_Id");
            CreateIndex("dbo.UsersData", "Id");
            AddForeignKey("dbo.UsersData", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Albums", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Tracks", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Albums", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.UsersData", "Id", "dbo.Users");
            DropIndex("dbo.UsersData", new[] { "Id" });
            DropIndex("dbo.Tracks", new[] { "Cart_Id" });
            DropIndex("dbo.Albums", new[] { "Cart_Id" });
            DropColumn("dbo.UsersData", "UserId");
            DropColumn("dbo.Tracks", "Cart_Id");
            DropColumn("dbo.Albums", "Cart_Id");
            DropTable("dbo.Carts");
        }
    }
}
