using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NBAInformer
{
    public partial class LiveGames : UserControl
    {
        private readonly ViewModel vm = new ViewModel();
        public LiveGames()
        {
            InitializeComponent();
            DisplayLiveGames();
        }

        private void DisplayLiveGames()
        {
            List<Game> games = vm.GetLiveGames();
            foreach (var game in games)
            {
                if (game.Status == "Canceled") continue;
                var block = new LiveGameContent(game.GetTeamObject(game.HomeTeam).GetPathToLogo(game.HomeTeam), game.GetTeamObject(game.AwayTeam).GetPathToLogo(game.AwayTeam), game.HomeTeamScore, game.AwayTeamScore, game.DateTime, game.Status);
                block.Margin = new Thickness(20, 0, 20, 5);
                LiveGamesWrapPanel.Children.Add(block);
            }
        }
    }
}
