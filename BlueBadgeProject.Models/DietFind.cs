using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class DietFind
    {       
        public int DietId { get; set; }
         public string Name { get; set; }
        [Required]
         public bool IsVegetarian { get; set; }
        [Required]
         public bool IsKeto { get; set; }
        [Required]
         public bool IsLactoseFree { get; set; }
        [Required]
         public bool IsGlutenFree { get; set; }
       
         public string Description { get; set; }
       
         public double CaloriesPerDay { get; set; }
        
    }
}
