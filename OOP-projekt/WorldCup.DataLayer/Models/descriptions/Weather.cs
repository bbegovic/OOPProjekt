using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Models.descriptions
{
    public class Weather
    {
        public string Humidity { get; set; } = string.Empty;
        public string TempCels { get; set; } = string.Empty;
        public string TempFarenheit { get; set; } = string.Empty;
        public string WindSpeed { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
