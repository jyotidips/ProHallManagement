namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class changeAttributeTypeinPOSTAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "PostImageId", "dbo.PostImages");
            DropIndex("dbo.Posts", new[] { "PostImageId" });
            DropColumn("dbo.Posts", "PostImageId");
        }

        public override void Down()
        {
            AddForeignKey("dbo.Posts", "PostImage_Id", "dbo.PostImages");
            CreateIndex("dbo.Posts", new[] { "PostImage_Id" });
            AddColumn("dbo.Posts", "PostImageId", c => c.Int(nullable: false));
        }
    }
}
