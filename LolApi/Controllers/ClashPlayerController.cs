
using LolApi.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClashPlayerController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public ClashPlayerController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetClashPlayer(string summonerName)
        {
            var getClashPlayerByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var clashPlayer = await _riotHttpClient.GetClashPlayer(getClashPlayerByName.Id);

            if (!clashPlayer.Any())
            {
                return NotFound();
            }
            return Ok(clashPlayer);
        }
    }
}
