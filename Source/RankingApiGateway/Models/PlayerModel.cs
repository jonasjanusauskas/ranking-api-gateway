using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class PlayerModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public decimal Deviation { get; set; }
        public decimal Volatility { get; set; }
    }
}
