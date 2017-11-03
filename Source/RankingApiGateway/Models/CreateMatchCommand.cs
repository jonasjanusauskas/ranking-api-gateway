using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class CreateMatchCommand
    {
        public string WinnerId { get; set; }
        public string LoserId { get; set; }
        public string Score { get; set; }
    }
}
