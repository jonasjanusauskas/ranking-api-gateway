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
        public int Rating { get; set; }
        public double Deviation { get; set; }
        public double Volatility { get; set; }
    }
}
