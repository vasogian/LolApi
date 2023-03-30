using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApi.Database.Models
{
    public class TftSummonerEntry
    {
        [Key]
        public int TftSummonerId { get; set; }
        public string? SummonerName { get; set; }
        public int NumOfTimesSearched { get; set; }
    }
}
