namespace NBAInformer
{
    internal class Team
    {
        public int TeamID { get; set; }
        public string Key { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float Percentage { get; set; }
        public int ConferenceRank { get; set; }

        //public List<Player> PlayersList;

        public Team() { }

        public Team(string key)
        {
            Key = key;
        }


        public string GetPathToLogo(string key)
        {
            return "ViewResources/Logos/" + key + ".png";
        }
    }
}
