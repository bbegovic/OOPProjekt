using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Models
{
    public class Results
    {
        
        public Team? Team { get; set; }
        public int Wins {  get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Games_played { get; set; }
        public int Points { get; set; }
        public int Goals_for { get; set; }
        public int Goals_against { get; set; }
        public int Goal_differential { get; set; }

    }
}
