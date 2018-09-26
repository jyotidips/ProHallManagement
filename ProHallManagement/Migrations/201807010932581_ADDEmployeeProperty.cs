namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDEmployeeProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "WorkID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "WorkID");
            AddForeignKey("dbo.Employees", "WorkID", "dbo.Works", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "WorkID", "dbo.Works");
            DropIndex("dbo.Employees", new[] { "WorkID" });
            DropColumn("dbo.Employees", "WorkID");
        }
    }
}
