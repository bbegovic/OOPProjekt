using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataLayer.Models.descriptions;

namespace WorldCup.DataLayer.Models
{
    public class Match
    {
        public string Fifa_Id { get; set; } = string.Empty;
        public string Venue {  get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Time {  get; set; } = string.Empty;
        public Weather? Weather { get; set; }
        public int Attendance {  get; set; }
        public List<string>? officials { get; set; }
        public string stage_name { get; set; } = string.Empty;
        public string HomeTeam_country { get; set; }=string.Empty;
        public string AwayTeam_country { get; set; } = string.Empty;
        public DateTime DateTime {  get; set; } = DateTime.Now;
        public string? Winner { get; set; }
        public string? Winner_code { get; set; }
        public matchTeam? HomeTeam { get; set; }
        public matchTeam? AwayTeam { get; set; }
        public List<Event>?Home_team_events { get; set; }
        public List<Event> ?Away_team_events { get; set; }
        public TeamStatistics? Home_team_statistics { get; set; }
        public TeamStatistics? Away_team_statistics { get; set; }
        public DateTime Last_event_update_at { get; set; }
        public DateTime Last_score_update_at { get; set; }

    }
}
