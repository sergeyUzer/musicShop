namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrackSample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "TrackSample", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "TrackSample");
        }
    }
}
