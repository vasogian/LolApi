using LolApi.Models;
using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueEntryController : ControllerBase
    {
        private readonly LeagueEntryService _leagueEntryService;
        public LeagueEntryController(LeagueEntryService leagueEntryService)
        {
            _leagueEntryService = leagueEntryService;   
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<LeagueEntryDTO>>> GetLeagueEntries(string encryptedSummonerId)
        {
            var getEntries = _leagueEntryService.GetLeagueEntries(encryptedSummonerId);
            return Ok(getEntries);
        }
    }
}
