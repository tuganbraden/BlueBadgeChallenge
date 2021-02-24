namespace BlueBadgeProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserId", c => c.String());
        }
    }
}
