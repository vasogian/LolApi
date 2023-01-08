using LolApi.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFT.Services;

namespace TFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TftEntry : ControllerBase
    {
        private readonly TftHttpClient _tftHttpClient;
        private readonly RiotHttpClient _riotHttpClient;

        public TftEntry(TftHttpClient tftHttpClient, RiotHttpClient riotHttpClient)
        {
            _tftHttpClient = tftHttpClient;
            _riotHttpClient = riotHttpClient;

        }
        [HttpGet]

        public async Task<IActionResult> GetTftEntry(string summonerName)
        {
            var getEntryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var getEntry = await _tftHttpClient.GetSummonerEntry(getEntryByName.Id);
            if(!getEntry.Any())
            {
                return NotFound();
            }
            return Ok(getEntry);
        }

    }
}
