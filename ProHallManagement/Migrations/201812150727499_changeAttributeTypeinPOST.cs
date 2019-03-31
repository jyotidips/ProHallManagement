namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class changeAttributeTypeinPOST : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostImages", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostImage_Id", "dbo.PostImages");
            DropForeignKey("dbo.Posts", "PostImageId_Id", "dbo.PostImages");
            DropIndex("dbo.Posts", new[] { "PostImage_Id" });
            DropIndex("dbo.Posts", new[] { "PostImageId_Id" });
            DropIndex("dbo.PostImages", new[] { "PostId" });
            //DropColumn("dbo.Posts", "PostImageId");
            //DropColumn("dbo.Posts", "PostImageId_Id");
            DropColumn("dbo.PostImages", "PostId");
        }

        public override void Down()
        {
            AddColumn("dbo.PostImages", "PostId", c => c.Int(nullable: false));
            //AddColumn("dbo.Posts", "PostImageId", c => c.Int());
            //AddColumn("dbo.Posts", "PostImage_Id", c => c.Int());
            CreateIndex("dbo.PostImages", "PostId");
            CreateIndex("dbo.Posts", "PostImageId_Id");
            CreateIndex("dbo.Posts", "PostImage_Id");
            AddForeignKey("dbo.Posts", "PostImageId_Id", "dbo.PostImages", "Id");
            AddForeignKey("dbo.Posts", "PostImage_Id", "dbo.PostImages", "Id");
            AddForeignKey("dbo.PostImages", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
