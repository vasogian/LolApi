using LolApi.Models;
using System.Collections;

namespace LolApi.Services
{
    public class LeagueEntryService
    {
        public async Task<List<LeagueEntryDTO>> GetLeagueEntries(string encryptedSummonerId)
        {
            using HttpClient riotClient = new HttpClient
            {
                BaseAddress = new Uri("https://eun1.api.riotgames.com"),
                Timeout = new TimeSpan(0, 0, 30)
            };
            riotClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-0bd32807-31b5-4d01-a0ea-0c1597768b50");
            var clientResponse = await riotClient.GetAsync($"/lol/league/v4/entries/by-summoner/{encryptedSummonerId}");

            if(clientResponse.IsSuccessStatusCode)
            {
                return await clientResponse.Content.ReadFromJsonAsync<List<LeagueEntryDTO>>();
            }
            return new List<LeagueEntryDTO>();
        }
            
            



    }

}

