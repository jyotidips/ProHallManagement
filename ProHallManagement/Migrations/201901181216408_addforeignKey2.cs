namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addforeignKey2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.PImages", "UserId", "dbo.Users", "Id");
        }

        public override void Down()
        {
        }
    }
}
