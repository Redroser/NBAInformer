using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NBAInformer
{
    public partial class CompleteGameContent : UserControl
    {
        public CompleteGameContent(string HomeTeamLogo, string AwayTeamLogo, Int32? HomeScore, Int32? AwayHome, string GameTime, string Status, List<Quarter> Quarters)
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
            if (HomeScore == null) HomeScore = 0;
            if (AwayHome == null) AwayHome = 0;
            GameResult.Text = HomeScore + " - " + AwayHome;

            QuarterTable quaterResultLeft = new QuarterTable();
            QuarterTable quaterResultRight = new QuarterTable();

            if (Quarters.Count > 3)
            {
                quaterResultLeft.Q1 = Quarters[0].HomeScore.ToString();
                quaterResultLeft.Q2 = Quarters[1].HomeScore.ToString();
                quaterResultLeft.Q3 = Quarters[2].HomeScore.ToString();
                quaterResultLeft.Q4 = Quarters[3].HomeScore.ToString();

                quaterResultRight.Q1 = Quarters[0].AwayScore.ToString();
                quaterResultRight.Q2 = Quarters[1].AwayScore.ToString();
                quaterResultRight.Q3 = Quarters[2].AwayScore.ToString();
                quaterResultRight.Q4 = Quarters[3].AwayScore.ToString();
            }

            if (Quarters.Count > 4)
            {
                quaterResultLeft.OT = Quarters[4].HomeScore.ToString();
                quaterResultRight.OT = Quarters[4].AwayScore.ToString();
            }

            QuarterResultTable.Items.Add(quaterResultLeft);
            QuarterResultTable.Items.Add(quaterResultRight);
        }
    }
}
