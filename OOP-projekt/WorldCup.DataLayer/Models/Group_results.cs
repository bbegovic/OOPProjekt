using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Models
{
    internal class Group_results
    {
        public int teamID {  get; set; }
        public string? teamLetter { get; set; }
        public List<Results>? ordered_team {  get; set; }
    }
}
