namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class tableUserPostUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "StudentId" });
            DropColumn("dbo.Posts", "StudentId");

            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Student_StudentId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "Student_StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "UserId");
            RenameColumn(table: "dbo.Posts", name: "Student_StudentId", newName: "StudentId");
            CreateIndex("dbo.Posts", "StudentId");
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}
