namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addforeignKey1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PImages", "UAlbum_Id", c => c.Int());
            AddColumn("dbo.PImages", "UPost_Id", c => c.Int());
            CreateIndex("dbo.PImages", "UserId");
            CreateIndex("dbo.PImages", "UAlbum_Id");
            CreateIndex("dbo.PImages", "UPost_Id");
            AddForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums", "Id");
            AddForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts", "Id");
            //            AddForeignKey("dbo.PImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums");
            DropIndex("dbo.PImages", new[] { "UPost_Id" });
            DropIndex("dbo.PImages", new[] { "UAlbum_Id" });
            DropIndex("dbo.PImages", new[] { "UserId" });
            DropColumn("dbo.PImages", "UPost_Id");
            DropColumn("dbo.PImages", "UAlbum_Id");
        }
    }
}
