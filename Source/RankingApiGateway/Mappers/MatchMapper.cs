using RankingApiGateway.Clients.MatchesApiClient.Models;
using RankingApiGateway.Clients.PlayersApiClient.Models;
using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Mappers
{
    internal class MatchMapper
    {
        public static List<MatchModel> Map(IEnumerable<Match> matches, IEnumerable<Player> players)
        {
            return matches.Select(x => Map(x, players)).ToList();
        }

        public static MatchModel Map(Match match, IEnumerable<Player> players)
        {
            return new MatchModel
            {
                Id = match.Id,
                WinnerId = match.WinnerId,
                LoserId = match.LoserId,
                Score = match.Score,

                Winner = players?.FirstOrDefault(x => x?.Id == match.WinnerId)?.Name,
                Loser = players?.FirstOrDefault(x => x?.Id == match.LoserId)?.Name
            };
        }
    }
}
