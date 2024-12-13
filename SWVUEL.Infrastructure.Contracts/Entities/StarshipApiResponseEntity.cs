using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVUEL.Infrastructure.Contracts.Entities
{
    public class StarshipApiResponseEntity
    {
        public int? count { get; set; }
        public string? next { get; set; }
        public object? previous { get; set; }
        public List<Starship>? results { get; set; }
    }
}
