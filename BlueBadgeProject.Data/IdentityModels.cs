using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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
    public class Client : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Client> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here

            return userIdentity;
        }
        public string ClientId { get { return this.Id; } set { this.ClientId = this.Id; } }// primary key is inherited 
        [Required]

        public string FullName { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]

        public double Height { get; set; }
        
        [Required]
        public double Weight { get; set; }
        [Required]
        public double GoalWeight { get; set; }
        [Required]
        public DateTime GoalDate { get; set; }
        [Required]
        public SubscriberStatus SubscriberStatus { get; set; } = 0;
        [Required]
        public double WeeklyCaloricNeed { get; set; }
        public BodyType BodyType { get; set; }
        [Required]
        public LifeStyleType LifeStyleType { get; set; }
        [Required]
        public bool IsVegetarian { get; set; } = false;
        [Required]
        public bool IsKeto { get; set; } = false;
        [Required]
        public bool IsLactoseFree{ get; set; } = false;
        [Required]
        public bool IsGlutenFree { get; set; } = false;


    }

    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<WorkoutPlan> WorkoutPlan { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}