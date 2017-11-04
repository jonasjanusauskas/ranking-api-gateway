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
    public class PlayersController : Controller
    {
        private readonly IPlayersService playerService;

        public PlayersController(IPlayersService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                return Ok(await playerService.GetAllPlayers());
            }

            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet("{id}")]
        public async Task<PlayerModel> GetPlayerById(string id)
        {
            return await playerService.GetPlayerById(id);
        }
        
        [HttpPost]
        public async Task<PlayerModel> CreatePlayer([FromBody]CreatePlayerCommand command)
        {
            if(command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            return await playerService.CreatePlayer(command);
        }
    }
}
