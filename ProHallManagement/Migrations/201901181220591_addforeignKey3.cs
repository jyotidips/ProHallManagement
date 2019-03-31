namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addforeignKey3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UComments", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums");
            DropForeignKey("dbo.UImages", "UAlbum_Id", "dbo.UAlbums");
            DropIndex("dbo.UComments", new[] { "UPost_Id" });
            DropIndex("dbo.PImages", new[] { "UAlbum_Id" });
            DropIndex("dbo.PImages", new[] { "UPost_Id" });
            DropIndex("dbo.UImages", new[] { "UAlbum_Id" });
            //            DropColumn("dbo.UComments", "PostId");
            //            DropColumn("dbo.PImages", "PostId");
            //            DropColumn("dbo.PImages", "AlbumId");
            //            DropColumn("dbo.UImages", "AlbumId");
            //            RenameColumn(table: "dbo.UComments", name: "UPost_Id", newName: "PostId");
            //            RenameColumn(table: "dbo.PImages", name: "UPost_Id", newName: "PostId");
            //            RenameColumn(table: "dbo.PImages", name: "UAlbum_Id", newName: "AlbumId");
            //            RenameColumn(table: "dbo.UImages", name: "UAlbum_Id", newName: "AlbumId");
            //            AlterColumn("dbo.UComments", "PostId", c => c.Int(nullable: false));
            //            AlterColumn("dbo.PImages", "AlbumId", c => c.Int(nullable: false));
            //            AlterColumn("dbo.PImages", "PostId", c => c.Int(nullable: false));
            //            AlterColumn("dbo.UImages", "AlbumId", c => c.Int(nullable: false));
            //            CreateIndex("dbo.UComments", "PostId");
            //            CreateIndex("dbo.PImages", "PostId");
            //            CreateIndex("dbo.PImages", "AlbumId");
            //            CreateIndex("dbo.UImages", "AlbumId");
            //            AddForeignKey("dbo.UComments", "PostId", "dbo.UPosts", "Id", cascadeDelete: true);
            //            AddForeignKey("dbo.PImages", "PostId", "dbo.UPosts", "Id", cascadeDelete: true);
            //            AddForeignKey("dbo.PImages", "AlbumId", "dbo.UAlbums", "Id", cascadeDelete: true);
            //            AddForeignKey("dbo.UImages", "AlbumId", "dbo.UAlbums", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.UImages", "AlbumId", "dbo.UAlbums");
            DropForeignKey("dbo.PImages", "AlbumId", "dbo.UAlbums");
            DropForeignKey("dbo.PImages", "PostId", "dbo.UPosts");
            DropForeignKey("dbo.UComments", "PostId", "dbo.UPosts");
            DropIndex("dbo.UImages", new[] { "AlbumId" });
            DropIndex("dbo.PImages", new[] { "AlbumId" });
            DropIndex("dbo.PImages", new[] { "PostId" });
            DropIndex("dbo.UComments", new[] { "PostId" });
            AlterColumn("dbo.UImages", "AlbumId", c => c.Int());
            AlterColumn("dbo.PImages", "PostId", c => c.Int());
            AlterColumn("dbo.PImages", "AlbumId", c => c.Int());
            AlterColumn("dbo.UComments", "PostId", c => c.Int());
            RenameColumn(table: "dbo.UImages", name: "AlbumId", newName: "UAlbum_Id");
            RenameColumn(table: "dbo.PImages", name: "AlbumId", newName: "UAlbum_Id");
            RenameColumn(table: "dbo.PImages", name: "PostId", newName: "UPost_Id");
            RenameColumn(table: "dbo.UComments", name: "PostId", newName: "UPost_Id");
            AddColumn("dbo.UImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.PImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.PImages", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.UComments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.UImages", "UAlbum_Id");
            CreateIndex("dbo.PImages", "UPost_Id");
            CreateIndex("dbo.PImages", "UAlbum_Id");
            CreateIndex("dbo.UComments", "UPost_Id");
            AddForeignKey("dbo.UImages", "UAlbum_Id", "dbo.UAlbums", "Id");
            AddForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums", "Id");
            AddForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts", "Id");
            AddForeignKey("dbo.UComments", "UPost_Id", "dbo.UPosts", "Id");
        }
    }
}
