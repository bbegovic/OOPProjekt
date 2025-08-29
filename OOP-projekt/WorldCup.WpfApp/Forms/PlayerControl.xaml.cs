using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using WorldCup.DataLayer.Models.descriptions;

namespace WorldCup.WpfApp.Controls
{
    public partial class PlayerControl : UserControl
    {
        public Player Player { get; private set; }

        public PlayerControl(Player player)
        {
            InitializeComponent();
            Player = player;
            SetPlayerInfo(player);
        }

        private void SetPlayerInfo(Player player)
        {
            txtName.Text = player.Name;
            txtNumber.Text = player.Shirt_number.ToString();

            string imagePath = $@"../../../assets/players/{player.Name}.png";
            if (System.IO.File.Exists(imagePath))
            {
                imgPlayer.Source = new BitmapImage(new System.Uri(imagePath, System.UriKind.Relative));
            }

           
            this.MouseLeftButtonUp += PlayerControl_MouseLeftButtonUp;
        }

        private void PlayerControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var playerWindow = new PlayerInfoWindow(Player);
            playerWindow.Owner = Window.GetWindow(this);
            playerWindow.ShowDialog();
        }
    }
}
