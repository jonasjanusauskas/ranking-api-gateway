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
        public IEnumerable<Player> GetAllPlayers()
        {
            return playerService.GetAllPlayers();
        }

        [HttpGet("{id}")]
        public Player GetPlayerById(Guid id)
        {
            return playerService.GetPlayerById(id);
        }
        
        [HttpPost]
        public Player CreatePlayer([FromBody]CreatePlayerCommand command)
        {
            if(command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            return playerService.CreatePlayer(command);
        }
    }
}
