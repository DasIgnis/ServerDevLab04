using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public List<long> SubscriptionIds { get; set; }
        public List<long> SubscriberIds { get; set; }
    }
}
