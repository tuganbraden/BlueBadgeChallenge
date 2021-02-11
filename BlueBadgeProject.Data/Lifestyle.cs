using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Data
{
    class Lifestyle
    {
        [Key]
        public int LifestyleId { get; set; }
        public double WeeklyCalorieIntake { get; set; }
        public string LifestyleType { get; set; }

    }
}
