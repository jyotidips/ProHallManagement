namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class migrationForErrorHandlingInDatabaseFromAlbumReADD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Albums",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            //.ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);
            //.Index(t => t.UserId);

            CreateTable(
                    "dbo.UserImages",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        UserId = c.Int(nullable: true),
                        AlbumId = c.Int(nullable: true),
                        IsProfilePic = c.Boolean(nullable: true),
                        IsCoverPic = c.Boolean(nullable: true)

                        //Album_Id = c.Int(),
                        //Album_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            //.ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
            //.ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);

            //.ForeignKey("dbo.Albums", t => t.Album_Id)
            //.ForeignKey("dbo.Albums", t => t.Album_Id1)
            //.Index(t => t.UserId)
            //.Index(t => t.AlbumId);
            //.Index(t => t.Album_Id)
            //.Index(t => t.Album_Id1);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "Album_Id1", "dbo.Albums");
            DropForeignKey("dbo.UserImages", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.UserImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Albums", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums");
            DropIndex("dbo.UserImages", new[] { "Album_Id1" });
            DropIndex("dbo.UserImages", new[] { "Album_Id" });
            DropIndex("dbo.UserImages", new[] { "AlbumId" });
            DropIndex("dbo.UserImages", new[] { "UserId" });
            DropIndex("dbo.Albums", new[] { "UserId" });
            DropTable("dbo.UserImages");
            DropTable("dbo.Albums");
        }
    }
}
