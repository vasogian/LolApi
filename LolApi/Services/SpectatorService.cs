using LolApi.Models;

namespace LolApi.Services
{
    public class SpectatorService
    {
        public async Task<CurrentGameInfo> GetCurrentGameInfo(string summonerId)
        {
            using HttpClient riotClient = new HttpClient()
            {
                BaseAddress = new Uri("https://eun1.api.riotgames.com"),
                Timeout = new TimeSpan(0, 0, 30)
            };
            riotClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-0bd32807-31b5-4d01-a0ea-0c1597768b50");
            var httpResponse = await riotClient.GetAsync($"/lol/spectator/v4/active-games/by-summoner/{summonerId}");

            if(httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<CurrentGameInfo>();
            }
            return new CurrentGameInfo();
        }
    }
}
