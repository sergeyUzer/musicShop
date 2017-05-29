namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "Description");
        }
    }
}
