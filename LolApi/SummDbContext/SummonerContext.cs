using LolApi.Models;
using Microsoft.EntityFrameworkCore;
namespace LolApi.SummDbContext

{
    public class SummonerContext : DbContext
    {

        public SummonerContext(DbContextOptions<SummonerContext> options)
           : base(options)
        {
        }
        public DbSet<SummonerEntry> Summoner { get; set; }
    }
}
