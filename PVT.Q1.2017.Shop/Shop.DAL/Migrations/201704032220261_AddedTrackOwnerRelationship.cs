namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrackOwnerRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "OwnerId", c => c.Int());
            CreateIndex("dbo.Tracks", "OwnerId");
            AddForeignKey("dbo.Tracks", "OwnerId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "OwnerId", "dbo.Users");
            DropIndex("dbo.Tracks", new[] { "OwnerId" });
            DropColumn("dbo.Tracks", "OwnerId");
        }
    }
}
