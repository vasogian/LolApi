
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
        public async Task<IActionResult> GetClashPlayer(string summonerId)
        {
            var clashPlayer = await _riotHttpClient.GetClashPlayer(summonerId);

            if (!clashPlayer.Any())
            {
                return NotFound();
            }
            return Ok(clashPlayer);
        }
    }
}
