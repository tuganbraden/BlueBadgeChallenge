﻿using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class ClientCreate
    {
        
        [Required]
        public string FullName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double GoalWeight { get; set; }
        public SubscriberStatus SubscriberStatus { get; set; }
        public double WeeklyCaloricNeed { get; set; }
        public BodyType BodyType { get; set; }
       
        public LifeStyleType LifeStyleType { get; set; }
        
        public bool IsVegetarian { get; set; } = false;
        
        public bool IsKeto { get; set; } = false;
        
        public bool IsLactoseFree { get; set; } = false;
        public bool IsGlutenFree { get; set; } = false;
        public DateTime GoalDate { get; set; }
        public int DietId { get; set; }
    }
}
