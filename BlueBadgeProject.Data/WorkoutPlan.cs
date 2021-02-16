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
        [ForeignKey(nameof(Client))]
        public int CreatedBy { get; set; }
        public virtual Client Client { get; set; }
        [Required]
        public string PlanName { get; set; }
        [Required]
        [Range(0, 10)]
        public double Intensity { get; set; }
        [Required]
        public WorkoutType ProgramType { get; set; }
    }
}
