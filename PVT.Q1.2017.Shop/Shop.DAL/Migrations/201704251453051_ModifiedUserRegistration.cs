namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedUserRegistration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 15));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Users", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
