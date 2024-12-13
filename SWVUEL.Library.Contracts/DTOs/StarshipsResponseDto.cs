using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWVUEL.Library.Contracts.DTOs
{
    public class StarshipsResponseDto
    {
   
        public int? count { get; set; }

        public string? next { get; set; }
    
        public string? previous { get; set; }
        public List<StarshipApiDto>? results { get; set; }
    }
}
