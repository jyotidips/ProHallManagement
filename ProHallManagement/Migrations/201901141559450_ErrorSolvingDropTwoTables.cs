namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorSolvingDropTwoTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.PostImages", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.PostImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_Id1", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostId_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id1" });
            DropIndex("dbo.Comments", new[] { "PostId_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "Student_StudentId" });
            DropIndex("dbo.PostImages", new[] { "UserId" });
            DropIndex("dbo.PostImages", new[] { "PostId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.PostImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        IsProfilePic = c.Boolean(nullable: false),
                        IsCoverPic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        Support = c.Int(nullable: false),
                        Unsupport = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        UserId = c.Int(nullable: false),
                        Post_Id = c.Int(),
                        Post_Id1 = c.Int(),
                        PostId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PostImages", "PostId");
            CreateIndex("dbo.PostImages", "UserId");
            CreateIndex("dbo.Posts", "Student_StudentId");
            CreateIndex("dbo.Posts", "UserId");
            CreateIndex("dbo.Comments", "PostId_Id");
            CreateIndex("dbo.Comments", "Post_Id1");
            CreateIndex("dbo.Comments", "Post_Id");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Comments", "PostId_Id", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Post_Id1", "dbo.Posts", "Id");
            AddForeignKey("dbo.PostImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostImages", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
