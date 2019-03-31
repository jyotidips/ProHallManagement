namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addforeignKey5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PImages", "UAlbum_Id");
            DropColumn("dbo.PImages", "UPost_Id");
        }

        public override void Down()
        {
        }
    }
}
