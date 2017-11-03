using RankingApiGateway.Clients;
using RankingApiGateway.Clients.MatchesApiClient;
using RankingApiGateway.Clients.MatchesApiClient.Models;
using RankingApiGateway.Clients.PlayersApiClient;
using RankingApiGateway.Clients.PlayersApiClient.Models;
using RankingApiGateway.Clients.RatingApiClient;
using RankingApiGateway.Mappers;
using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Services
{
    public interface IMatchesService
    {
        Task<IReadOnlyCollection<MatchModel>> GetAllMatches();
        Task<MatchModel> GetMatchById(string id);
        Task<MatchModel> CreateMatch(CreateMatchCommand command);
    }

    public class MatchesService : IMatchesService
    {
        IReadOnlyCollection<Match> matches = new List<Match>
        {
            new Match {
                Id = Guid.NewGuid().ToString(),
                LoserId = Guid.NewGuid().ToString(),
                WinnerId = Guid.NewGuid().ToString()
            },
            new Match{
                Id = Guid.NewGuid().ToString(),
                LoserId = Guid.NewGuid().ToString(),
                WinnerId = Guid.NewGuid().ToString()
            },
        };

        private readonly IPlayersApiClient playersApiClient;
        private readonly IMatchesApiClient matchesApiClient;
        private readonly IRatingApiClient ratingApiClient;

        public MatchesService(IPlayersApiClient playersApiClient, IMatchesApiClient matchesApiClient, IRatingApiClient ratingApiClient)
        {
            this.playersApiClient = playersApiClient;
            this.matchesApiClient = matchesApiClient;
            this.ratingApiClient = ratingApiClient;
        }

        public async Task<IReadOnlyCollection<MatchModel>> GetAllMatches()
        {
            var players = await playersApiClient.GetAllPlayers();
            return MatchMapper.Map(matches, players);
        }

        public async Task<MatchModel> GetMatchById(string id)
        {
            var match = matches.FirstOrDefault();

            Player loser = await playersApiClient.GetPlayer(match.LoserId);
            Player winner = await playersApiClient.GetPlayer(match.WinnerId);

            return MatchMapper.Map(match, new List<Player> { loser, winner });
        }

        public async Task<MatchModel> CreateMatch(CreateMatchCommand command)
        {
            Player loser = await playersApiClient.GetPlayer(command.LoserId);
            Player winner = await playersApiClient.GetPlayer(command.WinnerId);

            var ratings = await ratingApiClient.CalculatePlayersRatings(RatingMapper.Map(winner, loser));

            winner.UpdateRating(ratings.WinnerRating.Rating, ratings.WinnerRating.Deviation, ratings.WinnerRating.Volatility);
            await playersApiClient.UpdatePlayer(winner.Id, winner);

            loser.UpdateRating(ratings.LoserRating.Rating, ratings.LoserRating.Deviation, ratings.LoserRating.Volatility);
            await playersApiClient.UpdatePlayer(loser.Id, loser);

            await matchesApiClient.CreateMatch(command);

            var match = new Match
            {
                Id = Guid.NewGuid().ToString(),
                LoserId = Guid.NewGuid().ToString(),
                WinnerId = Guid.NewGuid().ToString()
            };

            return MatchMapper.Map(match, new List<Player> { loser, winner });
        }
    }
}
