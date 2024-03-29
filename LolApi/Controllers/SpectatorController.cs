﻿using LolApi.HttpClients;
using LolApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        public SpectatorController(RiotHttpClient riotHttpClient)
        {
            _riotHttpClient = riotHttpClient;
        }
        /// <summary>
        /// Calls Riot's api to get a summoner's current game
        /// </summary>
        /// <param name="summonerName">Summoner's name</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCurrentGame(string summonerName)
        {
            var getGameByName = await _riotHttpClient.GetSummonerByName(summonerName);
            var currentGame = await _riotHttpClient.GetCurrentGameInfo(getGameByName.Id);

            if(!currentGame.participants.Any())
            {
                return NotFound();
            }
            return Ok(currentGame);
        }
    }
}
