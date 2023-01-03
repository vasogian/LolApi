using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public SpectatorController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }

        [HttpGet]

        public async Task<IActionResult> GetCurrentGame(string summonerId)
        {
            var currentGame = await _riotHttpClient.GetCurrentGameInfo(summonerId);

            if(currentGame is null)
            {
                return NotFound();
            }
            return Ok(currentGame);
        }
    }
}
