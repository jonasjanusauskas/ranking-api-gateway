using RankingApiGateway.Clients.PlayersApiClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.PlayersApiClient
{
    public interface IPlayersApiClient
    {
        [Get("/players")]
        Task<IReadOnlyCollection<Player>> GetAllPlayers();

        [Get("/players/{id}")]
        Task<Player> GetPlayer([AliasAs("id")] string id);

        [Post("/players")]
        Task<Player> CreatePlayer(CreatePlayerRequest request);

        [Put("/players/{id}")]
        Task<Player> UpdatePlayer([AliasAs("id")] string id, UpdatePlayerRequest request);
    }
}
