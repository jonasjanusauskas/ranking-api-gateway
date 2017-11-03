using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RankingApiGateway.Models;
using RankingApiGateway.Services;

namespace RankingApiGateway.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly IMatchesService matchService;

        public MatchesController(IMatchesService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet]
        public async Task<IEnumerable<MatchModel>> GetAllMatches()
        {
            return await matchService.GetAllMatches();
        }

        [HttpGet("{id}")]
        public async Task<MatchModel> Get(string id)
        {
            return await matchService.GetMatchById(id);
        }
        
        [HttpPost]
        public async Task<MatchModel> CreatePlayer([FromBody]CreateMatchCommand command)
        {
            if(command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            return await matchService.CreateMatch(command);
        }
    }
}
