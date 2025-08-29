using System.CodeDom.Compiler;
using System.Windows;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Models.descriptions;

namespace WorldCup.WpfApp
{
    public partial class TeamInfoWindow : Window
    {
        public TeamInfoWindow(Team team, TeamStatistics? teamStats)
        {
            InitializeComponent();
            LoadTeamInfo(team, teamStats);
        }
        private void LoadTeamInfo(Team team, TeamStatistics? stats)
        {
            txtTeamName.Text = team.Country;
            txtFifaCode.Text = $"FIFA Code: {team.FifaCode}";

            if (stats != null)
            {
                
                int matchesPlayed = (stats.Starting_eleven?.Count ?? 0) + (stats.Substitutes?.Count ?? 0);
                txtMatches.Text = $"Odigrane utakmice: {matchesPlayed}";

               
                txtWins.Text = $"Pobjede (On target): {stats.On_target}";
                txtDraws.Text = $"Neriješeno (Off target): {stats.Off_target}";
                txtLosses.Text = $"Porazi (Blocked): {stats.Blocked}";

               
                txtGoalsFor.Text = $"Golovi postignuti (Attempts on goal): {stats.Attempts_on_goal}";
                txtGoalsAgainst.Text = $"Golovi primljeni (Corners protiv): {stats.Corners}";

               
                int goalDiff = stats.Attempts_on_goal - stats.Corners; 
                txtGoalDifference.Text = $"Gol razlika: {goalDiff}";

               
                txtOtherStats.Text = $"Žuti kartoni: {stats.Yellow_cards}, Crveni kartoni: {stats.Red_cards}";
            }
            else
            {
                txtMatches.Text = "Podaci nedostupni";
                txtWins.Text = "";
                txtDraws.Text = "";
                txtLosses.Text = "";
                txtGoalsFor.Text = "";
                txtGoalsAgainst.Text = "";
                txtGoalDifference.Text = "";
                txtOtherStats.Text = "";
            }
        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
