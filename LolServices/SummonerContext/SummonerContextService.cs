using LolApi.SummDbContext;
using LolApi.Models;
using Microsoft.EntityFrameworkCore;
using LolApi.Database.Models;

namespace LolApi.Services
{
    public class SummonerContextService
    {
        private readonly SummonerContext _summonerContext;
        public SummonerContextService(SummonerContext summonerContext)
        {
            _summonerContext = summonerContext;
        }
        public async Task<SummonerEntry> GetSummonerFromDb(string name)
        {
            var selectedSummoner = await _summonerContext.Summoner
                .FirstOrDefaultAsync(x => x.SummonerName == name);
            return selectedSummoner;
        }

        public async Task<SummonerEntry> UpdateSummoner(string name, SummonerEntry summoner)
        {
            var summonerToUpdate = await GetSummonerFromDb(name);
            if (summonerToUpdate != null)
            {

                summonerToUpdate.SummonerName = summoner.SummonerName;
                summonerToUpdate.NumOfTimesSearched = summoner.NumOfTimesSearched;
                _summonerContext.Entry(summonerToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _summonerContext.SaveChangesAsync();
            }
            return summonerToUpdate;
        }
        public async Task AddSummonerInDb(SummonerEntry summoner)
        {
            var summonerToBeAdded = _summonerContext.Summoner
                                   .Add(summoner);
            await _summonerContext.SaveChangesAsync();
        }
        public async Task<TftSummonerEntry> GetTftSummonerFromDb(string name)
        {
            var selectedSummoner = await _summonerContext.TftSummoner
                .FirstOrDefaultAsync(x => x.SummonerName == name);
            return selectedSummoner;
        }
        public async Task AddTftSummonerInDb(TftSummonerEntry summoner)
        {
            var tftSummonerToBeAdded = _summonerContext.TftSummoner
                                        .Add(summoner);
            await _summonerContext.SaveChangesAsync();
        }
        public async Task<TftSummonerEntry> UpdateSummoner(string name, TftSummonerEntry summoner)
        {
            var summonerToUpdate = await GetTftSummonerFromDb(name);
            if (summonerToUpdate != null)
            {

                summonerToUpdate.SummonerName = summoner.SummonerName;
                summonerToUpdate.NumOfTimesSearched = summoner.NumOfTimesSearched;
                _summonerContext.Entry(summonerToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _summonerContext.SaveChangesAsync();
            }
            return summonerToUpdate;

        }
    }
}