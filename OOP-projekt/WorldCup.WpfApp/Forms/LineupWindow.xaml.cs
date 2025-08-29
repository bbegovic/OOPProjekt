using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WorldCup.DataLayer.Models;
using WorldCup.DataLayer.Models.descriptions;
using WorldCup.WpfApp;

namespace WorldCup.WpfApp
{
    public partial class LineupWindow : Window
    {
        private readonly List<Player> _homePlayers;
        private readonly List<Player> _awayPlayers;

        public LineupWindow(List<Player> homePlayers, List<Player> awayPlayers)
        {
            InitializeComponent();
            _homePlayers = homePlayers;
            _awayPlayers = awayPlayers;

            Loaded += LineupWindow_Loaded;
        }

        private void LineupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayPlayers(_homePlayers, isHome: true);
            DisplayPlayers(_awayPlayers, isHome: false);
        }

        private void DisplayPlayers(List<Player> players, bool isHome)
        {
            foreach (var player in players)
            {
                var btn = new Button
                {
                    Content = $"{player.Shirt_number} {player.Name}",
                    Width = 80,
                    Height = 30,
                    Tag = player
                };

                btn.Click += Player_Click;

                
                var (x, y) = GetPlayerPosition(player.Position, isHome);
                Canvas.SetLeft(btn, x);
                Canvas.SetTop(btn, y);

                canvasField.Children.Add(btn);
            }
        }

        private static (double x, double y) GetPlayerPosition(string position, bool isHome)
        {
           
            double offsetX = isHome ? 100 : 500; 
            switch (position.ToLower())
            {
                case "goalie":
                    return (offsetX, 250);
                case "defender":
                    return (offsetX, 150);
                case "midfield":
                    return (offsetX, 300);
                case "forward":
                    return (offsetX, 450);
                default:
                    return (offsetX, 300);
            }
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Player player)
            {
                var win = new PlayerInfoWindow(player);
                win.Owner = this;
                win.ShowDialog();
            }
        }
    }
}
