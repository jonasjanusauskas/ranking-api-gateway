using RankingApiGateway.Clients.PlayersApiClient.Models;
using RankingApiGateway.Clients.RatingApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Mappers
{
    public class RatingMapper
    {
        public static PlayersRatings Map(Player winner, Player loser)
        {
            return new PlayersRatings
            {
                WinnerRating = Map(winner),
                LoserRating = Map(loser),
            };
        }

        private static PlayerRating Map(Player player)
        {
            return new PlayerRating
            {
                Deviation = player.Deviation,
                Rating = player.Rating,
                Volatility = player.Volatility,
            };
        }
    }
}
