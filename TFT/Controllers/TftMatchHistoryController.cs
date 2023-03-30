using LolApi.HttpClients;
using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TftMatchHistoryController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        
        public TftMatchHistoryController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;        
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's match history
        /// </summary>
        /// <param name="name">Summoner's name</param>
        /// <param name="count">Number of games</param>
        /// <returns>A list of games</returns>
        [HttpGet]
        public async Task<IActionResult> GetTftMatchHistory(string name, int count = 20)
        {
            var getSummonerByName = await _riotHttpClient.GetSummonerByName(name);
            var getSummonerHistory = await _riotHttpClient.GetTftMatchHistory(getSummonerByName.Puuid, count);
            if(!getSummonerHistory.Any())
            {
                return NotFound();
            }         
            return Ok(getSummonerHistory);
        }
    }
}
