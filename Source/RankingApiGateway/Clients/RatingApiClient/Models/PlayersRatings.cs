using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.RatingApiClient.Models
{
    public class PlayersRatings
    {
        [JsonProperty("winnerRating")]
        public PlayerRating WinnerRating { get; set; }
        [JsonProperty("loserRating")]
        public PlayerRating LoserRating { get; set; }
    }
}
