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
        Task<PlayerModel> GetPlayerById(Guid id);
        Task<PlayerModel> CreatePlayer(CreatePlayerCommand command);
    }

    public class PlayersService : IPlayersService
    {
        IReadOnlyCollection<Player> players = new List<Player>
        {
            new Player{ Id = Guid.NewGuid().ToString(), Name = "Player 1", Rating = 1 },
            new Player{ Id = Guid.NewGuid().ToString(), Name = "Player 2", Rating = 2 },
        };

        private readonly IPlayersApiClient playersApiClient;
        private readonly IRatingApiClient ratingApiClient;

        public PlayersService(IPlayersApiClient playersApiClient, IRatingApiClient ratingApiClient)
        {
            this.playersApiClient = playersApiClient;
            this.ratingApiClient = ratingApiClient;
        }

        public async Task<IReadOnlyCollection<PlayerModel>> GetAllPlayers()
        {
            return PlayerMapper.Map(players);
        }

        public async Task<PlayerModel> GetPlayerById(Guid id)
        {
            return PlayerMapper.Map(players.FirstOrDefault());
        }

        public async Task<PlayerModel> CreatePlayer(CreatePlayerCommand command)
        {
            var rating = await ratingApiClient.GetDefaultPlayerRating();

            Player player = new Player
            {
                Name = command.Name
            };

            player.UpdateRating(rating.Rating, rating.Deviation, rating.Volatility);

            Player createdPlayer = await playersApiClient.CreatePlayer(player);

            return PlayerMapper.Map(createdPlayer);
        }
    }
}