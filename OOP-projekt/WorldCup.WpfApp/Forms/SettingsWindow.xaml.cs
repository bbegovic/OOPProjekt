using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WorldCup.WpfApp
{
    public partial class SettingsWindow : Window
    {
        private const string SettingsFile = "settings.json";

        public SettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                var json = File.ReadAllText(SettingsFile);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null)
                {
                    cmbLanguage.SelectedItem = cmbLanguage.Items
                        .Cast<ComboBoxItem>()
                        .FirstOrDefault(i => i.Content.ToString() == settings.Language);

                    cmbTournament.SelectedItem = cmbTournament.Items
                        .Cast<ComboBoxItem>()
                        .FirstOrDefault(i => i.Content.ToString() == settings.Tournament);

                    if (settings.WindowMode == "Fullscreen") rbFullscreen.IsChecked = true;
                    else if (settings.WindowMode == "1280x720") rb1280.IsChecked = true;
                    else if (settings.WindowMode == "1600x900") rb1600.IsChecked = true;
                }
            }
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var settings = new AppSettings
            {
                Language = (cmbLanguage.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Tournament = (cmbTournament.SelectedItem as ComboBoxItem)?.Content.ToString(),
                WindowMode = rbFullscreen.IsChecked == true ? "Fullscreen" :
                             rb1280.IsChecked == true ? "1280x720" :
                             "1600x900"
            };

            File.WriteAllText(SettingsFile, JsonSerializer.Serialize(settings));
            MessageBox.Show("Postavke spremljene!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true; 
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }

    public class AppSettings
    {
        public string Language { get; set; }
        public string Tournament { get; set; }
        public string WindowMode { get; set; }
    }
}
