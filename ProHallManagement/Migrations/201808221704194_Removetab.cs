namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removetab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentPosts", "PostId", "dbo.Posts");
            DropForeignKey("dbo.StudentPosts", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentPosts", new[] { "StudentId" });
            DropIndex("dbo.StudentPosts", new[] { "PostId" });
            AddColumn("dbo.Posts", "Student_StudentId", c => c.Int());
            AddColumn("dbo.Students", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Student_StudentId");
            AddForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students", "StudentId");
            DropColumn("dbo.Posts", "StudentPostId");
            DropColumn("dbo.Students", "StuddentPostId");
            DropTable("dbo.StudentPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "StuddentPostId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "StudentPostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "Student_StudentId" });
            DropColumn("dbo.Students", "PostId");
            DropColumn("dbo.Posts", "Student_StudentId");
            CreateIndex("dbo.StudentPosts", "PostId");
            CreateIndex("dbo.StudentPosts", "StudentId");
            AddForeignKey("dbo.StudentPosts", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.StudentPosts", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
