using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.PlayersApiClient.Models
{
    public class UpdatePlayerRequest
    {
        public UpdatePlayerRequest(string id, string name, decimal rating, decimal deviation, decimal volatility)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Deviation = deviation;
            Volatility = volatility;
        }


        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("rating")]
        public decimal Rating { get; }
        [JsonProperty("deviation")]
        public decimal Deviation { get; }
        [JsonProperty("volatility")]
        public decimal Volatility { get; }
    }
}
