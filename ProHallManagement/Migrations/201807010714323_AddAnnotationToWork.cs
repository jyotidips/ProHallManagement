namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToWork : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Works", "Name", c => c.String());
        }
    }
}
