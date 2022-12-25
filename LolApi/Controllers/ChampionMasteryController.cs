using LolApi.Models;
using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private readonly ChampionMasteryService _championMasteryService;
        public ChampionMasteryController(ChampionMasteryService championMasteryService)
        {
            _championMasteryService = championMasteryService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ChampionMasteryDto>>>GetChampionMasteryPts(string encryptedSummonerId)
        {
            var championMastery = await _championMasteryService.GetChampionMasteryPts(encryptedSummonerId);
            return Ok(championMastery);          
        }

        
    }
}
