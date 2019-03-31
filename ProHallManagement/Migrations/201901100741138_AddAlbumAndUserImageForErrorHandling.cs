namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAlbumAndUserImageForErrorHandling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageAlbums",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    UserId = c.Int(nullable: true),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    ImageUrl = c.String(),
                    UserId = c.Int(nullable: true),
                    AlbumId = c.Int(nullable: true),
                    IsProfilePic = c.Boolean(nullable: true),
                    IsCoverPic = c.Boolean(nullable: true),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UImages", "UserId", "dbo.Users");
            DropIndex("dbo.UImages", new[] { "UserId" });
            DropTable("dbo.UImages");
            DropTable("dbo.ImageAlbums");
        }
    }
}
