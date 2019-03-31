namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddColumnAlbumId_Index_Fkey : DbMigration
    {
        public override void Up()
        {
            //            AddColumn("dbo.UImages", "AlbumId", c => c.Int(nullable: false));
            //            AddForeignKey("dbo.Teachers", "FacultyId", "dbo.Faculties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UImages", "AlbumId", "dbo.UAlbums", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
