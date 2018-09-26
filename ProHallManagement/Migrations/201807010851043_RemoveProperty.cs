namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Name");
            DropColumn("dbo.Employees", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
    }
}
