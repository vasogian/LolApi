using LolApi.Models;
using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        private readonly SpectatorService _spectatorService;
        public SpectatorController(SpectatorService spectatorService)
        {
            _spectatorService = spectatorService;
        }
       
        [HttpGet]

        public async Task<IActionResult> GetCurrentGame(string summonerId)
        {
            var currentGame = await _spectatorService.GetCurrentGameInfo(summonerId);

            if(currentGame is null)
            {
                return NotFound();
            }
            return Ok(currentGame);
        }
    }
}
