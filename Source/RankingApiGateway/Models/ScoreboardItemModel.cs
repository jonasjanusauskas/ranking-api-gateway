using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class ScoreboardItemModel
    {
        public decimal Rating { get; set; }
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
