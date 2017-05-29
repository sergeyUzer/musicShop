namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRole", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "ConfirmedEmail", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "UserRoles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserRoles", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "ConfirmedEmail");
            DropColumn("dbo.Users", "UserRole");
        }
    }
}
