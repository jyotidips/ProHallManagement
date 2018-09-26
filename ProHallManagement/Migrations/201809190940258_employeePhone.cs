namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeePhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Phone");
        }
    }
}
