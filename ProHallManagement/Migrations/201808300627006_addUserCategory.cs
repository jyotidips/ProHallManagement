namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserCategory : DbMigration
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
            
            AddColumn("dbo.Users", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserCategory_Id", c => c.Int());
            CreateIndex("dbo.Users", "UserCategory_Id");
            AddForeignKey("dbo.Users", "UserCategory_Id", "dbo.UserCategories", "Id");
            DropColumn("dbo.Users", "IsStudent");
            DropColumn("dbo.Users", "IsTeacher");
            DropColumn("dbo.Users", "IsEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsEmployee", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsTeacher", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsStudent", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Users", "UserCategory_Id", "dbo.UserCategories");
            DropIndex("dbo.Users", new[] { "UserCategory_Id" });
            DropColumn("dbo.Users", "UserCategory_Id");
            DropColumn("dbo.Users", "CategoryId");
            DropTable("dbo.UserCategories");
        }
    }
}
