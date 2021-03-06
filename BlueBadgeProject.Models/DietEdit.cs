﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class DietEdit
    {
        [Required]
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
    }
}
