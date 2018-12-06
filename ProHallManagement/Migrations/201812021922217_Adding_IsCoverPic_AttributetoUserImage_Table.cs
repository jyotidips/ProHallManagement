namespace ProHallManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Adding_IsCoverPic_AttributetoUserImage_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserImages", "IsCoverPic", c => c.Boolean(nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.UserImages", "IsCoverPic");
        }
    }
}
