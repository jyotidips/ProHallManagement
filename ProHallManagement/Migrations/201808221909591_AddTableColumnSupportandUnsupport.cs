namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableColumnSupportandUnsupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Support", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Unsupport", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Unsupport");
            DropColumn("dbo.Posts", "Support");
        }
    }
}
