namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addforeignKey4 : DbMigration
    {
        public override void Up()
        {
            //            DropColumn("dbo.UComments", "PostId");
            //            DropColumn("dbo.PImages", "PostId");
            //            DropColumn("dbo.PImages", "AlbumId");
            //            DropColumn("dbo.UImages", "AlbumId");
            //            RenameColumn(table: "dbo.UComments", name: "UPost_Id", newName: "PostId");
            //            RenameColumn(table: "dbo.PImages", name: "UPost_Id", newName: "PostId");
            //            RenameColumn(table: "dbo.PImages", name: "UAlbum_Id", newName: "AlbumId");
            //            RenameColumn(table: "dbo.UImages", name: "UAlbum_Id", newName: "AlbumId");
            //            AlterColumn("dbo.UComments", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.PImages", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.PImages", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.UImages", "AlbumId", c => c.Int(nullable: false));
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
        }
    }
}
