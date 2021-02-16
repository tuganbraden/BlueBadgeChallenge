using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlueBadgeProject.Data
{
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
        [ForeignKey(nameof(Diets))]
        public int DietId { get; set; }
        public virtual Diets Diets { get; set; }

    }
}