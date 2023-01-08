using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public ChampionMasteryController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }

        [HttpGet]

        public async Task<IActionResult> GetChampionMasteryPts(string summonerName, int count = 3)
        {
            var getMasteryByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var championMastery = await _riotHttpClient.GetChampionMasteryPts(getMasteryByName.Id, count);
            if (!championMastery.Any())
            {
                return NotFound();
            }
            return Ok(championMastery);
        }


    }
}
