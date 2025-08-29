using DataAccessLayer.Filesystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.WinForms.Forms;

namespace WorldCup.WinForms.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; 
        }
        private void Form1_Load(object? sender, EventArgs e)
        {
            var repo = new FileRepository();

            if (!repo.SettingsExists())
            {
                using var settingsForm = new SettingsForm();
                if (settingsForm.ShowDialog() == DialogResult.OK)
                    repo.SaveSettings(settingsForm.SelectedTournament, settingsForm.SelectedLanguage);
                else
                    Application.Exit();
            }

            var tournament = repo.GetTeamGender(); 
            var favTeamForm = new FormFavoriteTeam(tournament);
            favTeamForm.Show();
            this.Hide();
        }
    }

}