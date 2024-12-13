using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWVUEL.Library.Contracts.DTOs
{
    public class StarshipApiDto
    {
    
        public string? name { get; set; }
        public string? model { get; set; }
        public string? manufacturer { get; set; }
        public string? cost_in_credits { get; set; }
        public string? length { get; set; }
        public string? crew { get; set; }
        public string? passengers { get; set; }
        public string? starship_class { get; set; }
        public string? url { get; set; }
    }
}
