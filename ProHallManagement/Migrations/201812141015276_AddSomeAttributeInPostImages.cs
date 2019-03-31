namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddSomeAttributeInPostImages : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums");
            //AddColumn("dbo.UserImages", "Album_Id", c => c.Int());
            //AddColumn("dbo.UserImages", "Album_Id1", c => c.Int());
            AddColumn("dbo.PostImages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.PostImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.PostImages", "IsProfilePic", c => c.Boolean(nullable: true));
            AddColumn("dbo.PostImages", "IsCoverPic", c => c.Boolean(nullable: true));
            //CreateIndex("dbo.UserImages", "Album_Id");
            //CreateIndex("dbo.UserImages", "Album_Id1");
            CreateIndex("dbo.PostImages", "UserId");
            CreateIndex("dbo.PostImages", "AlbumId");
            AddForeignKey("dbo.PostImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.UserImages", "Album_Id", "dbo.Albums", "Id");
            //AddForeignKey("dbo.UserImages", "Album_Id1", "dbo.Albums", "Id");
        }

        public override void Down()
        {
            //DropForeignKey("dbo.UserImages", "Album_Id1", "dbo.Albums");
            //DropForeignKey("dbo.UserImages", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.PostImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.PostImages", "AlbumId", "dbo.Albums");
            DropIndex("dbo.PostImages", new[] { "AlbumId" });
            DropIndex("dbo.PostImages", new[] { "UserId" });
            //DropIndex("dbo.UserImages", new[] { "Album_Id1" });
            //DropIndex("dbo.UserImages", new[] { "Album_Id" });
            DropColumn("dbo.PostImages", "IsCoverPic");
            DropColumn("dbo.PostImages", "IsProfilePic");
            DropColumn("dbo.PostImages", "AlbumId");
            DropColumn("dbo.PostImages", "UserId");
            //DropColumn("dbo.UserImages", "Album_Id1");
            //DropColumn("dbo.UserImages", "Album_Id");
            AddForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
    }
}
