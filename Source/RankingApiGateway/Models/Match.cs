using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid WinnerId { get; set; }
        public string Winner { get; set; }
        public Guid LoserId { get; set; }
        public string Loser { get; set; }
        public string Score { get; set; }
    }
}
