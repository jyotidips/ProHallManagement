namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationForErrorHandlingInAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PostImages", "AlbumId", "dbo.Albums");
            DropIndex("dbo.UserImages", new[] { "AlbumId" });
            DropIndex("dbo.PostImages", new[] { "AlbumId" });
            DropColumn("dbo.UserImages", "AlbumId");
            DropColumn("dbo.PostImages", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.UserImages", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostImages", "AlbumId");
            CreateIndex("dbo.UserImages", "AlbumId");
            AddForeignKey("dbo.PostImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
    }
}
