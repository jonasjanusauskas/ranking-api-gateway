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
        [Get("/api/players")]
        Task<IReadOnlyCollection<Player>> GetAllPlayers();

        [Get("/api/players/{id}")]
        Task<Player> GetPlayer([AliasAs("id")] string id);

        [Post("/api/players")]
        Task<Player> CreatePlayer(CreatePlayerRequest request);

        [Put("/api/players")]
        Task<Player> UpdatePlayer(UpdatePlayerRequest request);
    }
}
