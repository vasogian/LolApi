using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly SummonerService _summonerService;
        public SummonerController(SummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [HttpGet]

        public async Task<IActionResult> GetSummonerByName(string name)
        {
            var SummonerDTO = await _summonerService.GetSummonerByName(name);
            
            return Ok(SummonerDTO);
        }
    }
}
