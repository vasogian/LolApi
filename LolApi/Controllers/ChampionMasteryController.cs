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

        public async Task<IActionResult>GetChampionMasteryPts(string encryptedSummonerId, int count = 3)
        {
            var championMastery = await _riotHttpClient.GetChampionMasteryPts(encryptedSummonerId, count);
            if (!championMastery.Any())
                    {
                return NotFound();
            }
            return Ok(championMastery);          
        }

        
    }
}
