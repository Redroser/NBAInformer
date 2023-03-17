using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NBAInformer
{
    public partial class StandingsBlockContent : UserControl
    {

        public StandingsBlockContent(string City, string Name, int Wins, int Losses, float Percentage, string pathToLogo)
        {
            InitializeComponent();
            TeamNameStandings.Text = City + " " + Name;
            TeamGameStatStandings.Text = Wins + " - " + Losses;
            TeamGameKStandings.Text = Percentage.ToString();
            TeamLogoStandings.Source = new BitmapImage(new Uri(pathToLogo, UriKind.Relative));
        }
    }
}
