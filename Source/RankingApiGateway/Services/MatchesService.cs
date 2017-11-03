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
            Player winner = await playersApiClient.GetPlayer(command.WinnerId);
            Player loser = await playersApiClient.GetPlayer(command.LoserId);            

            var ratings = await ratingApiClient.CalculatePlayersRatings(RatingMapper.Map(winner, loser));

            UpdatePlayerRequest updateWinnerRequest = new UpdatePlayerRequest(winner.Name, ratings.WinnerRating.Rating, ratings.WinnerRating.Deviation, ratings.WinnerRating.Volatility);
            await playersApiClient.UpdatePlayer(winner.Id, updateWinnerRequest);

            UpdatePlayerRequest updateLoserRequest = new UpdatePlayerRequest(loser.Name, ratings.LoserRating.Rating, ratings.LoserRating.Deviation, ratings.LoserRating.Volatility);
            await playersApiClient.UpdatePlayer(loser.Id, updateLoserRequest);

            CreateMatchRequest createMatchRequest = new CreateMatchRequest(command.WinnerId, command.LoserId, command.Score);
            Match match = await matchesApiClient.CreateMatch(createMatchRequest);

            return MatchMapper.Map(match, new List<Player> { loser, winner });
        }
    }
}
