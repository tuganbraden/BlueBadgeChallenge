using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class DietModels
    {
       public class DietCreate
       {
            public string Name { get; set; }
            public bool IsVegetarian { get; set; }
            public bool IsKeto { get; set; }
            public bool IsLactoseFree { get; set; }
            public bool IsGlutenFree { get; set; }
            public string Description { get; set;}
            public double CaloriesPerDay { get; set; }
       }
        public class Client
        {
            public int ClientId { get; set; }
        }
        public class ClientNeeds
        {
            public bool IsVegetarian { get; set; }
            public bool IsKeto { get; set; }
            public bool IsLactoseFree { get; set; }
            public bool IsGlutenFree { get; set; }
        }
        public class Diet
        {
            public int DietId { get; set; }
            public string Name { get; set; }
            public bool IsVegetarian { get; set; }
            public bool IsKeto { get; set; }
            public bool IsLactoseFree { get; set; }
            public bool IsGlutenFree { get; set; }
            public string Description { get; set; }
            public double CaloriesPerDay { get; set; }
        }
        public class DietName
        {
            public int DietId { get; set; }
            public string Name { get; set; }
        }
        public class DietList
        {
            public virtual List<DietName> DietsList { get; set; }
        }
        public class DietDelete
        {
            public int DietId { get; set; }
        }
    }
}
