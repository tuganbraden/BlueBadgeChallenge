﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlueBadgeProject.Models
{
    public class WorkoutPlanCreate
    {
        [Required]
        public string PlanName { get; set; }
        [Range(0, 10)]
        public double Intensity { get; set; }
        public WorkoutType ProgramType { get; set; }

    }
}