using LolApi.Models;

namespace LolApi.Services
{
    public class SummonerService
    {


        public async Task<SummonerDTO> GetSummonerByName(string name)
        {
            
            using HttpClient riotHttpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://eun1.api.riotgames.com"),
                Timeout = TimeSpan.FromSeconds(30)
            };
            riotHttpClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-0bd32807-31b5-4d01-a0ea-0c1597768b50");

            var httpResponse = await riotHttpClient.GetAsync($"/lol/summoner/v4/summoners/by-name/{name}");           
             
            if(httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<SummonerDTO>();
            }
            return new SummonerDTO();

        }
    }
}
