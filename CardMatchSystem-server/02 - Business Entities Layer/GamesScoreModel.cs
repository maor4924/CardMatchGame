using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class GamesScoreModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime ?gameDateTime { get; set; }
        public decimal gameDuration { get; set; }
        public int moves { get; set; }
    }
}
