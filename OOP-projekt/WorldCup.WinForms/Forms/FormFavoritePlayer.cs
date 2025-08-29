using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.data;
using DataAccessLayer.Filesystem;
using System.Numerics;
using WorldCup.DataLayer.Models.descriptions;



namespace WorldCup.WinForms.Forms
{

    public partial class FormFavoritePlayers : Form
    {
        private readonly JsonFileService _jsonService;
        private readonly string _tournament;
        private readonly Team _team;
        private List<Player> _allPlayers = new List<Player>();

        public FormFavoritePlayers(string tournament, Team team)
        {
            InitializeComponent();
            _tournament = tournament;
            _team = team;
            _jsonService = new JsonFileService(@"../../../data");
        }

        private async void FormFavoritePlayers_Load(object sender, EventArgs e)
        {
            await LoadPlayersAsync();
            DisplayPlayers();
        }

        private async Task LoadPlayersAsync()
        {
         
            var matches = await _jsonService.LoadJsonAsync<List<Match>>(
                _tournament,
                @"C:\Users\barba\source\repos\OOP-projekt\WorldCup.DataLayer\data\Women\matches.json"
            );

            if (matches == null) return;

            var playersSet = new HashSet<string>();
            foreach (var match in matches)
            {
                foreach (var player in (match.Home_team_statistics.Starting_eleven ?? Enumerable.Empty<Player>())
                         .Concat(match.Home_team_statistics.Substitutes ?? Enumerable.Empty<Player>()))
                {
                    if (playersSet.Add(player.Name))
                        _allPlayers.Add(player);
                }

                foreach (var player in (match.Away_team_statistics.Starting_eleven ?? Enumerable.Empty<Player>())
                                        .Concat(match.Away_team_statistics.Substitutes ?? Enumerable.Empty<Player>()))
                {
                    if (playersSet.Add(player.Name))
                        _allPlayers.Add(player);
                }

            }

        }

        private void DisplayPlayers()
        {
            clbPlayers.Items.Clear();
            foreach (var player in _allPlayers)
                clbPlayers.Items.Add($"{player.Name} ({player.Position})", false);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var selectedPlayers = clbPlayers.CheckedItems.Cast<string>().ToList();
            if (selectedPlayers.Count > 3)
            {
                MessageBox.Show("Možete odabrati najviše 3 omiljena igrača.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repo = new FileRepository();
            repo.SaveFavoritePlayers(selectedPlayers);

            MessageBox.Show("Omiljeni igrači spremljeni!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }

}