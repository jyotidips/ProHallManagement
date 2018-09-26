namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionID : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Students", "SessionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Students", new[] { "SessionId" });
            AlterColumn("dbo.Students", "SessionId", c => c.Int());
            AlterColumn("dbo.Students", "SessionId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Students", name: "SessionId", newName: "Session_Id");
            AddColumn("dbo.Students", "SessionId", c => c.String(nullable: false));
            CreateIndex("dbo.Students", "Session_Id");
            AddForeignKey("dbo.Students", "Session_Id", "dbo.Sessions", "Id");
        }
    }
}
