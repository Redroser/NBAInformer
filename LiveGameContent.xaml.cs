using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NBAInformer
{
    public partial class LiveGameContent : UserControl
    {
        public LiveGameContent(string HomeTeamLogo, string AwayTeamLogo, Int32? HomeScore, Int32? AwayHome, string GameTime, string Status)
        {
            InitializeComponent();
            LogoLeft.Source = new BitmapImage(new Uri(HomeTeamLogo, UriKind.Relative));
            LogoRight.Source = new BitmapImage(new Uri(AwayTeamLogo, UriKind.Relative));
            if (GameTime != null)
            {
                DateTime dateTime = DateTime.Parse(GameTime);
                GameStartTime.Text = dateTime.ToString("HH-mm");
            }
            else
            {
                GameStartTime.Text = "No time";
            }
            GameStatus.Text = Status;
            if (HomeScore == null) HomeScore = 0;
            if (AwayHome == null) AwayHome = 0;
            GameScore.Text = HomeScore + " - " + AwayHome;
        }
    }
}
