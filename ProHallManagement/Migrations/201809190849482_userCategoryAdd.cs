namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userCategoryAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserCategoryId");
            AddForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories");
            DropIndex("dbo.Users", new[] { "UserCategoryId" });
            DropColumn("dbo.Users", "UserCategoryId");
            DropTable("dbo.UserCategories");
        }
    }
}
