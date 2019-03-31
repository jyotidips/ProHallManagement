namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequired_In_PostImages_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostImages", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.PostImages", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostImages", "ImageUrl", c => c.String());
            AlterColumn("dbo.PostImages", "Title", c => c.String());
        }
    }
}
