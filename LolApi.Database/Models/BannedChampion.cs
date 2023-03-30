namespace LolApi.Models
{
    public class BannedChampion
    {
        public int PickTurn { get; set; }
        public long ChampionId { get; set; }
        public long TeamId { get; set; }
    }
}
