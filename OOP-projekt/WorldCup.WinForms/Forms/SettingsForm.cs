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

namespace WorldCup.WinForms.Forms
{ 
    
        public partial class SettingsForm : Form
        {
            public string SelectedTournament { get; private set; } = "men";
            public string SelectedLanguage { get; private set; } = "EN";

            public SettingsForm()
            {
                InitializeComponent();
                comboTournament.Items.AddRange(new[] { "men", "women" });
                comboLanguage.Items.AddRange(new[] { "EN", "HR" });
                comboTournament.SelectedIndex = 0;
                comboLanguage.SelectedIndex = 0;
            }

            private void btnConfirm_Click(object sender, EventArgs e)
            {
                SelectedTournament = comboTournament.SelectedItem.ToString() ?? "men";
                SelectedLanguage = comboLanguage.SelectedItem.ToString() ?? "EN";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    
}
