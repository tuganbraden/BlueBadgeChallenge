namespace BlueBadgeProject.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlueBadgeProject.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlueBadgeProject.Data.ApplicationDbContext";
        }

        protected override void Seed(BlueBadgeProject.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                var user = new User();
                user.UserName = "connor";
                user.FullName = "Connor Braeger";
                user.Email = "cjbraeger@gmail.com";
                string userPWD = "ElevenFiftyAcademy169?";
                user.CreatedUtc = DateTimeOffset.Now;
                user.Height = 73;//inches
                user.Weight = 215;
                user.GoalWeight = 190;
                user.GoalDate = new DateTime(2021, 6, 1);
                user.SubscriberStatus = SubscriberStatus.Premium;
                user.WeeklyCaloricNeed = 2500 * 7;
                user.BodyType = BodyType.endomorph;
                user.LifeStyleType = LifeStyleType.moderate;
                user.IsVegetarian = false;
                user.IsGlutenFree = false;
                user.IsKeto = false;
                user.IsLactoseFree = false;
                UserManager.Create(user, userPWD);
                UserManager.AddToRole(user.Id, "Admin");
            }
            
           
            


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
