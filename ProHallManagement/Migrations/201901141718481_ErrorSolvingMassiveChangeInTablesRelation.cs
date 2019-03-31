namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ErrorSolvingMassiveChangeInTablesRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UImages", "UserId", "dbo.Users");
            DropIndex("dbo.UImages", new[] { "UserId" });
            CreateTable(
                    "dbo.UAlbums",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            .Index(t => t.UserId);

            CreateTable(
                "dbo.UComments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Body = c.String(),
                    UserId = c.Int(nullable: false),
                    PostId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UPosts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);

            CreateTable(
                    "dbo.UPosts",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        Support = c.Int(nullable: false),
                        Unsupport = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            //                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
            //                .Index(t => t.UserId);

            CreateTable(
                "dbo.PImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    ImageUrl = c.String(nullable: false),
                    UserId = c.Int(nullable: false),
                    PostId = c.Int(nullable: false),
                    AlbumId = c.Int(nullable: false),
                    IsProfilePic = c.Boolean(nullable: false),
                    IsCoverPic = c.Boolean(nullable: false),
                    //                    UAlbum_Id = c.Int(),
                    //                    UPost_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UAlbums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.UPosts", t => t.PostId, cascadeDelete: true)
                //                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                //                .Index(t => t.UserId)
                .Index(t => t.AlbumId)
                .Index(t => t.PostId);

            AddColumn("dbo.Notifications", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "FacultyId", c => c.Int(nullable: false));
            //            AddColumn("dbo.UImages", "AlbumId", c => c.Int(nullable: false));//changed
            CreateIndex("dbo.Teachers", "FacultyId");
            CreateIndex("dbo.Notifications", "UserId");
            //            CreateIndex("dbo.UImages", "AlbumId");
            AddForeignKey("dbo.Teachers", "FacultyId", "dbo.Faculties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            //            AddForeignKey("dbo.UImages", "AlbumId", "dbo.UAlbums", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "PostId");
            DropColumn("dbo.UImages", "UserId");
            DropTable("dbo.ImageAlbums");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ImageAlbums",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.UImages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.PImages", "UserId", "dbo.Users");
            DropForeignKey("dbo.PImages", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.PImages", "UAlbum_Id", "dbo.UAlbums");
            DropForeignKey("dbo.UComments", "UPost_Id", "dbo.UPosts");
            DropForeignKey("dbo.UAlbums", "UserId", "dbo.Users");
            DropForeignKey("dbo.UImages", "UAlbum_Id", "dbo.UAlbums");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.Teachers", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.PImages", new[] { "UPost_Id" });
            DropIndex("dbo.PImages", new[] { "UAlbum_Id" });
            DropIndex("dbo.PImages", new[] { "UserId" });
            DropIndex("dbo.UPosts", new[] { "UserId" });
            DropIndex("dbo.UComments", new[] { "UPost_Id" });
            DropIndex("dbo.UComments", new[] { "UserId" });
            DropIndex("dbo.UImages", new[] { "UAlbum_Id" });
            DropIndex("dbo.UAlbums", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.Teachers", new[] { "FacultyId" });
            DropColumn("dbo.UImages", "UAlbum_Id");
            DropColumn("dbo.Teachers", "FacultyId");
            DropColumn("dbo.Notifications", "UserId");
            DropTable("dbo.PImages");
            DropTable("dbo.UPosts");
            DropTable("dbo.UComments");
            DropTable("dbo.UAlbums");
            CreateIndex("dbo.UImages", "UserId");
            AddForeignKey("dbo.UImages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
