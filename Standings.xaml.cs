using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NBAInformer
{
    public partial class Standings : UserControl
    {
        readonly ViewModel vm = new ViewModel();
        public Standings()
        {
            InitializeComponent();
            DisplayStandings();
        }

        private void DisplayStandings()
        {
            ClearStandings();
            List<Team> teams = vm.GetStandings();
            EnterTeamsToStackPanels(teams);
        }

        private void EnterTeamsToStackPanels(List<Team> teams)
        {
            teams.Sort((x, y) => x.ConferenceRank.CompareTo(y.ConferenceRank));
            foreach (var team in teams)
            {
                var block = new StandingsBlockContent(team.City, team.Name, team.Wins, team.Losses, team.Percentage, team.GetPathToLogo(team.Key));
                block.Margin = new Thickness(20, 0, 20, 5);
                if (team.Conference == "Eastern") EasternStack.Children.Add(block);
                else WesternStack.Children.Add(block);
            }
        }
        private void ClearStandings()
        {
            EasternStack.Children.Clear();
            WesternStack.Children.Clear();
        }

        private void ReloadStandingsButton_Click(object sender, RoutedEventArgs e)
        {
            vm.GetStandingsFromAPI();
            DisplayStandings();
        }
    }
}
