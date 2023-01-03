using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueEntryController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public LeagueEntryController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }
        [HttpGet]

        public async Task<IActionResult> GetLeagueEntries(string encryptedSummonerId)
        {
            var getEntries = await _riotHttpClient.GetLeagueEntries(encryptedSummonerId);

            if(!getEntries.Any())
            {
                return NotFound();
            }
            return Ok(getEntries);
        }
    }
}
