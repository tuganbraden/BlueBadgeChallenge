using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    public class WorkoutPlan
    {
        [Key]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string ProgramType { get; set; }
        //[ForeignKey nameof(Client)]
        //public int CreatedBy { get; set; }
        //public virtual Client Client { get; set; }
        public double intensity { get; set; }
    }
}
