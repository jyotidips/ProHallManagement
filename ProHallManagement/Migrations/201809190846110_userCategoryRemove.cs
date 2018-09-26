namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userCategoryRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserCategory_Id", "dbo.UserCategories");
            DropIndex("dbo.Users", new[] { "UserCategory_Id" });
            DropColumn("dbo.Users", "CategoryId");
            DropColumn("dbo.Users", "UserCategory_Id");
            DropTable("dbo.UserCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserCategory_Id", c => c.Int());
            AddColumn("dbo.Users", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserCategory_Id");
            AddForeignKey("dbo.Users", "UserCategory_Id", "dbo.UserCategories", "Id");
        }
    }
}
