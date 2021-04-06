using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models.ViewModels
{
    public class UserDashboardViewModel
    {
        public User User { get; set; }
        public List<Record> Records { get; set; }
    }
}
