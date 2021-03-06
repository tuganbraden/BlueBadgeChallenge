namespace BlueBadgeProject.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlueBadgeProject.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlueBadgeProject.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole,string,ApplicationUserRole>(context));
            var UserManager = new UserManager(new UserStore<User, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new AppRole();
                role.Name = "Admin";
                try
                {
                    roleManager.Create(role);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                
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
    public class UserManager : Microsoft.AspNet.Identity.UserManager<User, string>
    {
        public UserManager(IUserStore<User, string> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore<User, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
