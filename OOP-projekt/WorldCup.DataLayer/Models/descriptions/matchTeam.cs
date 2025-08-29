using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Models.descriptions
{
    public class matchTeam
    {
        public string? Country {  get; set; }
        public string? Code{  get; set; }
        public int Goals  { get; set; }
        public int Penalties { get; set; }

    }
}
