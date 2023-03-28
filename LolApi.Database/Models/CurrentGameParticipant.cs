﻿namespace LolApi.Models
{
    public class CurrentGameParticipant
    {
        public long ChampionId { get; set; }
        public Perks? Perks { get; set; }
        public long ProfileIconId { get; set; }
        public bool Bot { get; set; }
        public long TeamId { get; set; }
        public string? SummonerName { get; set; }
        public string? SummonerId { get; set; }
        public long Spell1Id { get; set; }
        public int? Spell2Id { get; set; }
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; } = new List<GameCustomizationObject>();

    }
}
