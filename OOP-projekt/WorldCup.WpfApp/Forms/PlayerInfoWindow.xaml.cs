using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using WorldCup.DataLayer.Models.descriptions;

namespace WorldCup.WpfApp
{
    public partial class PlayerInfoWindow : Window
    {
        private readonly Player _player;

        public PlayerInfoWindow(Player player)
        {
            InitializeComponent();
            _player = player;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtName.Text = _player.Name;
            txtPosition.Text = $"Pozicija: {_player.Position}";
            txtShirtNumber.Text = $"Broj: {_player.Shirt_number}";
            txtCaptain.Text = _player.Captain ? "Kapetan: Da" : "Kapetan: Ne";

           
            string imagePath = $@"../../../assets/players/{_player.Name}.png";
            if (System.IO.File.Exists(imagePath))
                imgPlayer.Source = new BitmapImage(new System.Uri(imagePath, System.UriKind.Relative));

            
            txtGoals.Text = $"Golovi: 0";
            txtYellowCards.Text = $"Žuti kartoni: 0";

            
            var fade = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
            this.BeginAnimation(Window.OpacityProperty, fade);
        }
    }
}
