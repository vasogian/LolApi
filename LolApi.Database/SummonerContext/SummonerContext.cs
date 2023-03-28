using Microsoft.EntityFrameworkCore;
using LolApi.Models;
using LolApi.Database.Models;

namespace LolApi.SummDbContext

{
    public class SummonerContext : DbContext
    {

        public SummonerContext(DbContextOptions<SummonerContext> options)
           : base(options)
        {
        }
        public DbSet<SummonerEntry> Summoner { get; set; }
        public DbSet<TftSummonerEntry> TftSummoner { get; set; }
    }
}
