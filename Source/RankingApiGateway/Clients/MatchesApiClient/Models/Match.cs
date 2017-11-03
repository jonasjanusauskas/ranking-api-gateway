using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.MatchesApiClient.Models
{
    public class Match
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("winnerId")]
        public string WinnerId { get; set; }
        [JsonProperty("loserId")]
        public string LoserId { get; set; }
        [JsonProperty("score")]
        public string Score { get; set; }
    }
}
