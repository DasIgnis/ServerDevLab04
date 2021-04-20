using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class RecordEditModel
    {
        public long UserId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        public RecordEditModel()
        {
            Text = "";
            Image = "";
        }
    }
}
