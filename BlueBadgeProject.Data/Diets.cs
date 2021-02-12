using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    public class Diets
    {
        [Key]
        public int DietID { get; set; }
        public string Name { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsKeto { get; set; }
        public bool IsLactoseFree { get; set; }
        public bool IsGlutenFree { get; set; }
        public string Description { get; set; }
        public double CaloriesPerDay { get; set; }
    }
}
