using System.Windows;
using System.Windows.Controls;

namespace NBAInformer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LiveGamesButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            DataContent.Content = new LiveGames();
        }

        private void StandingsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            DataContent.Content = new Standings();
        }

        private void CompletedGamesButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            DataContent.Content = new CompletedGames();
        }

        private void ChangeButtonStyle(object activeButton) {
            LiveGamesButton.Style = this.FindResource("HeaderButtonDisactiveStyle") as Style;
            StandingsButton.Style = this.FindResource("HeaderButtonDisactiveStyle") as Style;
            CompletedGamesButton.Style = this.FindResource("HeaderButtonDisactiveStyle") as Style;
            Button clickableButton = (Button)activeButton;
            clickableButton.Style = this.FindResource("HeaderButtonActiveStyle") as Style;
        }
    }
}
