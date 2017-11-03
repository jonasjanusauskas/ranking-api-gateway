using RankingApiGateway.Clients.RatingApiClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.RatingApiClient
{
    public interface IRatingApiClient
    {
        [Get("/ratings/default")]
        Task<PlayerRating> GetDefaultPlayerRating();

        [Post("/ratings")]
        Task<PlayersRatings> CalculatePlayersRatings(PlayersRatings ratings);
    }
}
