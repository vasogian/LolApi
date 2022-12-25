using LolApi.Models;
using System.Net.Http.Json;

namespace LolApi.Services
{
    public class ChampionMasteryService
    {
        public async Task<List<ChampionMasteryDto>> GetChampionMasteryPts(string encryptedSummonerId)
        {          
            
           using HttpClient riotClient = new HttpClient()
            {
                BaseAddress = new Uri("https://eun1.api.riotgames.com"),
                Timeout = new TimeSpan(0, 0, 30)
            };
            riotClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-4a8d594f-5b50-4e54-b97e-9a76d66c5512");
            var HttpResponse = await riotClient.GetAsync($"/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/top");
            
            if(HttpResponse.IsSuccessStatusCode)
            {
                return await HttpResponse.Content.ReadFromJsonAsync<List<ChampionMasteryDto>>();
            }
            return new List<ChampionMasteryDto>();

        }
    }
}
