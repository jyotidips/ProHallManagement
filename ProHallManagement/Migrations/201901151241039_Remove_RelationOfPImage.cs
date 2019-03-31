namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Remove_RelationOfPImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums");
            DropForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.PImages", "UserId", "dbo.Users");
            DropIndex("dbo.PImages", new[] { "UserId" });
            DropIndex("dbo.PImages", new[] { "UAlbum_Id" });
            DropIndex("dbo.PImages", new[] { "UPost_Id" });
            //            DropColumn("dbo.PImages", "UAlbum_Id");
            //            DropColumn("dbo.PImages", "UPost_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.PImages", "UPost_Id", c => c.Int());
            AddColumn("dbo.PImages", "UAlbum_Id", c => c.Int());
            CreateIndex("dbo.PImages", "UPost_Id");
            CreateIndex("dbo.PImages", "UAlbum_Id");
            CreateIndex("dbo.PImages", "UserId");
            AddForeignKey("dbo.PImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts", "Id");
            AddForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums", "Id");
        }
    }
}
