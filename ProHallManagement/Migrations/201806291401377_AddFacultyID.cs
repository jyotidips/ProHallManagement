namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFacultyID : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Students", "FacultyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "FacultyId" });
            AlterColumn("dbo.Students", "FacultyId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "FacultyId", newName: "Faculty_Id");
            CreateIndex("dbo.Students", "Faculty_Id");
            AddForeignKey("dbo.Students", "Faculty_Id", "dbo.Faculties", "Id");
        }
    }
}
