using LolApi.HttpClients;
using LolApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LolApi.Models;

namespace LolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly RiotHttpClient _riotHttpClient;
        private readonly SummonerContextService _summonerContextService;
        public SummonerController(RiotHttpClient riotHttpClient, SummonerContextService summonerContextService)
        {
            _riotHttpClient = riotHttpClient;
            _summonerContextService = summonerContextService;
        }

        [HttpGet]

        public async Task<IActionResult> GetSummonerByName(string name)
        {
            var summonerDTO = await _riotHttpClient.GetSummonerByName(name);

            if(summonerDTO.Id is null)
            {
                return NotFound();
            } 
            var searchedSummoner = await _summonerContextService.GetSummonerFromDb(name);
            if (searchedSummoner is null)
            {
               await _summonerContextService.AddSummonerInDb(new SummonerEntry
                {                   
                    SummonerName = name,
                    NumOfTimesSearched = 1,
                });
            }
            else
            {
                await _summonerContextService.UpdateSummoner(name, new SummonerEntry
                {              
                    SummonerName = searchedSummoner.SummonerName,
                    NumOfTimesSearched = ++searchedSummoner.NumOfTimesSearched
                });
            }

            return Ok(summonerDTO);         

        }
    }
}
