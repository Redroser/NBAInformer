using System;
using System.Collections.Generic;

namespace NBAInformer
{
    internal class Game
    {
        public int GameID { get; set;}
        public string Status { get; set; }
        public string DateTime { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public int AwayTeamID { get; set; }
        public int HomeTeamID { get; set; }
        public Int32? AwayTeamScore { get; set; }
        public Int32? HomeTeamScore { get; set; }
        public List<Quarter> Quarters { get; set; }

        public Team GetTeamObject(string key) {
            return new Team(key);
        }
    }
}
