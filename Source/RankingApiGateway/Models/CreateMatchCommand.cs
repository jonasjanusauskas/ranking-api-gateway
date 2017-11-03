using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApiGateway.Models
{
    public class CreateMatchCommand
    {
        public Guid WinnerId { get; set; }
        public Guid LoserId { get; set; }
        public string Score { get; set; }
    }
}
