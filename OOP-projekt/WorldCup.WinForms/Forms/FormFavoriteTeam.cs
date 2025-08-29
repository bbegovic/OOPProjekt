using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.data;

namespace WorldCup.WinForms.Forms
{
    public partial class FormFavoriteTeam : Form
    {
        private readonly JsonFileService _jsonService;
        private readonly string _tournament;

        public Team? SelectedTeam { get; private set; }

        public FormFavoriteTeam(string tournament)
        {
            InitializeComponent();
            _tournament = tournament;
            _jsonService = new JsonFileService(@"../../../data");
        }

        private async void FormFavoriteTeam_Load(object sender, EventArgs e)
        {
            var teams = await _jsonService.LoadJsonAsync<List<Team>>(_tournament, "teams.json");
            comboTeams.DataSource = teams;
            comboTeams.DisplayMember = "Country"; 
            comboTeams.ValueMember = "FifaCode";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SelectedTeam = comboTeams.SelectedItem as Team;
            if (SelectedTeam == null) return;

            var favPlayersForm = new FormFavoritePlayers(_tournament, SelectedTeam);
            favPlayersForm.Show();
            this.Hide();
        }
    }

}