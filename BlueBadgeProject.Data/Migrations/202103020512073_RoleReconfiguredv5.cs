namespace BlueBadgeProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleReconfiguredv5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AppRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        GoalWeight = c.Double(nullable: false),
                        GoalDate = c.DateTime(nullable: false),
                        SubscriberStatus = c.Int(nullable: false),
                        WeeklyCaloricNeed = c.Double(nullable: false),
                        BodyType = c.Int(nullable: false),
                        LifeStyleType = c.Int(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        IsKeto = c.Boolean(nullable: false),
                        IsLactoseFree = c.Boolean(nullable: false),
                        IsGlutenFree = c.Boolean(nullable: false),
                        DietId = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .Index(t => t.DietId);
            
            CreateTable(
                "dbo.AppUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        IsKeto = c.Boolean(nullable: false),
                        IsLactoseFree = c.Boolean(nullable: false),
                        IsGlutenFree = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        CaloriesPerDay = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DietId);
            
            CreateTable(
                "dbo.AppUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WorkoutPlan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 128),
                        PlanName = c.String(nullable: false),
                        Intensity = c.Double(nullable: false),
                        ProgramType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutPlan", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.ApplicationUserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.AppUserLogin", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "DietId", "dbo.Diets");
            DropForeignKey("dbo.AppUserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserRole", "RoleId", "dbo.AppRole");
            DropIndex("dbo.WorkoutPlan", new[] { "CreatedBy" });
            DropIndex("dbo.AppUserLogin", new[] { "User_Id" });
            DropIndex("dbo.AppUserClaim", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "DietId" });
            DropIndex("dbo.ApplicationUserRole", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUserRole", new[] { "UserId" });
            DropTable("dbo.WorkoutPlan");
            DropTable("dbo.AppUserLogin");
            DropTable("dbo.Diets");
            DropTable("dbo.AppUserClaim");
            DropTable("dbo.User");
            DropTable("dbo.AppRole");
            DropTable("dbo.ApplicationUserRole");
        }
    }
}
