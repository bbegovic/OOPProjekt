using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataLayer.Models.descriptions;


namespace WorldCup.DataLayer.Models.descriptions
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public bool Captain { get; set; }
        public int Shirt_number { get; set; }
        public string Position { get; set; } =string.Empty;
    }
}
