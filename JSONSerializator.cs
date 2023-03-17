using System.Collections.Generic;
using System.Text.Json;

namespace NBAInformer
{
    internal class JSONSerializator
    {
        public List<Team> SerializeStandingsList(string bodyAPI)
        {
            List<Team> teams = JsonSerializer.Deserialize<List<Team>>(bodyAPI);
            return teams;
        }

        public List<Game> SerializeGamesList(string bodyAPI)
        {
            List<Game> games = JsonSerializer.Deserialize<List<Game>>(bodyAPI);
            return games;
        }
    }
}
