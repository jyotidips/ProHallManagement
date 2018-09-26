namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    Phone = c.Int(nullable: false),
                    WorkId = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("Employees");
        }
    }
}
