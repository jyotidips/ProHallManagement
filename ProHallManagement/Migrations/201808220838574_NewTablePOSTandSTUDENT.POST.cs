namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTablePOSTandSTUDENTPOST : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentPosts", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentPosts", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.StudentPosts", "PostId");
            AddForeignKey("dbo.StudentPosts", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentPosts", "Name");
            DropColumn("dbo.StudentPosts", "Details");
            DropColumn("dbo.StudentPosts", "Supports");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentPosts", "Supports", c => c.Int(nullable: false));
            AddColumn("dbo.StudentPosts", "Details", c => c.String());
            AddColumn("dbo.StudentPosts", "Name", c => c.String());
            DropForeignKey("dbo.StudentPosts", "PostId", "dbo.Posts");
            DropIndex("dbo.StudentPosts", new[] { "PostId" });
            DropColumn("dbo.StudentPosts", "Date");
            DropColumn("dbo.StudentPosts", "PostId");
            DropTable("dbo.Posts");
        }
    }
}
