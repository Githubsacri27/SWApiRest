using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWVUEL.Domain.Models.Class1;

namespace SWVUEL.Domain.Models
{
    public class StarshipsResponse
    {
        public int? count { get; set; }
        public string? next { get; set; }
        public object? previous { get; set; }
        public StarshipModel[]? starshipModel { get; set; }
    }
}
