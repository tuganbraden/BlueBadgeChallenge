namespace BlueBadgeProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merge : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Diets", newName: "DietCreate");
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        MyUserId = c.String(nullable: false, maxLength: 128),
                        FriendUserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MyUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Friends");
            RenameTable(name: "dbo.DietCreate", newName: "Diets");
        }
    }
}
