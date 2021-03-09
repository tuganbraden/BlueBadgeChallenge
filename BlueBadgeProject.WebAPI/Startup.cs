using System;
using System.Collections.Generic;
using System.Linq;
using BlueBadgeProject.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("ApiConfig",typeof(BlueBadgeProject.WebAPI.Startup))]

namespace BlueBadgeProject.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //seedTest();
            
        }
        public void seedTest()
        {
            using(var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole, string, ApplicationUserRole>(context));
                var UserManager = new BlueBadgeProject.Data.Migrations.UserManager(new UserStore<User, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>(context));
                if (!roleManager.RoleExists("Admin1"))
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
                    try
                    {
                        UserManager.Create(user, userPWD);
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
                    
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
