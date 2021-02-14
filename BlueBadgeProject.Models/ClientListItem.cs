using BlueBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeProject.Models
{
    public class ClientListItem
    {
        public string ClientId { get; set; }
        public string FullName { get; set; }
        public SubscriberStatus SubscriberStatus { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
