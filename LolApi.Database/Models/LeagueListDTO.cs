using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApi.Database.Models
{
    public class LeagueListDTO
    {
        public string? leagueId { get; set; }
        public List<LeagueItemDTO> Entries { get; set; } = new List<LeagueItemDTO>();
        public string? Tier { get; set; }
        public string? Name { get; set; }
        public string? Queue { get; set; }
    }
}
