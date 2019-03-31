namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createUpdatedAT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UPosts", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.UPosts", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UPosts", "UpdatedAt");
            DropColumn("dbo.UPosts", "CreatedAt");
        }
    }
}
