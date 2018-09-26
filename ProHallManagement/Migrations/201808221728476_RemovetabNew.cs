namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovetabNew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "Student_StudentId" });
            DropColumn("dbo.Students", "PostId");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Student_StudentId");
            AddForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students", "StudentId");
        }
    }
}
