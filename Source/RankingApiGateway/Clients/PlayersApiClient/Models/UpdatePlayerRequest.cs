using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.PlayersApiClient.Models
{
    public class UpdatePlayerRequest
    {
        public UpdatePlayerRequest(string name, decimal rating, decimal deviation, decimal volatility)
        {
            Name = name;
            Rating = rating;
            Deviation = deviation;
            Volatility = volatility;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rating")]
        public decimal Rating { get; set; }
        [JsonProperty("deviation")]
        public decimal Deviation { get; set; }
        [JsonProperty("volatility")]
        public decimal Volatility { get; set; }
    }
}
