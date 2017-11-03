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
    public class PlayersController : Controller
    {
        private readonly IPlayersService playerService;

        public PlayersController(IPlayersService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerModel>> GetAllPlayers()
        {
            return await playerService.GetAllPlayers();
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
