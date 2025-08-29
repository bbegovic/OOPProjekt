using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataLayer.Models.descriptions;


namespace WorldCup.DataLayer.Models.descriptions
{
    public class TeamStatistics
    {
        public string? Country { get; set; }
        public int Attempts_on_goal { get; set; }
        public int On_target { get; set; }
        public int Off_target { get; set; }
        public int Blocked { get; set; }
        public int Woodwork { get; set; }
        public int Corners { get; set; }
        public int Offsides { get; set; }
        public int Ball_possession { get; set; }
        public int Pass_accuracy { get; set; }
        public int Num_passes { get; set; }
        public int Passes_completed { get; set; }
        public int Distance_covered { get; set; }
        public int Balls_recovered { get; set; }
        public int Tackles { get; set; }
        public int Clearances { get; set; }
        public int Yellow_cards { get; set; }
        public int Red_cards { get; set; }
        public int Fouls_committed { get; set; }
        public string? Tactics { get; set; }
        public List<Player>? Starting_eleven { get; set; }
        public List<Player> ?Substitutes { get; set; }
    }
}
