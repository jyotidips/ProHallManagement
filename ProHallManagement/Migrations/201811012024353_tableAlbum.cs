namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class tableAlbum : DbMigration
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);

            AddColumn("dbo.UserImages", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.UserImages", "IsProfilePic", c => c.Boolean(nullable: false));
            CreateIndex("dbo.UserImages", "AlbumId");
            AddForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Albums", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserImages", "AlbumId", "dbo.Albums");
            DropIndex("dbo.UserImages", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "UserId" });
            DropColumn("dbo.UserImages", "IsProfilePic");
            DropColumn("dbo.UserImages", "AlbumId");
            DropTable("dbo.Albums");
        }
    }
}
