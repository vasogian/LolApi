using LolApi.Database.Models;
using LolApi.HttpClients;
using LolApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace TFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TftEntry : ControllerBase
    {

        private readonly RiotHttpClient _riotHttpClient;
        private readonly SummonerContextService _summonerContextService;

        public TftEntry(RiotHttpClient riotHttpClient, SummonerContextService summonerContextService)
        {
            _riotHttpClient = riotHttpClient;
            _summonerContextService = summonerContextService;
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's tft league info
        /// </summary>
        /// <param name="summonerName">Summoner's name</param>
        /// <returns>Summoner's current league</returns>
        [HttpGet]
        public async Task<IActionResult> GetTftEntry(string summonerName)
        {
            var getEntryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var getEntry = await _riotHttpClient.GetTftEntry(getEntryByName.Id);
            if (!getEntry.Any())
            {
                return NotFound();
            }
            var searchedSummoner = await _summonerContextService.GetTftSummonerFromDb(summonerName);
            if (searchedSummoner is null)
            {
                await _summonerContextService.AddTftSummonerInDb(new TftSummonerEntry()
                {
                    SummonerName = summonerName,
                    NumOfTimesSearched = 1
                });
            }
            else
            {
                await _summonerContextService.UpdateSummoner(summonerName, new TftSummonerEntry()
                {
                    SummonerName = searchedSummoner.SummonerName,
                    NumOfTimesSearched = ++searchedSummoner.NumOfTimesSearched,
                });
            }
            return Ok(getEntry);
        }

    }
}
