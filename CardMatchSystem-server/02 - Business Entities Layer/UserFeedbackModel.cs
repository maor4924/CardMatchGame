using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class UserFeedbackModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime fbDateTime { get; set; }
        public string fbText { get; set; }
    }
}
