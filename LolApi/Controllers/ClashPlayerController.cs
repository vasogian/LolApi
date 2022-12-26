using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClashPlayerController : ControllerBase
    {
        private readonly ClashPlayerService _clashPlayerService;
        public ClashPlayerController(ClashPlayerService clashPlayerService)
        {
            _clashPlayerService = clashPlayerService;   
        }
        [HttpGet]
        public async Task<IActionResult> GetClashPlayer(string summonerId)
        {
            var clashPlayer = await _clashPlayerService.GetClashPlayer(summonerId);

            if (!clashPlayer.Any())
            {
                return NotFound();
            }
            return Ok(clashPlayer);
        }
    }
}
