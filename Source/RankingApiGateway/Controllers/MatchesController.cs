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
        public IEnumerable<Match> GetAllMatches()
        {
            return matchService.GetAllMatches();
        }

        [HttpGet("{id}")]
        public Match Get(Guid id)
        {
            return matchService.GetMatchById(id);
        }
        
        [HttpPost]
        public Match CreatePlayer([FromBody]CreateMatchCommand command)
        {
            if(command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            return matchService.CreateMatch(command);
        }
    }
}
