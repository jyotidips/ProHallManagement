namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToTeacher : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "DateEnd", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
