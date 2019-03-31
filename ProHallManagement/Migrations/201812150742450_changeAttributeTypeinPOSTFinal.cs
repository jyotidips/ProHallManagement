namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAttributeTypeinPOSTFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostImages", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostImages", "PostId");
            AddForeignKey("dbo.PostImages", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostImages", "PostId", "dbo.Posts");
            DropIndex("dbo.PostImages", new[] { "PostId" });
            DropColumn("dbo.PostImages", "PostId");
        }
    }
}
