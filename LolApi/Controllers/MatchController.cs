using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LolApi.HttpClients;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        readonly RiotHttpClient _riotHttpClient;
        public MatchController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;   
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's match history
        /// </summary>
        /// <param name="summonerName">Summoner's name</param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMatchHistory(string summonerName, int start = 0, int count = 20)
        {
            var getMatchHistoryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var getMatchHistory = await _riotHttpClient.GetMatchHistory(getMatchHistoryByName.Puuid, start, count);
            if(!getMatchHistory.Any())
            {
                return NotFound();
            }
            return Ok(getMatchHistory);
        }
    }
}
