using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class MatchModel
    {
        public string Id { get; set; }
        public string WinnerId { get; set; }
        public string Winner { get; set; }
        public string LoserId { get; set; }
        public string Loser { get; set; }
        public string Score { get; set; }
    }
}
