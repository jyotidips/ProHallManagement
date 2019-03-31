namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAttributeTypeinPOSTFullyFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostImageId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostImageId");
        }
    }
}
