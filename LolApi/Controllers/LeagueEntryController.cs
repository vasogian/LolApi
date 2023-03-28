using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueEntryController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public LeagueEntryController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's current league
        /// </summary>
        /// <param name="summonerName">Summoner's name</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLeagueEntries(string summonerName)
        {
            var getEntrybyName = await _riotHttpClient.GetSummonerByName(summonerName);
            var getEntries = await _riotHttpClient.GetLeagueEntries(getEntrybyName.Id);

            if(!getEntries.Any())
            {
                return NotFound();
            }
            return Ok(getEntries);
        }
    }
}
