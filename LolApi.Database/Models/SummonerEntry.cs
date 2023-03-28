using System.ComponentModel.DataAnnotations;

namespace LolApi.Models
{
    public class SummonerEntry
    {
        [Key]
        public int SummonerId { get; set; }
        public string? SummonerName { get; set; }
        public int NumOfTimesSearched { get; set; }
    }
}
