using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LolApi.HttpClients;
using LolApi.Services;

namespace TFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengerController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        private readonly SummonerContextService _summonerContextService;

        public ChallengerController(RiotHttpClient riotHttpClient, SummonerContextService summonerContextService)
        {
            _riotHttpClient = riotHttpClient;   
            _summonerContextService = summonerContextService;
        }
        /// <summary>
        /// Calls Riot's api to get a list of all challenger summoners
        /// </summary>
        /// <returns>A list of all challenger playersRGAPI-3a5f3b30-7f63-43ec-8916-5a38033c96e2</returns>
        [HttpGet]
        public async Task<IActionResult> GetChallLeague()
        {
            var response = await _riotHttpClient.GetChallLeague();
            if(response is null)
            {
                return NotFound();
            }          
            return Ok(response);
        }
    }
}
