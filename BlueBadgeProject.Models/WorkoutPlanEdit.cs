using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlueBadgeProject.Models
{
    public class WorkoutPlanEdit
    {
        [Required]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public double Intensity { get; set; }
        public WorkoutType ProgramType { get; set; }
    }
}
