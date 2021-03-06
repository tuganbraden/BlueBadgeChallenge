namespace BlueBadgeProject.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using BlueBadgeProject.Data;

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
            var diets = new DietCreate();

            diets.DietId = 1;
            diets.Name = "Mediterranean";
            diets.IsVegetarian = false;
            diets.IsKeto = false;
            diets.IsLactoseFree = true;
            diets.IsGlutenFree = false;
            diets.Description = "A diet traditionally followed in Greece, Crete, southern France, and parts of Italy that emphasizes fruits and vegetables, nuts, grains, olive oil (as opposed to butter)"+
                                "and grilled or steamed chicken and seafood (as opposed to red meat). Plus a glass or two of red wine. High consumption of fruits, vegetables, bread and other cereals, beans, nuts and seeds;"+
                                "Olive oil is the key monounsaturated fat source; Dairy products, fish and poultry are consumed in low to moderate amounts; Little red meat is eaten; Eggs are eaten zero to four times a week;"+
                                "and Wine is drunk in moderate(or low) amounts. Many studies indicate that a Mediterranean diet may play an important role in the prevention of coronary artery heart disease.A Mediterranean-style diet"+
                                "also appears to help avoid the metabolic syndrome(prediabetes)";
            diets.CaloriesPerDay = 1500;


            diets.DietId = 2;
            diets.Name = "Keto";
            diets.IsVegetarian = false;
            diets.IsKeto = true;
            diets.IsLactoseFree = false;
            diets.IsGlutenFree = false;
            diets.Description = "The ketogenic diet is a very low carb, high fat diet that shares many similarities with the Atkins and low carb diets." +
                                "It involves drastically reducing carbohydrate intake and replacing it with fat.This reduction in carbs puts your body into a metabolic state called ketosis." +
                                "When this happens, your body becomes incredibly efficient at burning fat for energy.It also turns fat into ketones in the liver, which can supply energy for the brain." +
                                "Ketogenic diets can cause significant reductions in blood sugar and insulin levels.This, along with the increased ketones, has some health benefits.";
            diets.CaloriesPerDay = 1500;


            diets.DietId = 3;
            diets.Name = "DASH";
            diets.IsVegetarian = false;
            diets.IsKeto = false;
            diets.IsLactoseFree = false;
            diets.IsGlutenFree = false;
            diets.Description = "Dietary Approaches to Stop Hypertension (DASH) is an eating plan to lower or control high blood pressure. The DASH diet emphasizes foods that are lower in sodium"+
                                "as well as foods that are rich in potassium, magnesium and calcium — nutrients that help lower blood pressure.The DASH diet features menus with plenty of vegetables,+"+
                                "fruits and low - fat dairy products, as well as whole grains, fish, poultry and nuts.It offers limited portions of red meats, sweets and sugary beverages.";
            diets.CaloriesPerDay = 2000;



            diets.DietId = 4;
            diets.Name = "Paleo";
            diets.IsVegetarian = false;
            diets.IsKeto = false;
            diets.IsLactoseFree = true;
            diets.IsGlutenFree = true;
            diets.Description = "The Paleo diet, also referred to as the caveman or Stone-Age diet, includes lean meats, fish, fruits, vegetables, nuts, and seeds."+
                                "Proponents of the diet emphasize choosing low-glycemic fruits and vegetables. The following is a summary of foods generally permitted"+
                                "on the diet: Allowed: Fresh lean meats, fish, shellfish, eggs, nuts, seeds, fruits, vegetables, olive oil, coconut oil, and small amounts of honey."+
                                "Certain root vegetables like sweet potatoes and cassava may be allowed in moderation because of their high nutrient content."+
                                "Not Allowed: Whole grains, cereals, refined grains and sugars, dairy products, white potatoes, legumes(peanuts, beans, lentils)," +
                                "alcohol, coffee, salt, refined vegetable oils such as canola, and most processed foods in general. Calorie counting and portion sizes" +
                                "are not emphasized.Some plans allow a few “cheat” non - Paleo meals a week, especially when first starting the diet, to improve overall compliance.";
            diets.CaloriesPerDay = 2000;


            var friends = new Friends();

            friends.MyUserId = //pass in user ID
            friends.FriendUserId = "test";//need to tie these to Connors UserIds
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
