using RankingApiGateway.Clients.MatchesApiClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Clients.MatchesApiClient
{
    public interface IMatchesApiClient
    {
        [Get("/matches")]
        Task<List<Match>> GetAllMatches();

        [Get("/matches/{id}")]
        Task<Match> GetMatch([AliasAs("id")] string id);

        [Post("/matches")]
        Task<Match> CreateMatch(CreateMatchRequest match);        
    }
}
