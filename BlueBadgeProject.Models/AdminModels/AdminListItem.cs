using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class AdminListItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
