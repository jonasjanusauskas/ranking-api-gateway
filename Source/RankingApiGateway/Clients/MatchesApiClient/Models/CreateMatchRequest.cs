using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.MatchesApiClient.Models
{
    public class CreateMatchRequest
    {
        public CreateMatchRequest(string winnerId, string loserId, string score)
        {
            WinnerId = winnerId;
            LoserId = loserId;
            Score = score;
        }

        [JsonProperty("winnerId")]
        public string WinnerId { get; set; }
        [JsonProperty("loserId")]
        public string LoserId { get; set; }
        [JsonProperty("score")]
        public string Score { get; set; }
    }
}
