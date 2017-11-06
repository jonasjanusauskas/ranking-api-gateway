using RankingApiGateway.Clients.MatchesApiClient;
using RankingApiGateway.Clients.PlayersApiClient;
using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Services
{
    public interface IScoreboardService
    {
        Task<IReadOnlyCollection<ScoreboardItemModel>> GetScoreboardData();
    }

    public class ScoreboardService : IScoreboardService
    {
        private readonly IPlayersApiClient playersApiClient;
        private readonly IMatchesApiClient matchesApiClient;

        public ScoreboardService(IPlayersApiClient playersApiClient, IMatchesApiClient matchesApiClient)
        {
            this.playersApiClient = playersApiClient;
            this.matchesApiClient = matchesApiClient;
        }

        public async Task<IReadOnlyCollection<ScoreboardItemModel>> GetScoreboardData()
        {
            var players = await playersApiClient.GetAllPlayers();

            List<ScoreboardItemModel> scores = new List<ScoreboardItemModel>();

            foreach(var player in players)
            {
                var matches = await this.matchesApiClient.GetPlayerMatches(player.Id);

                scores.Add(new ScoreboardItemModel
                {
                    PlayerId = player.Id,
                    PlayerName = player.Name,
                    Rating = player.Rating,
                    Wins = matches?.Where(x => x.WinnerId == player.Id)?.Count() ?? 0,
                    Losses = matches?.Where(x => x.LoserId == player.Id)?.Count() ?? 0,
                });
            }

            return scores.OrderByDescending(x => x.Rating).ToList();
        }
    }
}
