namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAlbumAndUserImageForErrorHandling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserImages", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.UserImages", "Album_Id1", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "UserId" });
            DropIndex("dbo.UserImages", new[] { "UserId" });
            DropIndex("dbo.UserImages", new[] { "AlbumId" });
            DropIndex("dbo.UserImages", new[] { "Album_Id" });
            DropIndex("dbo.UserImages", new[] { "Album_Id1" });
            DropTable("dbo.Albums");
            DropTable("dbo.UserImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        UserId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        IsProfilePic = c.Boolean(nullable: false),
                        IsCoverPic = c.Boolean(nullable: false),
                        Album_Id = c.Int(),
                        Album_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserImages", "Album_Id1");
            CreateIndex("dbo.UserImages", "Album_Id");
            CreateIndex("dbo.UserImages", "AlbumId");
            CreateIndex("dbo.UserImages", "UserId");
            CreateIndex("dbo.Albums", "UserId");
            AddForeignKey("dbo.UserImages", "Album_Id1", "dbo.Albums", "Id");
            AddForeignKey("dbo.UserImages", "Album_Id", "dbo.Albums", "Id");
            AddForeignKey("dbo.UserImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Albums", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
    }
}
