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

        [HttpGet]

        public async Task<IActionResult> GetMatchHistory(string summonerName)
        {
            var getMatchHistoryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var getMatchHistory = await _riotHttpClient.GetMatchHistory(getMatchHistoryByName.Puuid);
            if(!getMatchHistory.Any())
            {
                return NotFound();
            }
            return Ok(getMatchHistory);
        }
    }
}
