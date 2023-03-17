using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.IO;

namespace NBAInformer
{
    internal class ViewModel
    {
        public string jsonStandingsFilePath = AppDomain.CurrentDomain.BaseDirectory + @"ProgramRes/";
        private readonly HttpClient client = new HttpClient();
        private readonly JSONSerializator jsonSerializator = new JSONSerializator();
        private readonly Logger logger = new Logger();

        public List<Team> GetStandings()
        {
            if (File.Exists(jsonStandingsFilePath + "Standings.json")) return GetStandingsFromFile();
            else return GetStandingsFromAPI();
        }

        public List<Game> GetLiveGames()
        {
            try
            {
                var path = "https://api.sportsdata.io/api/nba/odds/json/GamesByDate/" + DateTime.UtcNow.ToString("yyyy-MM-dd");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(path),
                    Headers =
                {
                    { "Ocp-Apim-Subscription-Key", "bf68981a15be4509b7239667ca3a0cd3" }
                },
                };
                using (Task<HttpResponseMessage> response = client.SendAsync(request))
                {
                    if (response.Result.StatusCode.ToString() == "OK")
                    {
                        var body = response.Result.Content.ReadAsStringAsync().Result;
                        return jsonSerializator.SerializeGamesList(body);
                    }
                    else
                    {
                        MessageBox.Show("Service isn't available");
                        return new List<Game>();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("API service isn't available");
                MessageBox.Show(ex.Message);
                return new List<Game>();
            }
        }
        public List<Game> GetGamesInDate(DateTime date)
        {
            try
            {
                string choosenDate = date.AddDays(-1).ToString("yyyy-MM-dd");
                var path = "https://api.sportsdata.io/api/nba/odds/json/GamesByDate/" + choosenDate;
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(path),
                    Headers =
                {
                    { "Ocp-Apim-Subscription-Key", "bf68981a15be4509b7239667ca3a0cd3" }
                },
                };
                using (Task<HttpResponseMessage> response = client.SendAsync(request))
                {
                    if (response.Result.StatusCode.ToString() == "OK")
                    {
                        var body = response.Result.Content.ReadAsStringAsync().Result;
                        return jsonSerializator.SerializeGamesList(body);
                    }
                    else
                    {
                        MessageBox.Show("Service isn't available");
                        return new List<Game>();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("API service isn't available");
                MessageBox.Show(ex.Message);
                return new List<Game>();
            }
            
        }

        public List<Team> GetStandingsFromAPI()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.sportsdata.io/api/nba/fantasy/json/Standings/2023"),
                    Headers =
                {
                    { "Ocp-Apim-Subscription-Key", "bf68981a15be4509b7239667ca3a0cd3" }
                },
                };
                using (Task<HttpResponseMessage> response = client.SendAsync(request))
                {
                    if (response.Result.StatusCode.ToString() == "OK")
                    {
                        var body = response.Result.Content.ReadAsStringAsync().Result;
                        _ = SaveJson(body);
                        return jsonSerializator.SerializeStandingsList(body);
                    }
                    else
                    {
                        MessageBox.Show("Service isn't available");
                        return new List<Team>();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("API service isn't available");
                MessageBox.Show(ex.Message);
                return new List<Team>();
            }
        }
        private List<Team> GetStandingsFromFile()
        {
            try
            {
                string body;
                using (StreamReader reader = new StreamReader(jsonStandingsFilePath + "Standings.json"))
                {
                    body = reader.ReadToEnd();
                }
                return jsonSerializator.SerializeStandingsList(body);
            }
            catch(Exception ex)
            {
                logger.Error("File Standings incorrect");
                MessageBox.Show(ex.Message);
                return new List<Team>();
            }
        }
        private async Task SaveJson(string body)
        {
            try
            {
                if (!Directory.Exists(jsonStandingsFilePath))
                    Directory.CreateDirectory(jsonStandingsFilePath);
                await Task.Run(() => File.WriteAllText(jsonStandingsFilePath + "Standings.json", body));
            }
            catch(Exception ex)
            {
                logger.Error("Problem with saving file");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
