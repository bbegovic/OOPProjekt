using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorldCup.DataLayer.data;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Models.descriptions;

namespace WorldCup.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly JsonFileService _jsonService;
        private List<Team> _allTeams = new List<Team>();
        private List<Match> _allMatches = new List<Match>();
        private List<TeamStatistics> _allResults = new List<TeamStatistics>();

        public MainWindow()
        {
            InitializeComponent();
            _jsonService = new JsonFileService(@"../../../data");
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
            PopulateTeams();
        }

        private async Task LoadDataAsync()
        {
            string tournament = "WorldCupMen";

            _allTeams = await _jsonService.LoadJsonAsync<List<Team>>(tournament, "teams.json") ?? new List<Team>();
            _allMatches = await _jsonService.LoadJsonAsync<List<Match>>(tournament, "matches.json") ?? new List<Match>();

           
            _allResults = _allMatches
                .SelectMany(m => new[] { m.Home_team_statistics, m.Away_team_statistics })
                .Where(r => r != null)
                .Cast<TeamStatistics>()
                .ToList();
        }

        private void PopulateTeams()
        {
            cmbHomeTeam.ItemsSource = _allTeams;
            cmbAwayTeam.ItemsSource = _allTeams;
            cmbHomeTeam.DisplayMemberPath = "Country";
            cmbAwayTeam.DisplayMemberPath = "Country";
        }

        private void CmbHomeTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateResult();
        }

        private void CmbAwayTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateResult();
        }

        private void UpdateResult()
        {
            if (cmbHomeTeam.SelectedItem is Team home && cmbAwayTeam.SelectedItem is Team away)
            {
                var match = _allMatches.FirstOrDefault(m =>
                    (m.HomeTeam_country == home.Country && m.AwayTeam_country == away.Country) ||
                    (m.HomeTeam_country == away.Country && m.AwayTeam_country == home.Country));

                if (match != null)
                {
                    txtResult.Text = $"{match.HomeTeam?.Goals ?? 0} : {match.AwayTeam?.Goals ?? 0}";
                }
                else
                {
                    txtResult.Text = "Nema rezultata.";
                }
            }
        }

        private void BtnHomeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbHomeTeam.SelectedItem is Team selectedTeam)
            {
                var selectedTeamResults = _allResults.FirstOrDefault(r => r.Country == selectedTeam.Country);
                var win = new TeamInfoWindow(selectedTeam, selectedTeamResults);
                win.Owner = this;
                win.ShowDialog();
            }
        }

        private void BtnAwayInfo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAwayTeam.SelectedItem is Team selectedTeam)
            {
                var selectedTeamResults = _allResults.FirstOrDefault(r => r.Country == selectedTeam.Country);
                var win = new TeamInfoWindow(selectedTeam, selectedTeamResults);
                win.Owner = this;
                win.ShowDialog();
            }
        }
    }
}
