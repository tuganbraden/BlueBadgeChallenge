using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class DietDetail
    {

        public int DietId { get; set; }
        public string Name { get; set; }

        public bool IsVegetarian { get; set; } = false;

        public bool IsKeto { get; set; } = false;

        public bool IsLactoseFree { get; set; } = false;

        public bool IsGlutenFree { get; set; } = false;

        public string Description { get; set; }

        public double CaloriesPerDay { get; set; }
    }
}
