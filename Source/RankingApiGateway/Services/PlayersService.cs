using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Services
{
    public interface IPlayersService
    {
        IReadOnlyCollection<Player> GetAllPlayers();
        Player GetPlayerById(Guid id);
        Player CreatePlayer(CreatePlayerCommand command);
    }

    public class PlayersService : IPlayersService
    {

        IReadOnlyCollection<Player> players = new List<Player>
        {
            new Player{ Id = Guid.NewGuid(), Name = "Player 1", Rank = "1" },
            new Player{ Id = Guid.NewGuid(), Name = "Player 2", Rank = "2" },
        };


        public PlayersService()
        {
           
        }

        public IReadOnlyCollection<Player> GetAllPlayers()
        {
            return players;
        }

        public Player GetPlayerById(Guid id)
        {
            return players.FirstOrDefault();
        }

        public Player CreatePlayer(CreatePlayerCommand command)
        {
            return new Player
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Rank = "-"
            };
        }
    }
}
