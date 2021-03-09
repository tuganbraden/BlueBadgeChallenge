using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class UserCreate
    {

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Height (in)")]
        public double Height { get; set; }
        [Display(Name = "Current Weight (lbs)")]
        public double Weight { get; set; }
        [Display(Name = "Goal Weight (lbs)")]
        public double GoalWeight { get; set; }
        public SubscriberStatus SubscriberStatus { get; set; }
        [Display(Name = "Weekly Caloric Needs (kCal)")]
        public double WeeklyCaloricNeed { get; set; }
        public BodyType BodyType { get; set; }
       
        public LifeStyleType LifeStyleType { get; set; }
        
        public bool IsVegetarian { get; set; } = false;
        
        public bool IsKeto { get; set; } = false;
        
        public bool IsLactoseFree { get; set; } = false;
        public bool IsGlutenFree { get; set; } = false;
        public DateTime GoalDate { get; set; }
        public int? DietId { get; set; }
    }
}
