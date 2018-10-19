namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addTableCommentImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Comments",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId)

                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);

            CreateTable(
                "dbo.PostImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    ImageUrl = c.String(),
                    PostId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);

            CreateTable(
                "dbo.UserImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    ImageUrl = c.String(),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);


            AddColumn("dbo.Posts", "PostImageId", c => c.Int());
            CreateIndex("dbo.Posts", "PostImageId");
            AddForeignKey("dbo.Posts", "PostImageId", "dbo.PostImages", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_Id1", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostImageId_Id", "dbo.PostImages");
            DropForeignKey("dbo.Posts", "PostImage_Id", "dbo.PostImages");
            DropForeignKey("dbo.PostImages", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.UserImages", new[] { "UserId" });
            DropIndex("dbo.PostImages", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "PostImageId_Id" });
            DropIndex("dbo.Posts", new[] { "PostImage_Id" });
            DropIndex("dbo.Comments", new[] { "PostId_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id1" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Posts", "PostImageId_Id");
            DropColumn("dbo.Posts", "PostImage_Id");
            DropTable("dbo.UserImages");
            DropTable("dbo.PostImages");
            DropTable("dbo.Comments");
        }
    }
}
