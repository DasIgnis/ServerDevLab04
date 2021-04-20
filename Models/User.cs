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
        public List<User> Subscriptions { get; set; }
        public List<User> Subscribers { get; set; }
        public List<Record> Records { get; set; }

        public User()
        {
            Subscribers = new List<User>();
            Subscriptions = new List<User>();
            Records = new List<Record>();
        }
    }
}
