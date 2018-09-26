namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "StudentPostId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "StuddentPostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StuddentPostId");
            DropColumn("dbo.Posts", "StudentPostId");
        }
    }
}
