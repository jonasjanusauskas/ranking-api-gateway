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
        public decimal Rating { get; set; }
        [JsonProperty("deviation")]
        public decimal Deviation { get; set; }
        [JsonProperty("volatility")]
        public decimal Volatility { get; set; }
    }
}
