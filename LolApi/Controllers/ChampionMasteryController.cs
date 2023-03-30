using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public ChampionMasteryController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's top played champions
        /// </summary>
        /// <param name="summonerName">Summoner's name</param>
        /// <param name="count">Number of champions</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetChampionMasteryPts(string summonerName, int count = 3)
        {
            var getMasteryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var championMastery = await _riotHttpClient.GetChampionMasteryPts(getMasteryByName.Id, count);
            if (!championMastery.Any())
            {
                return NotFound();
            }
            return Ok(championMastery);
        }


    }
}
