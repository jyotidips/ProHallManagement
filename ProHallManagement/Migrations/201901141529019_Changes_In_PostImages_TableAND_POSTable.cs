namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes_In_PostImages_TableAND_POSTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "PostImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PostImageId", c => c.Int(nullable: false));
        }
    }
}
