using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RankingApiGateway.Models;
using RankingApiGateway.Services;
using System.Net;

namespace RankingApiGateway.Controllers
{
    [Route("api/[controller]")]
    public class ScoreboardController : Controller
    {
        private readonly IScoreboardService scoreboardService;

        public ScoreboardController(IScoreboardService scoreboardService)
        {
            this.scoreboardService = scoreboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                return Ok(await scoreboardService.GetScoreboardData());
            }

            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
