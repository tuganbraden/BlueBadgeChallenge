using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    public enum WorkoutType 
    {
        Cardio, Strength, Flexibility
    }
    public class WorkoutPlan
    {
        [Key]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public WorkoutType ProgramType { get; set; }
        [ForeignKey(nameof(User))]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }
        public double intensity { get; set; }
    }
}
