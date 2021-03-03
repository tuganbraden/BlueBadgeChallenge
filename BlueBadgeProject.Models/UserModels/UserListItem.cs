using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class UserListItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public SubscriberStatus SubscriberStatus { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
