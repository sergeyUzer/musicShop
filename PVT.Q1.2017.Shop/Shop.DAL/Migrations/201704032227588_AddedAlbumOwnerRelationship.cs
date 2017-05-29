namespace Shop.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumOwnerRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "OwnerId", c => c.Int());
            CreateIndex("dbo.Albums", "OwnerId");
            AddForeignKey("dbo.Albums", "OwnerId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "OwnerId", "dbo.Users");
            DropIndex("dbo.Albums", new[] { "OwnerId" });
            DropColumn("dbo.Albums", "OwnerId");
        }
    }
}
