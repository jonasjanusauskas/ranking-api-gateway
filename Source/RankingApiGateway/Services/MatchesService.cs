using RankingApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Services
{
    public interface IMatchesService
    {
        IReadOnlyCollection<Match> GetAllMatches();
        Match GetMatchById(Guid id);
        Match CreateMatch(CreateMatchCommand command);
    }

    public class MatchesService : IMatchesService
    {
        IReadOnlyCollection<Match> matches = new List<Match>
        {
            new Match{ Id = Guid.NewGuid(),
                Loser = "Player 1",
                LoserId = Guid.NewGuid(),
                Winner = "Player 2",
                WinnerId = Guid.NewGuid() },
            new Match{ Id = Guid.NewGuid(),
                Loser = "Player 1",
                LoserId = Guid.NewGuid(),
                Winner = "Player 3",
                WinnerId = Guid.NewGuid() },
        };


        public MatchesService()
        {

        }

        public IReadOnlyCollection<Match> GetAllMatches()
        {
            return matches;
        }

        public Match GetMatchById(Guid id)
        {
            return matches.FirstOrDefault();
        }

        public Match CreateMatch(CreateMatchCommand command)
        {
            return new Match
            {
                Id = Guid.NewGuid(),
                Loser = "Player 1",
                LoserId = Guid.NewGuid(),
                Winner = "Player 2",
                WinnerId = Guid.NewGuid()
            };
        }
    }
}
