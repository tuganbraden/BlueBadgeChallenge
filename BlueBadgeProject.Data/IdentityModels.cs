using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BlueBadgeProject.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public enum LifeStyleType
    {
       sedentary = 1, moderate, vigorous
    }
    public enum BodyType
    {
        ectomorph, mesomorph, endomorph
    }
    public enum SubscriberStatus
    {
        Free, Premium, GoldTier
    }
    public class AppUserClaim : IdentityUserClaim<string> { }
    public class AppUserLogin : IdentityUserLogin<string> { }
    public class AppRole: IdentityRole<string, ApplicationUserRole> {
    public AppRole()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public class ApplicationUserRole : IdentityUserRole<string>

    {

        [Required]
       
        public virtual User User { get; set; }
        [Required]
        public virtual AppRole Role { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<User, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection"
                  )
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
       // public DbSet<User> Users { get; set; }
        public DbSet<Diets> Diets { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Friends> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new AppUserLoginConfiguration())
                .Add(new ApplicationUserRoleConfiguration());
        }
    }
    public class AppUserLoginConfiguration : EntityTypeConfiguration<AppUserLogin>
    {
        public AppUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleConfiguration()
        {
            HasKey(iur => new {iur.UserId, iur.RoleId });
           
        }
    }
}