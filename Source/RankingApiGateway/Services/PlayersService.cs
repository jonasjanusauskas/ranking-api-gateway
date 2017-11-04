using RankingApiGateway.Clients;
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
    public interface IPlayersService
    {
        Task<IReadOnlyCollection<PlayerModel>> GetAllPlayers();
        Task<PlayerModel> GetPlayerById(string id);
        Task<PlayerModel> CreatePlayer(CreatePlayerCommand command);
    }

    public class PlayersService : IPlayersService
    {
        private readonly IPlayersApiClient playersApiClient;
        private readonly IRatingApiClient ratingApiClient;

        public PlayersService(IPlayersApiClient playersApiClient, IRatingApiClient ratingApiClient)
        {
            this.playersApiClient = playersApiClient;
            this.ratingApiClient = ratingApiClient;
        }

        public async Task<IReadOnlyCollection<PlayerModel>> GetAllPlayers()
        {
            var players = await playersApiClient.GetAllPlayers();
            return PlayerMapper.Map(players);
        }

        public async Task<PlayerModel> GetPlayerById(string id)
        {   
            Player player = await playersApiClient.GetPlayer(id);
            return PlayerMapper.Map(player);
        }

        public async Task<PlayerModel> CreatePlayer(CreatePlayerCommand command)
        {
            var rating = await ratingApiClient.GetDefaultPlayerRating();

            CreatePlayerRequest createPlayerRequest = new CreatePlayerRequest(command.Name, rating.Rating, rating.Deviation, rating.Volatility);

            Player createdPlayer = await playersApiClient.CreatePlayer(createPlayerRequest);

            return PlayerMapper.Map(createdPlayer);
        }
    }
}