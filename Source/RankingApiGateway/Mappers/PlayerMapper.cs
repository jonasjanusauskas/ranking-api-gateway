using RankingApiGateway.Clients.PlayersApiClient.Models;
using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Mappers
{
    internal class PlayerMapper
    {
        public static List<PlayerModel> Map(IEnumerable<Player> players)
        {
            return players.Select(x => Map(x)).ToList();
        }

        public static PlayerModel Map(Player player)
        {
            return new PlayerModel
            {
                Id = player.Id,
                Name = player.Name,
                Rating = player.Rating,
                Deviation = player.Deviation,
                Volatility = player.Volatility,
            };
        }
    }
}
