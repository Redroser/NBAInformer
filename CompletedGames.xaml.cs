using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NBAInformer
{
    public partial class CompletedGames : UserControl
    {
        private readonly ViewModel vm = new ViewModel();
        public CompletedGames()
        {
            InitializeComponent();
        }

        public void DisplayCompletedGames(DateTime date) { }

        private void ButtonToday_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            CompletedGamesWrapPanel.Children.Clear();
            DisplayGames(vm.GetGamesInDate(DateTime.UtcNow.AddDays(-1)));
        }

        private void ButtonYesterday_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            CompletedGamesWrapPanel.Children.Clear();
            DisplayGames(vm.GetGamesInDate(DateTime.UtcNow.AddDays(-2)));
        }

        private void ButtonChooseDate_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonStyle(sender);
            CompletedGamesWrapPanel.Children.Clear();
            Calendar.Visibility = Visibility.Visible;
        }

        private void ChangeButtonStyle(object activeButton)
        {
            ButtonToday.Style = this.FindResource("ButtonLiveGameStyle") as Style;
            ButtonYesterday.Style = this.FindResource("ButtonLiveGameStyle") as Style;
            ButtonChooseDate.Style = this.FindResource("ButtonLiveGameStyle") as Style;
            Button clickableButton = (Button)activeButton;
            clickableButton.Style = this.FindResource("ButtonActiveLiveGameStyle") as Style;
        }
        private void DisplayGames(List<Game> games)
        {
            foreach (var game in games)
            {
                if (game.Status == "F/OT" || game.Status == "Final")
                {
                    var block = new CompleteGameContent(game.GetTeamObject(game.HomeTeam).GetPathToLogo(game.HomeTeam), game.GetTeamObject(game.AwayTeam).GetPathToLogo(game.AwayTeam), game.HomeTeamScore, game.AwayTeamScore, game.DateTime, game.Status, game.Quarters);
                    block.Margin = new Thickness(20, 0, 20, 5);
                    CompletedGamesWrapPanel.Children.Add(block);
                }
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar.SelectedDate;
            if (selectedDate != null) 
            {
                DateTime date = (DateTime)selectedDate;
                Calendar.Visibility = Visibility.Hidden;
                DisplayGames(vm.GetGamesInDate(date));
            }
        }
    }
}
