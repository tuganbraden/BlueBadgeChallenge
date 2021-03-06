using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    public class DietCreate
    {
        [Key]
        public int DietId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsVegetarian { get; set; } = false;
        [Required]
        public bool IsKeto { get; set; } = false;
        [Required]
        public bool IsLactoseFree { get; set; } = false;
        [Required]
        public bool IsGlutenFree { get; set; } = false;
        [Required]
        public string Description { get; set; }
        [Required]
        public double CaloriesPerDay { get; set; }

        public DietCreate(int dietId, string name, bool isVegetarian, bool isKeto, bool isLactoseFree, bool isGlutenFree, string description, double caloriesPerDey)
        {
            DietId = dietId;
            Name = name;
            IsVegetarian = isVegetarian;
            IsKeto = isKeto;
            IsLactoseFree = isLactoseFree;
            IsGlutenFree = isGlutenFree;
            Description = description;
            CaloriesPerDay = caloriesPerDey;
        }
        public DietCreate()
        {

        }
    }

}
