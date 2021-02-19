using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlueBadgeProject.Data;

namespace BlueBadgeProject.Models
{
    public class WorkoutPlanEdit
    {
        [Required]
        public int WorkoutPlanId { get; set; }
        public string PlanName { get; set; }
        public double Intensity { get; set; }
        public WorkoutType ProgramType { get; set; }
    }
}
