using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.RatingApiClient.Models
{
    public class PlayerRating
    {
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("deviation")]
        public double Deviation { get; set; }
        [JsonProperty("volatility")]
        public double Volatility { get; set; }
    }
}
