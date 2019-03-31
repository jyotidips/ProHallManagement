namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationForErrorHandlingInAlbum2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.PostImages", "AlbumId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostImages", "AlbumId");
            DropColumn("dbo.UserImages", "AlbumId");
        }
    }
}
