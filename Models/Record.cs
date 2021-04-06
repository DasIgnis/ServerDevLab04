using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class Record
    {
        public long Id { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string DateTimeString { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
    }
}
