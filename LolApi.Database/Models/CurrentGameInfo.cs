namespace LolApi.Models
{
    public class CurrentGameInfo
    {
        public long GameId { get; set; }
        public string? GameType { get; set; }
        public long GameStartTime { get; set; }
        public long MapId { get; set; }
        public long GameLength { get; set; }  
        public string? PlatformId { get; set; }
        public string? GameMode { get; set; }
        public List<BannedChampion> bannedChampions {get; set; } = new List<BannedChampion>();
        public long GameQueueConfigId { get; set; }
        public Observer? Observers { get; set; }
        public List<CurrentGameParticipant> participants { get; set; } = new List<CurrentGameParticipant> ();
    }


}
