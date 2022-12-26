using LolApi.Models;
using System.Net.Http.Json;

namespace LolApi.Services
{
    public class ChampionMasteryService
    {
       
        public async Task<List<ChampionMasteryDto>> GetChampionMasteryPts(string encryptedSummonerId, int count = 3)
        {

            using HttpClient riotClient = new HttpClient()
            {
                BaseAddress = new Uri("https://eun1.api.riotgames.com"),
                Timeout = new TimeSpan(0, 0, 30)
            };
            riotClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-0bd32807-31b5-4d01-a0ea-0c1597768b50");
            var HttpResponse = await riotClient.GetAsync($"/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/top?count={count}");

            if (HttpResponse.IsSuccessStatusCode)
            {
                return await HttpResponse.Content.ReadFromJsonAsync<List<ChampionMasteryDto>>();
            }
            return new List<ChampionMasteryDto>();

        }
    }
}
