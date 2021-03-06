using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class DietDetail
    {
        [Key]
        public int DietId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsVegetarian { get; set; }
        [Required]
        public bool IsKeto { get; set; }
        [Required]
        public bool IsLactoseFree { get; set; }
        [Required]
        public bool IsGlutenFree { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double CaloriesPerDay { get; set; }
    }
}
