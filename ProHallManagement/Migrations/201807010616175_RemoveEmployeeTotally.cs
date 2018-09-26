namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmployeeTotally : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "WorkId", "dbo.Works");
            DropIndex("dbo.Employees", new[] { "WorkId" });
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Employees", "WorkId");
            AddForeignKey("dbo.Employees", "WorkId", "dbo.Works", "Id", cascadeDelete: true);
        }
    }
}
