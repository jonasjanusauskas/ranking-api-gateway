using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.PlayersApiClient.Models
{
    public class Player
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("deviation")]
        public double Deviation { get; set; }
        [JsonProperty("volatility")]
        public double Volatility { get; set; }

        public void UpdateRating(int rating, double deviation, double volatility)
        {
            Rating = rating;
            Deviation = deviation;
            Volatility = volatility;
        }
    }
}
