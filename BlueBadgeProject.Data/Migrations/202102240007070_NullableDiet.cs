namespace BlueBadgeProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDiet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "DietId", "dbo.Diets");
            DropIndex("dbo.User", new[] { "DietId" });
            AlterColumn("dbo.User", "DietId", c => c.Int());
            CreateIndex("dbo.User", "DietId");
            AddForeignKey("dbo.User", "DietId", "dbo.Diets", "DietId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "DietId", "dbo.Diets");
            DropIndex("dbo.User", new[] { "DietId" });
            AlterColumn("dbo.User", "DietId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "DietId");
            AddForeignKey("dbo.User", "DietId", "dbo.Diets", "DietId", cascadeDelete: true);
        }
    }
}
