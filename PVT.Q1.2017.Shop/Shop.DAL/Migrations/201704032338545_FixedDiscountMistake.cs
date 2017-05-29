namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDiscountMistake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersData", "Discount", c => c.Double());
            DropColumn("dbo.UsersData", "Dicount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersData", "Dicount", c => c.Double());
            DropColumn("dbo.UsersData", "Discount");
        }
    }
}
