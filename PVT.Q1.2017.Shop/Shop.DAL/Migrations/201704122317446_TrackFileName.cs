namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrackFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "FileName");
        }
    }
}
